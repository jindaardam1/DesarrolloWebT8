using System.ComponentModel.DataAnnotations;

namespace ActividadEvaluableUT8RazorPages.Models
{
    public class Logia
    {
        [Key]
        public int logia_id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [StringLength(255)]
        public string description { get; set; }
    }
}
