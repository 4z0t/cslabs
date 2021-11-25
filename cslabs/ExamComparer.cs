using System;
using System.Collections.Generic;
using System.Text;

namespace cslabs
{
    class ExamComparer: IComparer<Exam>
    {
        public int Compare(Exam ex1, Exam ex2)
        {
            return ex1.Date.CompareTo(ex2.Date);
        }

    }
}
