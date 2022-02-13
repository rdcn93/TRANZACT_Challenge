using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranzactChallenge.Core.Entities
{
    public class PostFilter
    {
        public string DateOfBirth { get; set; }
        public string MonthOfBirth { get; set; }
        public string State { get; set; }
        public int Age { get; set; }
        public string Plan { get; set; }
        public string Period { get; set; }

        public PostFilter()
        {
            MonthOfBirth = "";
            State = "";
            Age = 0;
            Plan = "";
            Period = "";
        }
    }
}
