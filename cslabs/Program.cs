using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;



namespace cslabs
{
    class Program
    {
        static void Main(string[] args)
        {

            Person jane = new Person("Jane", "Smith", DateTime.Now);
            Student st = new Student(jane, Education.Вachelor, 2);
            Exam[] ex = {
             new Exam("Maths", 4, DateTime.Now),
             new Exam("English", 5, DateTime.Now),
             new Exam("Physics", 3, DateTime.Now),
             new Exam("Chemistry", 4, DateTime.Now),
            };
            st.AddExams(ex);
            Student stCopy = st.DeepCopy() as Student;
            Console.WriteLine("Original:");
            Console.WriteLine(st);
            Console.WriteLine("DeepCopy:");
            Console.WriteLine(stCopy);
            Console.WriteLine("Enter filename");
            var fileName = Console.ReadLine();
            var workingDir = Environment.CurrentDirectory;
            var projectDir = Directory.GetParent(workingDir).Parent.Parent.FullName;
            fileName = projectDir + "/" + fileName;

            FileInfo file = new FileInfo(fileName);
            if (file.Exists)
            {
                Console.WriteLine("Loading existing file");
                st.Load(fileName);
            }
            else
            {
                Console.WriteLine("New file created");
                File.Create(fileName).Close();
            }






            Console.WriteLine(st);



            st.AddFromConsole();
            st.Save(fileName);

            Console.WriteLine(st);



            Student.Load(fileName, st);
            st.AddFromConsole();
            Student.Save(fileName, st);
            Console.WriteLine(st);
        }
    }
}
