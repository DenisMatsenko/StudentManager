using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Program
{
    public interface IStudentStoreManager
    {
        void CheckFileExistence();
        void AddStudent(Student student);
        void DeleteStudent(Student std, Dictionary<string, Student> students);
        Dictionary<string, Student> GetAllStudent();
        void AddMark(Mark mark);
        void DeleteMark(Mark mark);
    }
    class ManagerCSV : IStudentStoreManager
    {
        const string STUDENT_FILE = "students.csv";
        const string MARKS_FILE = "marks.csv";
        public void CheckFileExistence() {
            if(!File.Exists(STUDENT_FILE))
                File.Create(STUDENT_FILE).Close();
            if(!File.Exists(MARKS_FILE))
                File.Create(MARKS_FILE).Close();
        }
        public void AddStudent(Student student) {
            CheckFileExistence();
            string line = $"{student.ID},{student.Name},{student.LastName},{student.BirthYear},{student.Age}";
            File.AppendAllText(STUDENT_FILE, line + Environment.NewLine);

            // ! Need to add marks
            foreach (Mark mark in student.GetAllMarks())
            {
                AddMark(mark);
            }
        }
        public void DeleteStudent(Student std, Dictionary<string, Student> students) {
            CheckFileExistence();
            Student studentToDelete = students[std.ID];

            List<string> studentStrList = File.ReadAllLines(STUDENT_FILE).ToList();
            studentStrList.Remove($"{studentToDelete.ID},{studentToDelete.Name},{studentToDelete.LastName},{studentToDelete.BirthYear},{studentToDelete.Age}");
            File.WriteAllLines(STUDENT_FILE, studentStrList.ToArray());

            foreach(Mark mark in studentToDelete.GetAllMarks()) {
                DeleteMark(mark);
            }
        }
        public void AddMark(Mark mark) {
            CheckFileExistence();
            string line = $"{mark.StudentID},{mark.SubjectName},{mark.MarkValue},{mark.Description}";
            File.AppendAllText(MARKS_FILE, line + Environment.NewLine);
        }
        public void DeleteMark(Mark mark) {
            CheckFileExistence();
            List<string> marksStrList = File.ReadAllLines(MARKS_FILE).ToList();
            marksStrList.Remove($"{mark.StudentID},{mark.SubjectName},{mark.MarkValue},{mark.Description}");
            File.WriteAllLines(MARKS_FILE, marksStrList.ToArray());
        }
        public Dictionary<string, Student> GetAllStudent() {
            CheckFileExistence();

            Dictionary<string, Student> students = new Dictionary<string, Student>();
            string[] rStudents = File.ReadAllLines(STUDENT_FILE);
            foreach (var rStudent in rStudents) {
                string[] student = rStudent.Split(',');
                Student newStudent = new Student{
                    ID = student[0],
                    Name = student[1],
                    LastName = student[2],
                    BirthYear = int.Parse(student[3]),
                    Age = int.Parse(student[4])
                };
                students.Add(newStudent.ID, newStudent);
            }

            string[] rMarks = File.ReadAllLines(MARKS_FILE);
            foreach (var rMark in rMarks) {
                string[] mark = rMark.Split(',');
                Mark newMark = new Mark{
                    StudentID = mark[0],
                    SubjectName = mark[1],
                    MarkValue = int.Parse(mark[2]),
                    Description = mark[3]
                };
                students[newMark.StudentID].AddMark(newMark);
            }

            return students;
        }
    }
}