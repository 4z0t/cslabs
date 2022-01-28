using System;
using System.Collections.Generic;
using System.Text;

namespace cslabs 
{
    [Serializable]
    class Person : IDateAndCopy,IComparable,IComparer<Person>
    {
        protected string name;
        protected string surname;
        protected DateTime birthdate;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string Surname
        {
            get { return this.surname; }
            set { this.surname = value; }
        }
        public DateTime Birthdate
        {
            get { return this.birthdate; }
            set { this.birthdate = value; }
        }

        public DateTime Date
        {
            get { return this.birthdate; }
            set { this.birthdate = value; }
        }
        public int Birthyear
        {
            get { return this.birthdate.Year; }
            set { this.birthdate = new DateTime(value, this.birthdate.Month, this.birthdate.Day, this.birthdate.Hour, this.birthdate.Minute, this.birthdate.Second); }
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Person p = (Person)obj;
                return (this.name.Equals(p.name) && this.birthdate.Equals(p.birthdate) && this.surname.Equals(p.surname));
            }
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Person person = obj as Person;
            if (person != null)
                return this.surname.CompareTo(person.surname);
            else
                throw new ArgumentException("Object must be Person");
        }

        public int Compare(Person a,Person b)
        {
            return a.birthdate.CompareTo(b.birthdate);
        }
        public static bool operator ==(Person left, Person right) => left.Equals(right);
        public static bool operator !=(Person left, Person right) => !left.Equals(right);
        public virtual object DeepCopy()
        {
            return (object)new Person(new string(this.name), new string(this.surname), new DateTime(this.birthdate.Ticks));
        }
        public override int GetHashCode()
        {
            return this.name.GetHashCode() ^ this.surname.GetHashCode() ^ this.birthdate.GetHashCode();
        }
        public Person() : this("null", "null", DateTime.Now) { }
        public Person(string name, string surname, DateTime birthdate)
        {
            this.name = name;
            this.surname = surname;
            this.birthdate = birthdate;
        }
        public Person(Person p)
        {
            this.name = p.name;
            this.surname = p.surname;
            this.birthdate = p.birthdate;
        }
        public override string ToString() => string.Format("{0} {1} {2}", this.surname, this.name, this.birthdate);
        virtual public string ToShortString() => string.Format("{1} {0}", this.name, this.surname);


    }
}
