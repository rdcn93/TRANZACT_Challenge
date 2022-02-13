using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranzactChallenge.Core.Entities;
using TranzactChallenge.Core.Interfaces;
using TranzactChallenge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Dynamic;

namespace TranzactChallenge.Infrastructure.Repository
{
    public class PremiumRepository : IPremiumRepository
    {
        private readonly PremiumContext _context;

        public PremiumRepository(PremiumContext context)
        {
            _context = context;
        }

        public async Task<List<Premium>> GetPremiums(PostFilter filter)
        {
            List<Premium> premiums = new List<Premium>();

            //premiums.Add(new Premium { id = 2323, Carrier = "", Age = "", MonthOfBirth = "SDSDS", State = "SDSDS", PremiumAmount = (decimal)3999.3, Plan = "SDSDS" });

            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@MonthOfBirth", filter.MonthOfBirth));
            parameter.Add(new SqlParameter("@State", filter.State));
            parameter.Add(new SqlParameter("@Age", filter.Age));
            parameter.Add(new SqlParameter("@Plan", filter.Plan));
            parameter.Add(new SqlParameter("@Period", filter.Period));

            var result = await Task.Run(() => _context.premiums.FromSqlRaw(@"exec dbo.GetPremiers @MonthOfBirth, @State, @Age, @Plan, @Period",
                                                              parameter.ToArray()
                                                              ));

            foreach (var r in result)
            {
                premiums.Add(new Premium { 
                    id = r.id,
                    State = r.State,
                    MonthOfBirth = r.MonthOfBirth,
                    Age = r.Age,
                    Carrier = r.Carrier,
                    PremiumAmount = r.PremiumAmount,
                    Plan = r.Plan,
                    Annual = r.Annual,
                    Monthly = r.Monthly
                });
            }

            return premiums;
        }
    }
}
