using C44_G00_EX02.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G00_EX02.Inheritance.Exam
{
    internal class Practical : C44_G00_EX02.Abstract.Exams
    {
        static int TotalGrade = 0;
       
        int userAnswer;
        public override void ShowExam()
        {
            int TotalMarks = 0;
            Console.WriteLine("--- Practical Exam Started ---");
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < Questions.Length; i++)
            {
                

                Console.WriteLine($"\nQuestion {i + 1} :");
                Questions[i].DisplayQuestion();

                
                bool isValidInput;

                do
                {
                    Console.Write("Enter your answer (1-4): ");
                    isValidInput = int.TryParse(Console.ReadLine(), out userAnswer);
                    if (!isValidInput || userAnswer < 1 || userAnswer > 4)
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                        isValidInput = false;

                    }
                }
                while (!isValidInput);

                Questions[i].UserAnswerID = userAnswer;
                TotalMarks += Questions[i].Mark;

                if (Questions[i].Answers[userAnswer - 1].AnswerText == Questions[i].CorrectAnswer.AnswerText)
                {
                    Console.WriteLine("Correct Answer!");
                    TotalGrade += Questions[i].Mark;
                }
                else
                {
                    Console.WriteLine("Wrong Answer!");
                }

                
            }
             DateTime endTime = DateTime.Now;
            TimeSpan duration = endTime - startTime;

            Console.Clear();
            Console.WriteLine("--- Report of Practical Exam ---");

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.WriteLine($"Question {i + 1}: {Questions[i].Header}");
                Console.WriteLine($"Correct Answer: {Questions[i].CorrectAnswer.AnswerText}\n");
            }

            Console.WriteLine($"You Answered  {TotalGrade} Qes from {TotalMarks}");
           Console.WriteLine($"You finished in: {duration.Minutes} min {duration.Seconds} sec");
              
        }
    }
}
