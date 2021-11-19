using System;
using System.Collections.Generic;
using System.Text;

namespace cslabs
{
    interface IDateAndCopy
    {
        object DeepCopy();

        DateTime Date { get; set; }
    }
}
