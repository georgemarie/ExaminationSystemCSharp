using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{

    public class Student
    {
        private string name;
        private int id;

        public Student(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }

        public void OnExamStarted(object sender, ExamEventArgs e)
        {
            Console.WriteLine($"Notification for {name}: Exam for {e.Subject.Name} has started!");
        }
    }
}
