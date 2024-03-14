using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ActividadEvaluableUT8RazorPages.Models
{
    public class Tablas
    {
        [Table("logias")]
        public class Logia
        {
            [Key]
            [Column("logia_id")]
            public int LogiaId { get; set; }

            [Column("name")]
            public required string Name { get; set; }

            [Column("description")]
            public required string Description { get; set; }

            public virtual required ICollection<Creature> Creatures { get; set; }
            public virtual required ICollection<Mason> Masones { get; set; }
        }

        [Table("creatures")]
        public class Creature
        {
            [Key]
            [Column("creature_id")]
            public int CreatureId { get; set; }

            [Column("name")]
            public required string Name { get; set; }

            [Column("description")]
            public required string Description { get; set; }

            [Column("logia_id")]
            public int LogiaId { get; set; }

            [ForeignKey("LogiaId")]
            public virtual required Logia Logia { get; set; }
        }

        [Table("masones")]
        public class Mason
        {
            [Key]
            [Column("masone_id")]
            public int MasonId { get; set; }

            [Column("name")]
            public required string Name { get; set; }

            [Column("description")]
            public required string Description { get; set; }

            [Column("logia_id")]
            public int LogiaId { get; set; }

            [ForeignKey("LogiaId")]
            public virtual required Logia Logia { get; set; }
        }
    }
}
