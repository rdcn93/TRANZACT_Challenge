
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TranzactChallenge.Infrastructure.Models
{
    [Table("tb_premium")]
    public class tb_premium
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
