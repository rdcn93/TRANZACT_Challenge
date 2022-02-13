using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TranzactChallenge.Application.ViewModels;

namespace TranzactChallenge.Application.Services
{
    
    public interface IPlanService
    {
        Task<List<PlanViewModel>> GetPlansAll();
    }
}
