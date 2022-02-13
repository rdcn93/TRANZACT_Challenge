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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "PlanService" en el código y en el archivo de configuración a la vez.
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _planRepository;
        public PlanService(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<List<PlanViewModel>> GetPlansAll()
        {
            var states = await _planRepository.GetPlansAll();

            var statesM = states
                .Select(u => new PlanViewModel(u))
                .ToList();

            return statesM;
        }
    }
}
