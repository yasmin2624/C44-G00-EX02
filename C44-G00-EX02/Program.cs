using C44_G00_EX02.Abstract;
using C44_G00_EX02.Aggregation;
using C44_G00_EX02.Association;
using C44_G00_EX02.Inheritance.Exam;
using C44_G00_EX02.Inheritance.Ques;

namespace C44_G00_EX02
{
    internal class Program
    {
        private static int mark;

        static void Main(string[] args)
        {

            #region part01 

            int examType;
            do
            {
                Console.WriteLine("Choose Exam Type:\nEnter [ 1 ] for Practical Exam --- [ 2 ] for Final Exam");
            }
            while (!int.TryParse(Console.ReadLine(), out examType) || (examType != 1 && examType != 2));

            int Time;
            do
            {
                Console.Write("Enter exam Time in minutes (30 to 180): ");
            } while (!int.TryParse(Console.ReadLine(), out Time) || Time < 30 || Time > 180);

            int numberOfQuestions;
            do
            {
                Console.Write("Enter number of questions: ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfQuestions) || numberOfQuestions <= 0);

            Question[] questions = new Question[numberOfQuestions];
            #endregion

            #region part02  

            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.Clear();
                Console.WriteLine($"Entering Question {i + 1}:");

                Question question;

                if (examType == 1)  // Practical : MCQ 
                {
                    question = new MCQQuestion();
                    Console.WriteLine("MCQ Question");
                }
                else  // Final :choose question type [ MCQ , T&F]
                {
                    Console.WriteLine("Choose Question Type:");
                    Console.WriteLine("1. MCQ");
                    Console.WriteLine("2. True/False");

                    int Type;
                    while (!int.TryParse(Console.ReadLine(), out Type) || (Type != 1 && Type != 2))
                    {
                        Console.WriteLine("Invalid input. Enter 1 for MCQ or 2 for True/False.");
                    }
                    if (Type == 1)
                    {
                        question = new MCQQuestion();
                    }
                    else
                    {
                        question = new TFQuestion();
                    }
                }
                // body of question , mark
                Console.Write("Please Enter Question Body: ");
                question.Body = Console.ReadLine();

                int inputMark;
                Console.Write("Please Enter Question Mark: ");
                while (!int.TryParse(Console.ReadLine(), out  inputMark))
                {
                    Console.Write("Invalid mark. Try again: ");
                }
                question.Mark = inputMark;

                // Answers

                if (question is MCQQuestion)
                {
                    question.Answers = new Answer[4];

                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write($"Please Enter Choice number {j + 1}: ");
                        question.Answers[j] = new Answer
                        {
                            AnswerId = j + 1,
                            AnswerText = Console.ReadLine()
                        };
                    }

                    Console.Write("Please Enter the right answer id (1-4): ");
                    int correctId;
                    while (!int.TryParse(Console.ReadLine(), out correctId) || correctId < 1 || correctId > 4)
                    {
                        Console.Write("Invalid ID. Try again: ");
                    }

                    question.CorrectAnswer = question.Answers[correctId - 1];


                }
                else if (question is TFQuestion)
                {
                    question.Answers = new Answer[2];
                    question.Answers[0] = new Answer { AnswerId = 1, AnswerText = "True" };
                    question.Answers[1] = new Answer { AnswerId = 2, AnswerText = "False" };
                    Console.Write("Please Enter the right answer id (1-2): ");
                    int correctId;
                    while (!int.TryParse(Console.ReadLine(), out correctId) || correctId < 1 || correctId > 2)
                    {
                        Console.Write("Invalid ID. Try again: ");
                    }
                    question.CorrectAnswer = question.Answers[correctId - 1];
                }

                questions[i] = question;

            }


            #endregion

            #region part03 
            Exams exam;

            if (examType == 1)
                exam = new Practical();
            else
                exam = new FinalExam();

            exam.Time = Time;
            exam.NumberOfQuestions = numberOfQuestions;
            exam.Questions = questions;

            Subject subject = new Subject();

            int subjectId;
            Console.Write("Enter Subject ID: ");
            while (!int.TryParse(Console.ReadLine(), out subjectId))
            {
                Console.Write("Invalid input. Please enter a valid Subject ID: ");
            }
            subject.Id = subjectId;


            Console.Write("Enter Subject Name: ");
            subject.Name = Console.ReadLine();

            //Every Exam object is Associated to a Subject
            subject.CreateExam(exam);

            #endregion

            #region part04
            Console.Clear();

            Console.Write("Do you want to start the exam now? (y/n): ");
            string start = Console.ReadLine().ToLower();
            Console.Clear();
            if (start == "y")
            {
                exam.ShowExam();
                Console.WriteLine(subject.ToString());
                Console.WriteLine("Thank you ");
            }
            else
            {
                Console.WriteLine("Exam canceled.");
            }
            

            #endregion

          
        }
    }
}
