using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ActividadEvaluableUT8RazorPages.Data;
using ActividadEvaluableUT8RazorPages.Models;

namespace ActividadEvaluableUT8RazorPages.Pages.Creatures
{
    public class CreateModel : PageModel
    {
        private readonly ActividadEvaluableUT8RazorPages.Data.ActividadEvaluableUT8RazorPagesContext _context;

        public CreateModel(ActividadEvaluableUT8RazorPages.Data.ActividadEvaluableUT8RazorPagesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["logia_id"] = new SelectList(_context.Set<Logia>(), "logia_id", "name");
            return Page();
        }

        [BindProperty]
        public Creature Creature { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Creature.Add(Creature);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
