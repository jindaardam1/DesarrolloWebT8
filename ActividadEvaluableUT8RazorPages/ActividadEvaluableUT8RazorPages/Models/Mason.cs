using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActividadEvaluableUT8RazorPages.Models
{
    public class Mason
    {
        [Key]
        public int masone_id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public int logia_id { get; set; }

        [ForeignKey("logia_id")]
        public Logia Logia { get; set; }
    }
}
