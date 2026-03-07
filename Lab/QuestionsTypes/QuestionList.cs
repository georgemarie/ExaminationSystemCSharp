using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab.QuestionsTypes
{
    public class QuestionList : List<Question>
    {
        private readonly string _fileName;

        public QuestionList(string fileName)
        {
            _fileName = fileName;
        }

        public QuestionList() { }

        public new void Add(Question question)
        {
            base.Add(question);

            using (StreamWriter writer = new StreamWriter(_fileName, append: true))
            {
                writer.WriteLine("--- Logged Question Details ---");
                writer.WriteLine($"Type: {question.GetType().Name}");
                writer.WriteLine($"Header: {question.Head}");
                writer.WriteLine($"Body: {question.Body}");
                writer.WriteLine($"Marks: {question.Marks}");
                writer.WriteLine("-------------------------------");
            }
        }
    }
}
