using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ActividadEvaluableUT8RazorPages.Models;

namespace ActividadEvaluableUT8RazorPages.Data
{
    public class ActividadEvaluableUT8RazorPagesContext : DbContext
    {
        public ActividadEvaluableUT8RazorPagesContext (DbContextOptions<ActividadEvaluableUT8RazorPagesContext> options)
            : base(options)
        {
        }

        public DbSet<ActividadEvaluableUT8RazorPages.Models.Creature> Creature { get; set; } = default!;
        public DbSet<ActividadEvaluableUT8RazorPages.Models.Logia> Logia { get; set; } = default!;
        public DbSet<ActividadEvaluableUT8RazorPages.Models.Mason> Mason { get; set; } = default!;
    }
}
