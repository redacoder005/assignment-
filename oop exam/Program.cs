namespace oop_exam
{

    using System;

    class Answer
    {
        public int AnswerId;
        public string AnswerText;

        public Answer(int id, string text)
        {
            AnswerId = id;
            AnswerText = text;
        }

        public override string ToString()
        {
            return AnswerId + ". " + AnswerText;
        }
    }

    abstract class Question : ICloneable, IComparable<Question>
    {
        public string Header;
        public string Body;
        public int Mark;
        public Answer[] Answers;
        public Answer RightAnswer;
        public int SelectedAnswerId;

        public Question(string header, string body, int mark, Answer[] answers, Answer rightAnswer)
        {
            Header = header;
            Body = body;
            Mark = mark;
            Answers = answers;
            RightAnswer = rightAnswer;
            SelectedAnswerId = 0;
        }

        public abstract void Show();

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int CompareTo(Question other)
        {
            if (other == null)
            {
                return 1;
            }

            return Mark.CompareTo(other.Mark);
        }

        public override string ToString()
        {
            return Header + ": " + Body + " (Mark: " + Mark + ")";
        }
    }

    class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, string body, int mark, Answer[] answers, Answer rightAnswer)
            : base(header, body, mark, answers, rightAnswer)
        {
        }

        public override void Show()
        {
            Console.WriteLine(ToString());

            foreach (Answer answer in Answers)
            {
                Console.WriteLine(answer);
            }
        }
    }

    class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, int mark, Answer[] answers, Answer rightAnswer)
            : base(header, body, mark, answers, rightAnswer)
        {
        }

        public override void Show()
        {
            Console.WriteLine(ToString());

            foreach (Answer answer in Answers)
            {
                Console.WriteLine(answer);
            }
        }
    }

    abstract class Exam
    {
        public int Time;
        public int NumberOfQuestions;
        public Question[] Questions;

        public Exam(int time, Question[] questions)
        {
            Time = time;
            Questions = questions;
            NumberOfQuestions = questions.Length;
        }

        public abstract void Show();
    }

    class FinalExam : Exam
    {
        public FinalExam(int time, Question[] questions)
            : base(time, questions)
        {
        }

        public override void Show()
        {
            int grade = 0;
            int totalMark = 0;

            Console.WriteLine("Final Exam");
            Console.WriteLine("Time: " + Time + " minutes");
            Console.WriteLine("Number of Questions: " + NumberOfQuestions);
            Console.WriteLine();

            foreach (Question question in Questions)
            {
                question.Show();

                totalMark += question.Mark;

                if (question.SelectedAnswerId == question.RightAnswer.AnswerId)
                {
                    grade += question.Mark;
                }

                Console.WriteLine();
            }

            Console.WriteLine("Your Grade: " + grade + " / " + totalMark);
        }
    }

    class PracticalExam : Exam
    {
        public PracticalExam(int time, Question[] questions)
            : base(time, questions)
        {
        }

        public override void Show()
        {
            Console.WriteLine("Practical Exam");
            Console.WriteLine("Time: " + Time + " minutes");
            Console.WriteLine("Number of Questions: " + NumberOfQuestions);
            Console.WriteLine();

            foreach (Question question in Questions)
            {
                question.Show();
                Console.WriteLine();
            }

            Console.WriteLine("Exam Finished!");
            Console.WriteLine("Right Answers:");

            foreach (Question question in Questions)
            {
                Console.WriteLine(question.Header + ": " + question.RightAnswer.AnswerText);
            }
        }
    }

    class Subject
    {
        public int SubjectId;
        public string SubjectName;
        public Exam Exam;

        public Subject(int id, string name)
        {
            SubjectId = id;
            SubjectName = name;
        }

        public void CreateFinalExam(int time, Question[] questions)
        {
            Exam = new FinalExam(time, questions);
        }

        public void CreatePracticalExam(int time, Question[] questions)
        {
            Exam = new PracticalExam(time, questions);
        }

        public void ShowExam()
        {
            if (Exam != null)
            {
                Console.WriteLine("Subject: " + SubjectName);
                Exam.Show();
            }
            else
            {
                Console.WriteLine("No Exam Created");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Answer[] answers1 =
            {
            new Answer(1, "True"),
            new Answer(2, "False")
        };

            Answer[] answers2 =
            {
            new Answer(1, "C#"),
            new Answer(2, "HTML"),
            new Answer(3, "CSS"),
            new Answer(4, "SQL")
        };

            Question question1 = new TrueFalseQuestion(
                "Q1",
                "C# is an object-oriented programming language.",
                2,
                answers1,
                answers1[0]
            );

            Question question2 = new MCQQuestion(
                "Q2",
                "Which language is used with .NET?",
                3,
                answers2,
                answers2[0]
            );

            question1.SelectedAnswerId = 1;
            question2.SelectedAnswerId = 2;

            Question[] questions =
            {
            question1,
            question2
        };

            Subject subject = new Subject(1, "C#");

            subject.CreateFinalExam(60, questions);
            subject.ShowExam();

            Console.WriteLine();
            Console.WriteLine("----------------------");
            Console.WriteLine();

            subject.CreatePracticalExam(30, questions);
            subject.ShowExam();
        }
    }
}
