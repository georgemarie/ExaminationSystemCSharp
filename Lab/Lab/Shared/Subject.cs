using System;
using System.Collections.Generic;
using System.Text;
using Lab.ExamInfo;

namespace Lab.Shared
{
    public class Subject
    {
        private string name;

        public List<Student> EnrolledStudents { get; private set; } = new List<Student>();
        public string Name { get => name; set => name = value; }

        public Subject(string name)
        {
            this.Name = name;
        }

        public void Enroll(Student student)
        {
            EnrolledStudents.Add(student);
        }

        public void NotifyStudents(Exam exam)
        {
            foreach (var student in EnrolledStudents)
            {
                exam.ExamStarted += student.OnExamStarted;
            }
        }
    }
}
