using Lab.Answers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.QuestionsTypes
{
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, string body, int marks, Answer correctAnswer)
            : base(header, body, marks, correctAnswer)
        {
            Answers.Add(new Answer(1, "True"));
            Answers.Add(new Answer(2, "False"));
        }

        public override void Display()
        {
            Console.WriteLine($"[True/False] {ToString()}");
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
