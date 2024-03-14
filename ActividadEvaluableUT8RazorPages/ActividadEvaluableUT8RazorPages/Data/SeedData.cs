using ActividadEvaluableUT8RazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace ActividadEvaluableUT8RazorPages.Data
{
    public static class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ActividadEvaluableUT8RazorPagesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ActividadEvaluableUT8RazorPagesContext>>()))
            {
                if (context.Creature.Any())
                {
                    return;
                }

                context.Creature.AddRange(
                    new Creature
                    {
                        name = "creature1",
                        description = "La creature 1",
                        logia_id = 1
                    },

                    new Creature
                    {
                        name = "creature2",
                        description = "La creature 2",
                        logia_id = 2
                    },

                    new Creature
                    {
                        name = "creature3",
                        description = "La creature 3",
                        logia_id = 3
                    },

                    new Creature
                    {
                        name = "creature4",
                        description = "La creature 4",
                        logia_id = 4
                    }
                );

                context.Logia.AddRange(
                    new Logia
                    {
                        name = "logia1",
                        description = "La logia 1"
                    },

                    new Logia
                    {
                        name = "logia2",
                        description = "La logia 2"
                    },

                    new Logia
                    {
                        name = "logia3",
                        description = "La logia 3"
                    },

                    new Logia
                    {
                        name = "logia4",
                        description = "La logia 4"
                    }
                );

                context.SaveChanges();
            }
        }

    }
}
