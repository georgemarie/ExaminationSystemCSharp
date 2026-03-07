using Lab.Answers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.QuestionsTypes
{
    public abstract class Question
    {
        private string head;
        private string body;
        private int marks;
        private AnswerList answers;
        private Answer correctAnswer;

        protected Question(string head, string body, int marks, Answer correctAnswer)
        {
            this.head = head;
            this.body = body;
            this.marks = marks;
            this.correctAnswer = correctAnswer;
            Answers = new AnswerList();
        }

        public string Head { get => head; set => head = value; }
        public string Body { get => body; set => body = value; }
        public int Marks { get => marks; set => marks = value; }
        public AnswerList Answers { get => answers; set => answers = value; }
        public Answer CorrectAnswer { get => correctAnswer; set => correctAnswer = value; }

        public abstract void Display();

        public abstract bool CheckAnswer(Answer studentAnswer);

        public override string ToString()
        {
            return $"{Head}\n{Body}\nMarks: {Marks}";
        }

        public override bool Equals(object? obj)
        {
            if((obj is Question question) &&(question != null))
            {
                return head == question.Head && body == question.Body;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(head, body);
        }
    }
}
