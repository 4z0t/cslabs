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
            //Person jane = new Person("Jane", "Smith", DateTime.Now);
            //Person b = new Person();
            //Console.WriteLine(jane.ToShortString());
            //Console.WriteLine(b.ToShortString());
            //Student st = new Student(jane, Education.Вachelor, 2);
            //Exam[] ex = new Exam[4];
            //ex[0] = new Exam("Maths", 4, DateTime.Now);
            //ex[1] = new Exam("English", 5, DateTime.Now);
            //ex[2] = new Exam("Physics", 3, DateTime.Now);
            //ex[3] = new Exam("Chemistry", 4, DateTime.Now);



            //st.AddExams(ex);
            //st.AddExams(ex);
            //Console.WriteLine(st);
            //Person j = (Person)jane.DeepCopy();

            //Console.WriteLine(((object)jane) == ((object)j));
            //Console.WriteLine(((object)jane).Equals((object)j));

            //Console.WriteLine(jane.GetHashCode());
            //Console.WriteLine(j.GetHashCode());
            //Console.WriteLine(jane);
            //Console.WriteLine(b.GetHashCode());

            //Student newst = st.DeepCopy() as Student;
            //Console.WriteLine(newst );
            //Console.WriteLine(((object)newst) == ((object)st));
            //newst.Group = 22;
            TestCollectionsold tc = new TestCollectionsold(1000000);
            tc.CalcTime();


        }
    }
}
