using System;

namespace Program {
    class Student {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Mark> Marks = new List<Mark>();

        public bool AddMark(Mark mark) {
            Marks.Add(mark);
            Marks = Marks.OrderBy(x => x.SubjectName).ThenBy(x => x.MarkValue).ToList();

            return true;
        }

        public string WriteMarks() {
            string result = "";
            foreach (var mark in Marks) {
                result += mark.WriteMark() + "\n";
            };
            return result;
        }   
}

    class Mark {
        public string SubjectName { get; set; }
        public string Description { get; set; }
        public int MarkValue { get; set; }

        public string WriteMark() {
            return $"{SubjectName} - {MarkValue} - {Description}";
        }
    }
}