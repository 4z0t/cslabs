using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace cslabs
{
    class Program
    {
        static void Main(string[] args)
        {
            Person jane = new Person("Jane", "Smith", DateTime.Now);
            Person b = new Person();
            Console.WriteLine(jane.ToShortString());
            Console.WriteLine(b.ToShortString());
            Student st = new Student(jane, Education.Вachelor, 2);
            Exam[] ex = {
             new Exam("Maths", 4, DateTime.Now),
             new Exam("English", 5, DateTime.Now),
             new Exam("Physics", 3, DateTime.Now),
             new Exam("Chemistry", 4, DateTime.Now),
            };
            st.AddExams(ex);

            Console.WriteLine(st);
            st.SortByDate();
            Console.WriteLine(st);
            st.SortByMark();
            Console.WriteLine(st);
            st.SortBySubject();
            Console.WriteLine(st);

          
            Student st1 = new Student("Bruh", "Bruhson", DateTime.Now, Education.SecondEducation, 1);
            Exam[] ex1 = {
             new Exam("Maths", 3, DateTime.Now),
             new Exam("English", 2, DateTime.Now),
             new Exam("Physics", 5, DateTime.Now),
             new Exam("Chemistry", 5, DateTime.Now),
             new Exam("PE", 4, DateTime.Now),
            };
            st1.AddExams(ex1);

            Student st2 = new Student("Ez", "Pez", DateTime.Now, Education.Specialist, 1);
            Exam[] ex2 = {
             new Exam("Maths", 5, DateTime.Now),
             new Exam("English", 5, DateTime.Now),
             new Exam("Physics", 5, DateTime.Now),
             new Exam("Chemistry", 5, DateTime.Now),
             new Exam("PE", 5, DateTime.Now),
            };
            st2.AddExams(ex2);

            Student st3 = new Student("Kappa", "pride", DateTime.Now, Education.Specialist, 2);
            Exam[] ex3 = {
             new Exam("Maths", 3, DateTime.Now),
             new Exam("English", 3, DateTime.Now),
             new Exam("Physics", 4, DateTime.Now),
             new Exam("Chemistry", 4, DateTime.Now),
             new Exam("PE", 5, DateTime.Now),
            };
            st3.AddExams(ex3);

            StudentCollection<string> scs = new StudentCollection<string>(delegate (Student s)
            {
                return s.Stud.Name.GetHashCode().ToString();
            });
            scs.Add(st);
            scs.Add(st1);
            scs.Add(st2);
            scs.Add(st3);
            Console.WriteLine(scs);
            Console.WriteLine(scs.MaxAverargeMark);
            foreach (KeyValuePair<string, Student> kv in scs.EducationForm(Education.Specialist))
                Console.WriteLine(kv.Value);

            foreach (IGrouping<Education,KeyValuePair< string, Student>> ig in scs.GroupByEducation)
            {
                Console.WriteLine(ig.Key);
                foreach (KeyValuePair<string, Student> kv in ig)
                    Console.WriteLine(kv.Value);
            }

            TestCollections<Person, Student> tc = new TestCollections<Person, Student>(10000000,
            delegate (int j)
                {
                    Person per = new Person(TestCollectionsold.RandomString(10 + j % 10), TestCollectionsold.RandomString(10 + j % 10), DateTime.Now);
                    Student sts = new Student(per, Education.Specialist, 20);
                    return new KeyValuePair<Person, Student>(per, sts);
                });
            tc.CalcTime();



        }
    }
}
