using System;
using System.Collections.Generic;
using System.Text;

namespace cslabs
{
    class Test
    {
        public string Subject { get; set; }
        public bool IsPassed { get; set; }

        public Test() : this("None", false) { }
        public Test(string subject, bool isPassed)
        {
            this.Subject = subject;
            this.IsPassed = isPassed;
        }
        public object DeepCopy()
        {
            return (object)new Test(new string(this.Subject), this.IsPassed);
        }
        public override string ToString() => string.Format(this.IsPassed ? "{0}: passed" : "{0}: not passed", this.Subject);


    }
}
