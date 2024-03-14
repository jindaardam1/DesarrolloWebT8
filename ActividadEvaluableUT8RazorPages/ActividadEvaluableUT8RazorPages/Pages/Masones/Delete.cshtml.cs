using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActividadEvaluableUT8RazorPages.Data;
using ActividadEvaluableUT8RazorPages.Models;

namespace ActividadEvaluableUT8RazorPages.Pages.Masones
{
    public class DeleteModel : PageModel
    {
        private readonly ActividadEvaluableUT8RazorPages.Data.ActividadEvaluableUT8RazorPagesContext _context;

        public DeleteModel(ActividadEvaluableUT8RazorPages.Data.ActividadEvaluableUT8RazorPagesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mason Mason { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mason = await _context.Mason.FirstOrDefaultAsync(m => m.masone_id == id);

            if (mason == null)
            {
                return NotFound();
            }
            else
            {
                Mason = mason;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mason = await _context.Mason.FindAsync(id);
            if (mason != null)
            {
                Mason = mason;
                _context.Mason.Remove(Mason);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
