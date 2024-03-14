using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActividadEvaluableUT8RazorPages.Data;
using ActividadEvaluableUT8RazorPages.Models;

namespace ActividadEvaluableUT8RazorPages.Pages.Creatures
{
    public class DeleteModel : PageModel
    {
        private readonly ActividadEvaluableUT8RazorPages.Data.ActividadEvaluableUT8RazorPagesContext _context;

        public DeleteModel(ActividadEvaluableUT8RazorPages.Data.ActividadEvaluableUT8RazorPagesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Creature Creature { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creature = await _context.Creature.FirstOrDefaultAsync(m => m.creature_id == id);

            if (creature == null)
            {
                return NotFound();
            }
            else
            {
                Creature = creature;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creature = await _context.Creature.FindAsync(id);
            if (creature != null)
            {
                Creature = creature;
                _context.Creature.Remove(Creature);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
