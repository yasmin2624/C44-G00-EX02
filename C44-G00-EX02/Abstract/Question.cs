using C44_G00_EX02.Aggregation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G00_EX02.Abstract
{
    internal abstract class Question
    {
        internal int UserAnswerID;

        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[] Answers { get; set; }
        public Answer CorrectAnswer { get; set; }

        public abstract void DisplayQuestion();

    }
}
