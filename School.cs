using System;
using System.Collections.Generic;

namespace Program {
    public class Student {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Mark> Marks = new List<Mark>();
        public Student(string id, string name, int age) {
            ID = id;
            Name = name;
            Age = age;
        }

        public Student(string name, int age) {
            ID = Guid.NewGuid().ToString();
            Name = name;
            Age = age;
        }
        public void Write() {
            Program.ColorWrite(ConsoleColor.Green, $"Name: {Name}, Age: {Age} ");
            Program.ColorWrite(ConsoleColor.Red, ID, true);
            foreach (var mark in Marks) {
                mark.Write();
            }
        }
        public static void ListWrite(List<Student> students) {
            foreach (var student in students) {
                student.Write();
            }
        }
    }

    public class Mark {
        public string ID { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }
        public int MarkValue { get; set; }

        public Mark(string subjectName, int markValue, string description) {
            ID = Guid.NewGuid().ToString();
            SubjectName = subjectName;
            MarkValue = markValue;
            Description = description;
        }

        public Mark(string id, string subjectName, int markValue, string description) {
            ID = id;
            SubjectName = subjectName;
            MarkValue = markValue;
            Description = description;
        }

        public void Write() {
            Program.ColorWrite(ConsoleColor.Yellow, $"\t{SubjectName} - {MarkValue} - {Description} ");
            Program.ColorWrite(ConsoleColor.Red, ID, true);
        }
    }
}