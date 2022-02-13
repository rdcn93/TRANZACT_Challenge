
using TranzactChallenge.Core.Entities;

namespace TranzactChallenge.Application.ViewModels
{
    public class PremiumViewModel
    {
        public PremiumViewModel(Premium pr)
        {
            Carrier = pr.Carrier;
            PremiumAmount = pr.PremiumAmount;
        }

        public string Carrier { get; set; }
        public decimal PremiumAmount { get; set; }
    }
}
