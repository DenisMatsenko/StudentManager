using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>{
                new Student{
                    Name = "John", 
                    Age = 18, 
                    Marks = new List<Mark>{
                        new Mark{
                            SubjectName = "Math",
                            Description = "Homework", 
                            MarkValue = 1
                        },
                        new Mark{
                            SubjectName = "Math",
                            Description = "Test", 
                            MarkValue = 2
                        },
                        new Mark{
                            SubjectName = "Math",
                            Description = "Exam", 
                            MarkValue = 3
                        },
                        new Mark{
                            SubjectName = "English",
                            Description = "Homework", 
                            MarkValue = 4
                        }
                    }
                }
            };

            foreach (var student in students) {
                Console.WriteLine(student.Name + "\n" + student.WriteMarks());
            }
        }
    }
}