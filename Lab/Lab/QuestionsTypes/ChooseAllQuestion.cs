using Lab.Answers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.QuestionsTypes
{
    public class ChooseAllQuestion : Question
    {
        public ChooseAllQuestion(string header, string body, int marks, Answer correctAnswer)
            : base(header, body, marks, correctAnswer) { }

        public override void Display()
        {
            Console.WriteLine($"[Choose All That Apply] {ToString()}");
            for (int i = 0; i < Answers.Count; i++)
            { 
                Console.WriteLine(Answers[i]); 
            }
        }

        public override bool CheckAnswer(Answer studentAnswer)
        {
            if (studentAnswer == null || CorrectAnswer == null) return false;
            string[] correctIds = CorrectAnswer.Text.Split(',');
            string[] studentIds = studentAnswer.Text.Split(',');

            if (correctIds.Length != studentIds.Length) return false;

            Array.Sort(correctIds);
            Array.Sort(studentIds);

            for (int i = 0; i < correctIds.Length; i++)
            {
                if (correctIds[i].Trim() != studentIds[i].Trim()) return false;
            }
            return true;
        }
    }
}
