using System;
using System.Collections.Generic;
using System.Text;

namespace cslabs
{
    class Exam : IDateAndCopy, IComparable , IComparer<Exam>
    {
        public string Subject { get; set; }
        public int Mark { get; set; }
        public DateTime Date { get; set; }
        public Exam(string subject, int mark, DateTime date)
        {
            this.Date = date;
            this.Mark = mark;
            this.Subject = subject;
        }
        public Exam() : this("Maths", 0, DateTime.Now) { }
        public override string ToString() => string.Format("{0} {1} {2}", this.Subject, this.Mark, this.Date);
        public object DeepCopy()
        {
            return (object)new Exam(new string(this.Subject), this.Mark, new DateTime(this.Date.Ticks));
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Exam ex = obj as Exam;
            if (ex != null)
                return this.Subject.CompareTo(ex.Subject);
            else
                throw new ArgumentException("Object must be Exam");
        }
        public int Compare(Exam a, Exam b)
        {
            return a.Mark.CompareTo(b.Mark);
        }


    }
}
