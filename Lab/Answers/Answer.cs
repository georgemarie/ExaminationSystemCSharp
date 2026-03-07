using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.Answers
{
    public class Answer : IComparable<Answer> , ICloneable
    {
        private int id;
        private string text;

        public Answer(int id, string text)
        {
            this.id = id;
            this.text = text;
        }

        public int Id { get => id; set => id = value; }
        public string Text { get => text; set => text = value; }

        public int CompareTo(Answer? other)
        {
           if((other != null) && (other is Answer ans))
            {
                return Id.CompareTo(ans.Id);
            }
           return 0;
        }

        public override bool Equals(object? obj)
        {
            if ((obj is Answer ans) && (ans != null))
            {
                return Id == ans.Id && Text == ans.Text;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Text);
        }

        public override string ToString()
        {
            return $"Answer ID = {Id} , Answer Text = {Text} ";
        }

        object ICloneable.Clone()
        {
            return new Answer(Id, Text);
        }
    }
}
