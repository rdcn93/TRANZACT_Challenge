using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranzactChallenge.Core.Entities;

namespace TranzactChallenge.Application.ViewModels
{
    public class PeriodViewModel
    {
        public PeriodViewModel(Period pr)
        {
            id = pr.id;
            Value = pr.Value;
            Text = pr.Text;
            Monthly = pr.Monthly;
            Annual = pr.Annual;
        }

        public int id { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
        public int Monthly { get; set; }
        public int Annual { get; set; }
    }
}
