using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranzactChallenge.Core.Entities;
using TranzactChallenge.Core.Interfaces;
using TranzactChallenge.Infrastructure.Data;

namespace TranzactChallenge.Infrastructure.Repository
{
    public class PlanRepository : IPlanRepository
    {
        private readonly PremiumContext _context;

        public PlanRepository(PremiumContext context)
        {
            _context = context;
        }

        public async Task<List<Plan>> GetPlansAll()
        {
            List<Plan> plans = new List<Plan>();

            var dbPlans = await Task.Run(() => _context.plans.ToList());

            foreach (var r in dbPlans)
            {
                plans.Add(new Plan
                {
                    id = r.id,
                    Value = r.Value,
                    Text = r.Text
                });
            }

            return plans;
        }
    }
}
