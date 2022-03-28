using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool IsWeighted) : base(name, IsWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }



        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else if (Students.Count >= 5)
            {
                base.CalculateStatistics();
            }
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires more students at least 5");
            }
            var DropLetter = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();
            if (grades[DropLetter - 1] <= averageGrade)
            {
                return 'A';
            }
            else if (grades[(DropLetter * 2) - 1] <= averageGrade)
            {
                return 'B';
            }
            else if (grades[(DropLetter * 3) - 1] <= averageGrade)
            {
                return 'C';
            }
            else if (grades[(DropLetter * 4) - 1] <= averageGrade)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        

        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
