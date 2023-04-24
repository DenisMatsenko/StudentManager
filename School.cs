using System;

namespace Program {
    public class Student {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Mark> Marks = new List<Mark>();
        public Student(string name, int age) {
            Name = name;
            Age = age;
        }
        public string ToString() {
            string student = $"Name: {Name}, Age: {Age}";
            foreach (var mark in Marks) {
                student += $"\n\t{mark.WriteMark()}";
            }
            return student;
        }
    }

    public class Mark {
        public string SubjectName { get; set; }
        public string Description { get; set; }
        public int MarkValue { get; set; }

        public Mark(string subjectName, int markValue, string description) {
            SubjectName = subjectName;
            MarkValue = markValue;
            Description = description;
        }

        public string WriteMark() {
            return $"{SubjectName} - {MarkValue} - {Description}";
        }
    }
}