using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranzactChallenge.Core.Entities;

namespace TranzactChallenge.Application.ViewModels
{
    public class PlanViewModel
    {
        public PlanViewModel(Plan pr)
        {
            id = pr.id;
            Value = pr.Value;
            Text = pr.Text;
        }

        public int id { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
    }
}
