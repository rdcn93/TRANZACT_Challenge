using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranzactChallenge.Application.ViewModels;
using TranzactChallenge.Core.Entities;
using TranzactChallenge.Core.Interfaces;

namespace TranzactChallenge.Application.Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "StateService" en el código y en el archivo de configuración a la vez.
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;
        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task<List<StateViewModel>> GetStatesAll()
        {
            var states = await _stateRepository.GetStatesAll();

            var statesM = states
                .Select(u => new StateViewModel(u))
                .ToList();

            return statesM;
        }
    }
}
