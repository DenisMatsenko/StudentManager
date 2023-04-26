using System;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        private static Dictionary<string, Student> students;
        private static ManagerCSV sm;
        static void Main(string[] args)
        {
            sm = new ManagerCSV();
            students = sm.GetAllStudent();
            Menu();
        }
        private static void Menu() {
            Console.Clear();
            Console.WriteLine("1. Add student");
            Console.WriteLine("2. Delete student");
            Console.WriteLine("3. Update student");
            Console.WriteLine("4. Add mark");
            Console.WriteLine("5. Delete mark");
            Console.WriteLine("6. Update mark");
            Console.WriteLine("7. Show all students");
            Console.WriteLine("8. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice) {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    DeleteStudent();
                    break;
                case 3:
                    UpdateStudent();
                    break;
                case 4:
                    AddMark();
                    break;
                case 5:
                    DeleteMark();
                    break;
                case 6:
                    UpdateMark();
                    break;
                case 7:
                    ShowAllStudents();
                    break;
                case 8:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong choice!");
                    break;
            }
            ColorWrite(ConsoleColor.Red, "Done. Press any key to continue...");
            Console.ReadKey();
            Menu();
        }
        private static void AddStudent() {
            Console.Clear();
            Console.WriteLine("Enter student first name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter student last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter student age:");
            int age = int.Parse(Console.ReadLine());
            Student student = new Student(name, lastName, age);

            students.Add(student.ID, student);
            sm.AddStudent(student);
        }
        private static void DeleteStudent() {
            //Todo
        }
        private static void UpdateStudent() {
            //Todo
        }
        private static void AddMark() {
            Console.Clear();
            Console.WriteLine("Enter student first name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter student last name:");
            string lastName = Console.ReadLine();
            string id = Student.ConvertToID(name, lastName);
            Console.WriteLine("Enter subject name:");
            string subjectName = Console.ReadLine();
            Console.WriteLine("Enter mark value:");
            int markValue = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter mark description:");
            string description = Console.ReadLine();
            Mark mark = new Mark(id, subjectName, markValue, description);

            students[id].AddMark(mark);
            sm.AddMark(mark);
        }
        private static void DeleteMark() {
            //Todo
        }
        private static void UpdateMark() {
            //Todo
        }
        private static void ShowAllStudents() {
            Console.Clear();
            Student.ListWrite(students);
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