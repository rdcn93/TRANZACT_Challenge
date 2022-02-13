
namespace TranzactChallenge.Core.Entities
{
    public class Premium
    {
        public int id { get; set; }
        public string Carrier { get; set; }
        public string Plan { get; set; }
        public string State { get; set; }
        public string MonthOfBirth { get; set; }
        public string Age { get; set; }
        public decimal PremiumAmount { get; set; }
        public decimal Annual { get; set; }
        public decimal Monthly { get; set; }
    }
}
