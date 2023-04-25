using System;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
            
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            ManagerCSV sm = new ManagerCSV();

            // sm.AddStudent(new Student("Kuba", 17));


            List<Student> students = sm.GetAllStudent();
            Student.ListWrite(students);

            // List<Mark> marks = new List<Mark> {
            //     new Mark (
            //         "English",
            //         1,
            //         "Homework"
            //     )
            // };


            // sm.AddMarks(students[0], marks);

            // Student.ListWrite(students);

            // List<Student> students = new List<Student>{
            //     new Student{
            //         Name = "John", 
            //         Age = 18, 
            //         Marks = new List<Mark>{
            //             new Mark{
            //                 SubjectName = "Math",
            //                 Description = "Homework", 
            //                 MarkValue = 1
            //             },
            //             new Mark{
            //                 SubjectName = "Math",
            //                 Description = "Test", 
            //                 MarkValue = 2
            //             },
            //             new Mark{
            //                 SubjectName = "Math",
            //                 Description = "Exam", 
            //                 MarkValue = 3
            //             },
            //             new Mark{
            //                 SubjectName = "English",
            //                 Description = "Homework", 
            //                 MarkValue = 4
            //             }
            //         }
            //     }
            // };

            // foreach (var student in students) {
            //     Console.WriteLine(student.Name + "\n" + student.WriteMarks());
            // }
        }


        public static void ColorWrite(ConsoleColor collor, string str, bool newLine = false) {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = collor;
            if (newLine)
                System.Console.WriteLine(str);
            else 
                System.Console.Write(str);
            Console.ForegroundColor = oldColor;
        }
    }


}