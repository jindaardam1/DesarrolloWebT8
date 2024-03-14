using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActividadEvaluableUT8RazorPages.Models
{
    public class Creature
    {
        [Key]
        public int creature_id { get; set; }

        [Required]
        [StringLength(100)]
        public required string name { get; set; }

        [StringLength(255)]
        public required string description { get; set; }

        public int logia_id { get; set; }

        [ForeignKey("logia_id")]
        public required Logia Logia { get; set; }
    }
}
