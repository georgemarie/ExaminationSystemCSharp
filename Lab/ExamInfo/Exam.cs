using Lab.QuestionsTypes;
using Lab.Answers;
using Lab.Shared;

namespace Lab.ExamInfo
{
    public delegate void ExamStartedHandler(object sender, ExamEventArgs e);
    public abstract class Exam : ICloneable, IComparable<Exam>
    {
        public event ExamStartedHandler ExamStarted;

        private int time;
        private int numberOfQuestions;

        private List<Question> questions;
        private Dictionary<Question, Answer> questionAnswerDictionary;
        private Subject subject;

        private ExamMode mode;
        public ExamMode Mode
        {
            get => mode;
            set
            {
                mode = value;
                if (mode == ExamMode.Starting)
                {
                    ExamStarted?.Invoke(this, new ExamEventArgs(Subject, this));
                }
            }
        }

        public List<Question> Questions { get => questions; set => questions = value; }
        public Dictionary<Question, Answer> QuestionAnswerDictionary { get => questionAnswerDictionary; set => questionAnswerDictionary = value; }
        public Subject Subject { get => subject; set => subject = value; }
        public int Time { get => time; set => time = value; }
        public int NumberOfQuestions { get => numberOfQuestions; set => numberOfQuestions = value; }

        public Exam(int time, int numberOfQuestions, Subject subject)
        {
            this.Time = time;
            this.NumberOfQuestions = numberOfQuestions;
            Subject = subject;
            Questions = new List<Question>(numberOfQuestions);
            QuestionAnswerDictionary = new Dictionary<Question, Answer>();
            Mode = ExamMode.Queued;
        }

        public abstract void ShowExam();

        public virtual void Start()
        {
            Subject.NotifyStudents(this);
            Mode = ExamMode.Starting;
        }

        public virtual void Finish()
        {
            Mode = ExamMode.Finished;
            CorrectExam();
        }

        protected abstract void CorrectExam();

        public override string ToString() => $"Exam: {Subject.Name}, Time: {Time} mins";

        public override bool Equals(object obj)
        {
            if (obj is Exam e) return Time == e.Time && NumberOfQuestions == e.NumberOfQuestions && Subject.Name == e.Subject.Name;
            return false;
        }

        public override int GetHashCode() => (Time + NumberOfQuestions).GetHashCode();

        public object Clone() => this.MemberwiseClone();

        public int CompareTo(Exam other)
        {
            if (other == null) return 1;
            int timeComparison = Time.CompareTo(other.Time);
            if (timeComparison != 0) return timeComparison;
            return NumberOfQuestions.CompareTo(other.NumberOfQuestions);
        }
    }
}
