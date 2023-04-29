using System;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        private static Dictionary<string, Student> students;
        private static ManagerCSV fm;
        public static void ColorWrite(ConsoleColor collor, string str, bool newLine = false) {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = collor;
            if (newLine)
                System.Console.WriteLine(str);
            else 
                System.Console.Write(str);
            Console.ForegroundColor = oldColor;
        }
        static void Main(string[] args)
        {
            fm = new ManagerCSV();
            students = fm.GetAllStudent();
            Menu();
        }
        private static void Menu() {
            Console.Clear();
            ColorWrite(ConsoleColor.Green,  "1. Add student",       true);
            ColorWrite(ConsoleColor.Green,  "2. Add mark",          true);
            ColorWrite(ConsoleColor.Green,  "3. Show all students", true);
            ColorWrite(ConsoleColor.Green,  "4. Exit",              true);
            ColorWrite(ConsoleColor.Yellow, "5. Update student",    true);
            ColorWrite(ConsoleColor.Yellow, "6. Update mark",       true);
            ColorWrite(ConsoleColor.Red,    "7. Delete student",    true);
            ColorWrite(ConsoleColor.Red,    "8. Delete mark",       true);
            ColorWrite(ConsoleColor.Blue,   "Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());
            switch (choice) {
                case 1:
                    AddStudent();
                    break;
                case 7:
                    DeleteStudent();
                    break;
                case 5:
                    UpdateStudent();
                    break;
                case 2:
                    AddMark();
                    break;
                case 8:
                    DeleteMark();
                    break;
                case 6:
                    UpdateMark();
                    break;
                case 3:
                    ShowAllStudents();
                    break;
                case 4:
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
            fm.AddStudent(student);
        }
        private static void DeleteStudent() {
            Console.Clear();
            Console.WriteLine("Enter student first name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter student last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter student age:");
            int age = int.Parse(Console.ReadLine());
            Student student = new Student(name, lastName, age);

            fm.DeleteStudent(student, students);
            students.Remove(student.ID);
        }
        private static void UpdateStudent() {
            Console.Clear();
            Console.WriteLine("Enter student first name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter student last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter new student age:");
            int age = int.Parse(Console.ReadLine());

            // ! Need explanation
            string studentId = Student.ConvertToID(name, lastName);
            Student studentOld = students[studentId];
            fm.DeleteStudent(studentOld, students);
            students[studentId].Age = age;
            fm.AddStudent(students[studentId]);
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
            fm.AddMark(mark);
        }
        private static void DeleteMark() {
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
            students[id].RemoveMark(mark);
            fm.DeleteMark(mark);
        }
        private static void UpdateMark() {
            Console.Clear();
            Console.WriteLine("Enter student first name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter student last name:");
            string lastName = Console.ReadLine();
            string id = Student.ConvertToID(name, lastName);

            Console.WriteLine("Enter mark subject name:");
            string subjectName = Console.ReadLine();
            Console.WriteLine("Enter mark description:");
            string description = Console.ReadLine();

            // * OLD MARK
            Console.WriteLine("Enter old mark value:");
            int markValueOld = int.Parse(Console.ReadLine());

            // * NEW MARK
            Console.WriteLine("Enter new mark value:");
            int markValueNew = int.Parse(Console.ReadLine());

            Mark markOld = new Mark(id, subjectName, markValueOld, description);
            Mark markNew = new Mark(id, subjectName, markValueNew, description);

            students[id].RemoveMark(markOld);
            fm.DeleteMark(markOld);
            students[id].AddMark(markNew);
            fm.AddMark(markNew);
        }
        private static void ShowAllStudents() {
            Console.Clear();
            Student.WriteAll(students);
        }
    }
}