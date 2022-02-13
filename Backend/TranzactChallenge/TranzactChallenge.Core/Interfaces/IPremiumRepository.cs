using System.Collections.Generic;
using System.Threading.Tasks;
using TranzactChallenge.Core.Entities;

namespace TranzactChallenge.Core.Interfaces
{
    public interface IPremiumRepository
    {
        Task<List<Premium>> GetPremiums(PostFilter filter);
    }
}
