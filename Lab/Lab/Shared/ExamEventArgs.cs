using System;
using System.Collections.Generic;
using System.Text;
using Lab.ExamInfo;
using Lab.Shared;

namespace Lab
{
    public class ExamEventArgs : EventArgs
    {
        private Subject subject;
        private Exam exam;

        public ExamEventArgs(Subject subject, Exam exam)
        {
            this.Subject = subject;
            this.Exam = exam;
        }

        public Subject Subject { get => subject; set => subject = value; }
        public Exam Exam { get => exam; set => exam = value; }
    }
}
