using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel;




namespace cslabs
{
    class StudentCollection<TKey> : IComparer<Student>
    {

        private Dictionary<TKey, Student> students;
        private KeySelector<TKey> selector;
        public string Name { get; set; }

        private void HandleEvent(object obj, EventArgs e)
        {
            var it = (PropertyChangedEventArgs)e;
            var st = (Student)obj;
            var key = selector(st);
            StudentPropertyChanged(Action.Property, it.PropertyName, key);
        }

        private void StudentPropertyChanged(Action action, string name, TKey key)
        {
            StudentsChanged?.Invoke(this, new StudentsChangedEventArgs<TKey>(Name, action, name, key));
        }

        public bool Remove(Student st)
        {
            if (students.ContainsValue(st))
            {
                var key = students.FirstOrDefault(x => x.Value == st).Key;
                StudentPropertyChanged(Action.Remove, "----", key);
                st.PropertyChanged -= HandleEvent;
                return students.Remove(key);
            }
            return false;
        }

        public StudentsChangedHandler<TKey> StudentsChanged;

        public StudentCollection(KeySelector<TKey> selector)
        {
            this.selector = selector;
            this.students = new Dictionary<TKey, Student>();
        }

        public void AddDefaults()
        {
            for (int i = 0; i < 10; i++)
            {

                Student st = new Student(new Person(TestCollectionsold.RandomString(10), "test", DateTime.Now), Education.Specialist, 20);
                this.students.Add(this.selector(st), st);
            }
        }
        public void AddStudents(Student[] students)
        {
            foreach (Student st in students)
                this.students.Add(this.selector(st), st);
        }

        public void Add(Student st) {
            var key = this.selector(st);
            this.students.Add(key, st);
            StudentPropertyChanged(Action.Add, "----", key);
            st.PropertyChanged += HandleEvent;
        }


        public int Compare(Student a, Student b) => a.AverageMark.CompareTo(b.AverageMark);


        public override string ToString()
        {
            string result = "";
            foreach (KeyValuePair<TKey, Student> keyValuePair in this.students)
            {
                result += keyValuePair.Value.ToString() + '\n';
            }
            return result;
        }
        public string ToShortString()
        {
            string result = "";
            foreach (KeyValuePair<TKey, Student> keyValuePair in this.students)
            {
                result += keyValuePair.Value.ToShortString() + '\n';
            }
            return result;
        }

        //public void SortBySurname() => this.students.Sort((Student a, Student b) => a.CompareTo(b));

        //public void SortByBirthDate() => this.students.Sort((Student a, Student b) => Compare(a, b));

        //public void SortByAverageMark() => this.students.Sort((Student a, Student b) => this.Compare(a, b));

        public double MaxAverargeMark
        {
            get
            {
                return this.students.Max((kv) => kv.Value.AverageMark);
            }
        }

        public IEnumerable<KeyValuePair<TKey, Student>> EducationForm(Education value)
        {
            return this.students.Where((kv) => kv.Value[value]);
        }

        public IEnumerable<IGrouping<Education, KeyValuePair<TKey, Student>>> GroupByEducation
        {
            get
            {
                return this.students.GroupBy((kv) => kv.Value.Edu);
            }
        }


    }
}
