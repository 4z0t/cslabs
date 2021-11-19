using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;

namespace cslabs
{
    class TestCollectionsold
    {
        List<Person> persons;
        List<string> list;
        Dictionary<Person, Student> personStudent;
        Dictionary<string, Student> studentDict;

        public TestCollectionsold(int value)
        {
            this. persons = new List<Person>(value);
            this.list = new List<string>(value);
            this.personStudent = new Dictionary<Person, Student>(value);
            this.studentDict = new Dictionary<string, Student>(value);
            //Person test = new Person("Jane", "Smith", DateTime.Now);
            //Student st = new Student(test, Education.Вachelor, 2);
            Exam[] ex = new Exam[4];
            ex[0] = new Exam("Maths", 4, DateTime.Now);
            ex[1] = new Exam("English", 5, DateTime.Now);
            ex[2] = new Exam("Physics", 3, DateTime.Now);
            ex[3] = new Exam("Chemistry", 4, DateTime.Now);
            //st.AddExams(ex);
            for (int i = 0; i < value; i++)
            {
                Person p = new Person(RandomString(10), "test", DateTime.Now);
                Student st = new Student(p, Education.Вachelor, 20);
                st.AddExams(ex);
                persons.Add(p);
                list.Add(st.Name);
                personStudent.Add(p, st);
                studentDict.Add(p.Name,st);
            }
        }
        public void CalcTime()
        {
            
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Total count of elements in persons: "+this.persons.Count);
            sw.Start();
            this.persons.Contains(this.persons[0]);
            sw.Stop();
            Console.WriteLine("search first element in list of persons: " + sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            this.persons.Contains(this.persons[this.persons.Count/2]);
            sw.Stop();
            Console.WriteLine("search middle element in list of persons: " + sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            this.persons.Contains(this.persons.Last());
            sw.Stop();
            Console.WriteLine("search last element in list of persons: " + sw.ElapsedMilliseconds);
            sw.Reset();


            Console.WriteLine("Total count of elements in names: " + this.list.Count);
            sw.Start();
            this.list.Contains(this.list[0]);
            sw.Stop();
            Console.WriteLine("search first element in list of names: " + sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            this.list.Contains(this.list[this.list.Count / 2]);
            sw.Stop();
            Console.WriteLine("search middle element in list of names: " + sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            this.list.Contains(this.list.Last());
            sw.Stop();
            Console.WriteLine("search last element in list of names: " + sw.ElapsedMilliseconds);
            sw.Reset();

            Console.WriteLine("Total count of key elements in person-student: " + this.personStudent.Count);
            sw.Start();
            this.personStudent.ContainsKey(this.persons[0]);
            sw.Stop();
            Console.WriteLine("search first element in list of person-student: " + sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            this.personStudent.ContainsKey(this.persons[this.persons.Count / 2]);
            sw.Stop();
            Console.WriteLine("search middle element in list of person-student: " + sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            this.personStudent.ContainsKey(this.persons.Last());
            sw.Stop();
            Console.WriteLine("search last element in list of person-student: " + sw.ElapsedMilliseconds);
            sw.Reset();

            
            sw.Start();
            this.personStudent.ContainsValue(this.personStudent[this.persons[0]]);
            sw.Stop();
            Console.WriteLine("search first element in list of person-student: " + sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            this.personStudent.ContainsValue(this.personStudent[this.persons[this.persons.Count / 2]]);
            sw.Stop();
            Console.WriteLine("search middle element in list of person-student: " + sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            this.personStudent.ContainsValue(this.personStudent[this.persons.Last()]);
            sw.Stop();
            Console.WriteLine("search last element in list of person-student: " + sw.ElapsedMilliseconds);
            sw.Reset();

            Console.WriteLine("Total count of key elements in name-student: " + this.studentDict.Count);
            sw.Start();
            this.studentDict.ContainsKey(this.persons[0].Name);
            sw.Stop();
            Console.WriteLine("search first element in list of name-student: " + sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            this.studentDict.ContainsKey(this.persons[this.persons.Count / 2].Name);
            sw.Stop();
            Console.WriteLine("search middle element in list of name-student: " + sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            this.studentDict.ContainsKey(this.persons.Last().Name);
            sw.Stop();
            Console.WriteLine("search last element in list of name-student: " + sw.ElapsedMilliseconds);
            sw.Reset();

            //Console.WriteLine("Total count of value elements in name-student: " + this.persons.Count);
            sw.Start();
            this.studentDict.ContainsValue(this.personStudent[this.persons[0]]);
            sw.Stop();
            Console.WriteLine("search first element in list of name-student: " + sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            this.studentDict.ContainsValue(this.personStudent[this.persons[this.persons.Count / 2]]);
            sw.Stop();
            Console.WriteLine("search middle element in list of name-student: " + sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            this.studentDict.ContainsValue(this.personStudent[this.persons.Last()]);
            sw.Stop();
            Console.WriteLine("search last element in list of name-student: " + sw.ElapsedMilliseconds);
            sw.Reset();

        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
