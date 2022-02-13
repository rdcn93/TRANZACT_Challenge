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
    public class PeriodRepository : IPeriodRepository
    {
        private readonly PremiumContext _context;

        public PeriodRepository(PremiumContext context)
        {
            _context = context;
        }

        public async Task<List<Period>> GetPeriodsAll()
        {
            List<Period> periods = new List<Period>();

            var dbPeriods = await Task.Run(() => _context.periods.ToList());

            foreach (var r in dbPeriods)
            {
                periods.Add(new Period
                {
                    id = r.id,
                    Value = r.Value,
                    Text = r.Text,
                    Monthly = r.Monthly,
                    Annual = r.Annual
                });
            }

            return periods;
        }
    }

}
