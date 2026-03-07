using Lab.Answers;
using Lab.ExamInfo;
using Lab.QuestionsTypes;
using Lab.Shared;
using System;

namespace Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject csharpSubject = new Subject("C# Programming");

            Student s1 = new Student(1, "George");
            Student s2 = new Student(2, "Ebram");
            csharpSubject.Enroll(s1);
            csharpSubject.Enroll(s2);

            PracticeExam practiceExam = new PracticeExam(30, 4, csharpSubject);
            FinalExam finalExam = new FinalExam(60, 4, csharpSubject);

            QuestionList practiceQuestions = new QuestionList("practice_log.txt");
            QuestionList finalQuestions = new QuestionList("final_log.txt");


            TrueFalseQuestion tfQ1 = new TrueFalseQuestion("Q1", "C# is an OOP language.", 5, new Answer(1, "True"));

            ChooseOneQuestion coQ1 = new ChooseOneQuestion("Q2", "Which keyword is used for inheritance in C#?", 10, new Answer(2, "colon"));
            coQ1.Answers.Add(new Answer(1, "extends"));
            coQ1.Answers.Add(new Answer(2, "colon"));
            coQ1.Answers.Add(new Answer(3, "inherits"));

            ChooseAllQuestion caQ1 = new ChooseAllQuestion("Q3", "Which of the following are value types in C#?", 15, new Answer(0, "1,3"));
            caQ1.Answers.Add(new Answer(1, "int"));
            caQ1.Answers.Add(new Answer(2, "string"));
            caQ1.Answers.Add(new Answer(3, "struct"));
            caQ1.Answers.Add(new Answer(4, "class"));

            TrueFalseQuestion tfQ2 = new TrueFalseQuestion("Q4", "Arrays in C# are dynamically sized by default.", 5, new Answer(2, "False"));

            practiceQuestions.Add(tfQ1);
            practiceQuestions.Add(coQ1);
            practiceQuestions.Add(caQ1);
            practiceQuestions.Add(tfQ2);

            finalQuestions.Add(tfQ1);
            finalQuestions.Add(coQ1);
            finalQuestions.Add(caQ1);
            finalQuestions.Add(tfQ2);

            practiceExam.Questions = practiceQuestions;
            finalExam.Questions = finalQuestions;

            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("        EXAMINATION MANAGEMENT SYSTEM             ");
            Console.WriteLine("==================================================");

            Console.WriteLine();
            Console.WriteLine($"Subject: {csharpSubject.Name}");
            Console.WriteLine($"Enrolled Students: {csharpSubject.EnrolledStudents.Count}");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("Select Exam Type:");
            Console.WriteLine("  1 - Practice Exam (Shows correct answers & grade)");
            Console.WriteLine("  2 - Final Exam (Submits silently)");

            Console.Write("\nYour Choice (1 or 2): ");
            string choice = Console.ReadLine() ?? "1";

            Exam selectedExam = choice == "1" ? practiceExam : finalExam;

            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine($"       STARTING {csharpSubject.Name.ToUpper()} EXAM");
            Console.WriteLine("==================================================");
            Console.WriteLine();

            selectedExam.Start();
            Console.WriteLine();

            selectedExam.ShowExam();

            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("                  EXAM FINISHED                   ");
            Console.WriteLine("==================================================");

            selectedExam.Finish();
        }
    }
}