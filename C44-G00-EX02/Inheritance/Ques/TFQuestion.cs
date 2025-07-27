using C44_G00_EX02.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G00_EX02.Inheritance.Ques
{
    internal class TFQuestion : Question
    {
        public override void DisplayQuestion()
        {
            Console.WriteLine($"{Header} \n {Body} ({Mark} Mark)");
            Console.WriteLine("Choose 1 for True, 2 for False.");
          
        }

    }
}
