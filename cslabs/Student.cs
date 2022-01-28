using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


namespace cslabs
{
    delegate TKey KeySelector<TKey>(Student st);
    [Serializable]
    class Student : Person, IDateAndCopy, IEnumerable, INotifyPropertyChanged
    {

        private Education edu;
        private int group;
        private List<Test> tests;
        private List<Exam> exams;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnHandleEvent(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public Student(Person student, Education edu, int group) : base(student)
        {
            this.edu = edu;
            this.group = group;
            this.exams = new List<Exam>(0);
            this.tests = new List<Test>(0);
        }

        public Student(string name, string surname, DateTime birthdate, Education edu, int group) : base(name, surname, birthdate)
        {
            this.edu = edu;
            this.group = group;
            this.exams = new List<Exam>(0);
            this.tests = new List<Test>(0);
        }


        public Student() : this(new Person(), Education.Вachelor, 0) { }
        public Person Stud
        {
            get { return (Person)this; }
            set
            {
                this.name = value.Name;
                this.surname = value.Surname;
                this.birthdate = value.Birthdate;
                OnHandleEvent("Stud");
            }
        }
        public Education Edu { get { return this.edu; } set { this.edu = value; OnHandleEvent("Edu"); } }
        public int Group
        {
            get { return this.group; }
            set
            {
                if (value <= 100 || value > 599)
                    throw new Exception("group must be between 100 and 599");
                this.group = value;
            }
        }
        public List<Exam> Exams { get { return this.exams; } set { this.exams = value; OnHandleEvent("Exams"); } }

        public double AverageMark
        {
            get
            {
                double avg = 0;
                foreach (Exam exam in this.exams)
                {
                    avg += exam.Mark;
                }
                return avg / this.exams.Count;
            }
        }

        public bool this[Education edu]
        {
            get
            {
                return this.edu == edu;
            }
        }

        public void AddExams(Exam[] exams)
        {
            this.exams.AddRange(exams);
            OnHandleEvent("exams");
        }

        public IEnumerable GetExams(int mark)
        {
            foreach (Exam ex in this.exams)
                if (ex.Mark > mark)
                    yield return ex;
        }

        public IEnumerable GetExamsAndTests()
        {
            foreach (Exam ex in this.exams)
                yield return ex;
            foreach (Test tst in this.tests)
                yield return tst;
        }

        public override string ToString()
        {

            string result = string.Format("{0}: {1} {2}\n", base.ToShortString(), this.group, this.edu);
            foreach (Exam ex in this.exams)
                result += ex + "\n";
            foreach (Test tst in this.tests)
                result += tst + "\n";
            return result;


        }

        public IEnumerator GetEnumerator()
        {
            foreach (Exam ex in this.exams)
                foreach (Test test in this.tests)
                    if (ex.Subject == test.Subject)
                        yield return ex.Subject;

        }

        public void SortBySubject()
        {
            this.exams.Sort((ex1, ex2) => ex1.Subject.CompareTo(ex2.Subject));
        }

        public void SortByMark()
        {
            this.exams.Sort((ex1, ex2) => ex1.Mark.CompareTo(ex2.Mark));
        }

        public void SortByDate()
        {
            this.exams.Sort((ex1, ex2) => ex1.Date.CompareTo(ex2.Date));
        }
        public override object DeepCopy()
        {

            MemoryStream memoryStream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(memoryStream) as Student;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public override string ToShortString()
        {
            return string.Format("{0}: {1} {2} {3}", base.ToShortString(), this.group, this.edu, this.AverageMark);
        }

        public bool Save(string filename)
        {
            return Save(filename, this);
        }

        public bool Load(string filename)
        {
            return Load(filename, this);
        }

        public bool AddFromConsole()
        {
            //TODO:
            return true;
        }

        public static bool Save(string filename, Student obj)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(stream, obj);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }
        public static bool Load(string filename, Student obj)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    Student st = formatter.Deserialize(stream) as Student;
                    obj.name = st.name;
                    obj.surname = st.surname;
                    obj.birthdate = st.birthdate;
                    obj.edu = st.edu;
                    obj.exams = st.exams;
                    obj.tests = st.tests;
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }



    }
}
