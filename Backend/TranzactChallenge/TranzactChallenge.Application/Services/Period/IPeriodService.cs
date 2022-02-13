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
    // NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IPeriodService" en el código y en el archivo de configuración a la vez.
    public interface IPeriodService
    {
        Task<List<PeriodViewModel>> GetPeriodsAll();
    }
}
