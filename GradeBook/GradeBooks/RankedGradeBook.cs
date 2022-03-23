using System;
using System.Collections.Generic;
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
    }
}
