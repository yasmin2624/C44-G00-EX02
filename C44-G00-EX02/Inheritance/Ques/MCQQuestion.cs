using C44_G00_EX02.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G00_EX02.Inheritance.Ques
{
    internal class MCQQuestion : Question
    {
        public override void DisplayQuestion()
        {
            Console.WriteLine($"{Header} \n {Body} ({Mark} Mark)");
            for (int i = 0; i < Answers.Length; i++)
            {
                Console.WriteLine($"{i + 1}- {Answers[i].AnswerText}");
            }
        }
    }
}
