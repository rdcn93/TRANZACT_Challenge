using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranzactChallenge.Core.Entities;

namespace TranzactChallenge.Core.Interfaces
{
    public interface IPlanRepository
    {
        Task<List<Plan>> GetPlansAll();
    }
}
