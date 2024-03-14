using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ActividadEvaluableUT8MVC.Models
{
    [Table("logias")]
    public class Logia
    {
        [Key]
        [Column("logia_id")]
        public int LogiaId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        public virtual ICollection<Creature> Creatures { get; set; }
        public virtual ICollection<Mason> Masones { get; set; }
    }

    [Table("creatures")]
    public class Creature
    {
        [Key]
        [Column("creature_id")]
        public int CreatureId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("logia_id")]
        public int LogiaId { get; set; }

        [ForeignKey("LogiaId")]
        public virtual Logia Logia { get; set; }
    }

    [Table("masones")]
    public class Mason
    {
        [Key]
        [Column("masone_id")]
        public int MasonId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("logia_id")]
        public int LogiaId { get; set; }

        [ForeignKey("LogiaId")]
        public virtual Logia Logia { get; set; }
    }
}
