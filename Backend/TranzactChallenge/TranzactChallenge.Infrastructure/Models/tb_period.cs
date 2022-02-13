using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TranzactChallenge.Infrastructure.Models
{
    [Table("tb_period")]
    public class tb_period
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
        public int Monthly { get; set; }
        public int Annual { get; set; }
    }
}
