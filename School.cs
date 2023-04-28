using System;
using System.Collections.Generic;

namespace Program {
    public class Student {
        public string ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public int Age { get; set; }
        private List<Mark> Marks = new List<Mark>();
        public void AddMark (Mark mark) {
            Marks.Add(mark);
        }
        public void RemoveMark (Mark mark) {
            Marks.Remove(mark);
        }
        public List<Mark> GetAllMarks() {
            return Marks;
        }
        public static string ConvertToID(string name, string lastName) {
            return (lastName.Substring(0, 4) + name.Substring(0, 2)).ToLower();
        }
        public Student() {}
        public Student(string id, string name, string lastName, int age) {
            ID = id;
            Name = name;
            LastName = lastName;
            Age = age;
            BirthYear = DateTime.Now.Year - age;
        }
        public Student(string name, string lastName, int age) {
            ID = (lastName.Substring(0, 4) + name.Substring(0, 2)).ToLower();
            Name = name;
            LastName = lastName;
            Age = age;
            BirthYear = DateTime.Now.Year - age;
        }
        public void Write() {
            Program.ColorWrite(ConsoleColor.Green, $"{Name} {LastName} - {Age}\n");
            foreach (var mark in Marks) {
                mark.Write();
            }
        }
        public static void ListWrite(Dictionary<string, Student> students) {
            foreach (KeyValuePair<string, Student> item in students) {
                item.Value.Write();
            }
        }
    }

    public class Mark {
        public string StudentID { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }
        public int MarkValue { get; set; }

        public Mark() {}

        public Mark(string studentId, string subjectName, int markValue, string description) {
            StudentID = studentId;
            SubjectName = subjectName;
            MarkValue = markValue;
            Description = description;
        }

        public void Write() {
            Program.ColorWrite(ConsoleColor.Yellow, $"\t{SubjectName} - {MarkValue} - {Description}\n");
        }
    }
}