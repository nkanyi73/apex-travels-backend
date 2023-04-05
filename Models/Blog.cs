using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApexTravels.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Author { get; set; } = "Anonymous";
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [Required]
        [Column(TypeName = "text")]
        public string BlogContent { get; set; }

    }
}
