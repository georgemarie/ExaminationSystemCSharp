using Lab.Answers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.QuestionsTypes
{
    public class ChooseOneQuestion : Question
    {
        public ChooseOneQuestion(string header, string body, int marks, Answer correctAnswer)
            : base(header, body, marks, correctAnswer) { }

        public override void Display()
        {
            Console.WriteLine($"[Choose One] {ToString()}");
            for (int i = 0; i < Answers.Count; i++)
            { 
                Console.WriteLine(Answers[i]); 
            }
        }

        public override bool CheckAnswer(Answer studentAnswer)
        {
            return CorrectAnswer.Equals(studentAnswer);
        }
    }
}
