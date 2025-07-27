using C44_G00_EX02.Inheritance.Ques;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G00_EX02.Inheritance.Exam
{ 
    internal class FinalExam : C44_G00_EX02.Abstract.Exams
    {
        public override void ShowExam()
        {
            int totalGrade = 0;
            int totalMarks = 0;

            Console.WriteLine("--- Final Exam Started ---");
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine($"\nQuestion {i + 1}:");
                Questions[i].DisplayQuestion();

                bool isValidInput;
                int userAnswer;
                int maxChoice = Questions[i] is TFQuestion ? 2 : 4;

                
                do
                {
                    Console.Write($"Enter your answer (1-{maxChoice}): ");
                    isValidInput = int.TryParse(Console.ReadLine(), out userAnswer);
                    if (!isValidInput || userAnswer < 1 || userAnswer > maxChoice)
                    {
                        Console.WriteLine($"Invalid input. Please enter a number between 1 and {maxChoice}.");
                        isValidInput = false;
                    }
                } while (!isValidInput);

                Questions[i].UserAnswerID = userAnswer;
                totalMarks += Questions[i].Mark;


                if (Questions[i].Answers[userAnswer - 1].AnswerText == Questions[i].CorrectAnswer.AnswerText)
                {
                    Console.WriteLine("Correct Answer!");
                    totalGrade += Questions[i].Mark;
                }
                else
                {
                    Console.WriteLine("Wrong Answer!");
                }
            }
            DateTime endTime = DateTime.Now;
            TimeSpan duration = endTime - startTime;

            Console.Clear();
            Console.WriteLine("--- Final Exam Report ---");

            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine($"Question {i + 1}: {Questions[i].Header}");
                Console.WriteLine($"Your Answer: {Questions[i].Answers[Questions[i].UserAnswerID - 1].AnswerText}");
                Console.WriteLine($"Correct Answer: {Questions[i].CorrectAnswer.AnswerText}");
                Console.WriteLine();
            }

            Console.WriteLine($"Your grade is: {totalGrade} from {totalMarks}");
            Console.WriteLine($"You finished in: {duration.Minutes} min {duration.Seconds} sec");
           
        }

    }

}
