using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ActividadEvaluableUT8MVC.Models;

namespace ActividadEvaluableUT8MVC.Data
{
    public class ActividadEvaluableUT8MVCContext : DbContext
    {
        public ActividadEvaluableUT8MVCContext (DbContextOptions<ActividadEvaluableUT8MVCContext> options)
            : base(options)
        {
        }

        public DbSet<ActividadEvaluableUT8MVC.Models.Mason> Mason { get; set; }
    }
}
