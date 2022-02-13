using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TranzactChallenge.Application.ViewModels;
using TranzactChallenge.Core.Entities;

namespace TranzactChallenge.Application.Services
{
    public interface IPremiumService
    {
        Task<List<PremiumViewModel>> GetPremiums(PostFilter filter);
    }
}
