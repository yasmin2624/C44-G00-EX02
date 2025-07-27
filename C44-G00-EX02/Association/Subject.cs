using C44_G00_EX02.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C44_G00_EX02.Association
{
    internal class Subject 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Exams Exam { get; set; }

       

        public void CreateExam(Exams exam)
        {
            Exam = exam;
        }

        public override string ToString()
        {
            return $"\nSubject ID: {Id}, Name: {Name}\nExam Time: {Exam.Time} min\nNumber of Questions: {Exam.NumberOfQuestions}\n";
        }

        
    }
}
