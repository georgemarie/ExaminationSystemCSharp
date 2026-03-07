using Lab.Answers;
using Lab.QuestionsTypes;
using Lab.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.ExamInfo
{
    public class FinalExam : Exam
    {
        public FinalExam(int time, int numberOfQuestions, Subject subject)
            : base(time, numberOfQuestions, subject) { }

        public override void ShowExam()
        {
            for (int i = 0; i < Questions.Count; i++)
            {
                if (Questions[i] != null)
                {
                    Questions[i].Display();
                    Console.Write("Enter Answer ID(s) [comma separated for multiple]: ");
                    string ansText = Console.ReadLine() ?? "";

                    if (Questions[i] is ChooseAllQuestion)
                    {
                        QuestionAnswerDictionary[Questions[i]] = new Answer(0, ansText);
                    }
                    else
                    {
                        if (int.TryParse(ansText.Trim(), out int ansId))
                        {
                            Answer selectedAnswer = Questions[i].Answers.GetById(ansId);

                            QuestionAnswerDictionary[Questions[i]] = selectedAnswer ?? new Answer(0, ansText);
                        }
                        else
                        {
                            QuestionAnswerDictionary[Questions[i]] = new Answer(0, ansText);
                        }
                    }
                }
            }
        }

        protected override void CorrectExam()
        {
            int score = 0;
            int totalMarks = 0;
            Console.WriteLine("\n--- Final Exam Submitted ---");
            foreach (var kvp in QuestionAnswerDictionary)
            {
                if (kvp.Key.CheckAnswer(kvp.Value)) score += kvp.Key.Marks;
                totalMarks += kvp.Key.Marks;

                Console.WriteLine($"Q: {kvp.Key.Head}");
                Console.WriteLine($"Your Answer: {kvp.Value.Text}");
            }
        }
    }
}
