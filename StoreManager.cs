using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Program
{
    public interface IStudentStoreManager
    {
        void AddStudent(Student student);
        void AddMarks(Student student, List<Mark> marks);
        List<Student> GetAllStudent();
    }

    class ManagerCSV : IStudentStoreManager
    {
        const string STUDENT_FILE = "students.csv";
        const string MARKS_FILE = "marks.csv";

        private void CheckFileExistence() {
            if(!File.Exists(STUDENT_FILE))
                File.Create(STUDENT_FILE).Close();
            if(!File.Exists(MARKS_FILE))
                File.Create(MARKS_FILE).Close();
        }
        
        public void AddStudent(Student student) {
            CheckFileExistence();
            List<string> students = File.ReadAllLines(STUDENT_FILE).ToList();
            students.Add($"{student.Name},{student.Age}");

            students = students.
                OrderBy(s => s.Split(',')[0]).
                ThenBy(s => s.Split(',')[1]).
                ToList();
            File.WriteAllLines(STUDENT_FILE, students);
        }
        public void AddMarks(Student student, List<Mark> marks) {
            CheckFileExistence();
            List<string> rMarks = File.ReadAllLines(MARKS_FILE).ToList();
            foreach (var mark in marks) {
                string line = $"{student.Name},{mark.SubjectName},{mark.MarkValue},{mark.Description}";
                rMarks.Add(line);
            }
            rMarks = rMarks.
                OrderBy(s => s.Split(',')[0]).
                ThenBy(s => s.Split(',')[1]).
                ThenBy(s => s.Split(',')[2]).
                ThenBy(s => s.Split(',')[3]).
                ToList();
            File.WriteAllLines(MARKS_FILE, rMarks);
        }

        public List<Student> GetAllStudent() {
            CheckFileExistence();

            List<string> rStudents = File.ReadAllLines(STUDENT_FILE).ToList();
            List<string> rMarks = File.ReadAllLines(MARKS_FILE).ToList();

            // * This part of code will iterate through the list of students and marks
            // * and return a new list of students with thair marks
            List<Student> studentList = new List<Student>();
            foreach (var student in rStudents) {
                string[] studentInfo = student.Split(',');
                if(studentInfo.Length != 2)
                    continue;
                Student newStudent = new Student(studentInfo[0], int.Parse(studentInfo[1]));
                List<Mark> marks = new List<Mark>();
                foreach (var mark in rMarks) {
                    string[] markInfo = mark.Split(',');
                    if(markInfo.Length != 4)
                        continue;
                    if (markInfo[0] == newStudent.Name) {
                        Mark newMark = new Mark(markInfo[1], int.Parse(markInfo[2]), markInfo[3]);
                        marks.Add(newMark);
                    }
                }
                newStudent.Marks = marks;
                studentList.Add(newStudent);
            }
            return studentList;
        }

    }
}