using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TranzactChallenge.Infrastructure.Models
{
    [Table("tb_plan")]
    public class tb_plan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
    }
}
