using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace cslabs
{
    class StudentCollection : IComparer<Student>
    {
        private List<Student> students;
        public void AddDefaults()
        {
            this.students.Add(new Student());
        }
        public void AddStudents(Student[] students)
        {
            this.students.AddRange(students);
        }

        public int Compare(Student a, Student b) => a.AverageMark.CompareTo(b.AverageMark);


        public override string ToString()
        {
            string result = "";
            foreach (Student student in this.students)
            {
                result += student.ToString() + '\n';
            }
            return result;
        }
        public string ToShortString()
        {
            string result = "";
            foreach (Student student in this.students)
            {
                result += student.ToShortString() + '\n';
            }
            return result;
        }

        public void SortBySurname() => this.students.Sort((Student a, Student b) => a.CompareTo(b));

        public void SortByBirthDate() => this.students.Sort((Student a, Student b) => Compare(a, b));

        public void SortByAverageMark() => this.students.Sort((Student a, Student b) => this.Compare(a, b));

        public double MaxAverargeMark
        {
            get
            {
                return System.Linq.Enumerable.Max(this.students, (Student a) => a.AverageMark); ;
            }
        }
        public IEnumerable<Student> Specialists
        {
            get
            {
                return Enumerable.Where(this.students, (Student a) => a[Education.Specialist]);
            }
        }


        //public List<Student> AverageMarkGroup(double value)
        //{

        //    var studentGroups = students.GroupBy(std => std.AverageMark == value);
        //    return 

        //}

    }
}
