using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranzactChallenge.Core.Entities
{
    public class Period
    {
        public int id { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
        public int Monthly { get; set; }
        public int Annual { get; set; }
    }
}
