using Microsoft.Data.SqlClient;
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
    public class StateRepository : IStateRepository
    {
        private readonly PremiumContext _context;

        public StateRepository(PremiumContext context)
        {
            _context = context;
        }

        public async Task<List<State>> GetStatesAll()
        {
            List<State> states = new List<State>();

            var dbStates = await Task.Run(() => _context.states.ToList());

            foreach (var r in dbStates)
            {
                states.Add(new State
                {
                    id = r.id,
                    Value = r.Value,
                    Text = r.Text
                });
            }

            return states;
        }
    }
}
