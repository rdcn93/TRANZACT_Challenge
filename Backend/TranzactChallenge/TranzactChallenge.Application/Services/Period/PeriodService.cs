using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TranzactChallenge.Application.ViewModels;
using TranzactChallenge.Core.Interfaces;

namespace TranzactChallenge.Application.Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "PeriodService" en el código y en el archivo de configuración a la vez.
    public class PeriodService : IPeriodService
    {
        private readonly IPeriodRepository _periodRepository;
        public PeriodService(IPeriodRepository periodRepository)
        {
            _periodRepository = periodRepository;
        }

        public async Task<List<PeriodViewModel>> GetPeriodsAll()
        {
            var states = await _periodRepository.GetPeriodsAll();

            var statesM = states
                .Select(u => new PeriodViewModel(u))
                .ToList();

            return statesM;
        }
    }
}
