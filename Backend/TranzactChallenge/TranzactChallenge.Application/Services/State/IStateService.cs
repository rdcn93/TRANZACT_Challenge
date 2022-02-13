using System.Collections.Generic;
using System.Threading.Tasks;
using TranzactChallenge.Application.ViewModels;

namespace TranzactChallenge.Application.Services
{
    public interface IStateService
    {
        Task<List<StateViewModel>> GetStatesAll();
    }
}
