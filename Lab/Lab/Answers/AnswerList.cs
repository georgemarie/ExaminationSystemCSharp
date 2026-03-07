using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Answers
{
    public class AnswerList
    {
        private List<Answer> answers = new List<Answer>();
        public int Count => Answers.Count;

        public List<Answer> Answers { get => answers; set => answers = value; }

        public void Add(Answer answer)
        {
            if (answer != null)
            {
                Answers.Add(answer);
            }
        }

        public Answer GetById(int id)
        {
            foreach (var ans in Answers)
            {
                if (ans.Id == id)
                { 
                    return ans; 
                }
            }
            return null;
        }

        public Answer this[int index]
        {
            get 
            { 
                return Answers[index]; 
            }

            set
            {
                Answers[index] = value;
            }
        }
    }
}
