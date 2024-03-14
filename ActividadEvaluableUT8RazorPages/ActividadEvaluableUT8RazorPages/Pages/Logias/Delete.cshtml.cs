using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ActividadEvaluableUT8RazorPages.Data;
using ActividadEvaluableUT8RazorPages.Models;

namespace ActividadEvaluableUT8RazorPages.Pages.Logias
{
    public class DeleteModel : PageModel
    {
        private readonly ActividadEvaluableUT8RazorPages.Data.ActividadEvaluableUT8RazorPagesContext _context;

        public DeleteModel(ActividadEvaluableUT8RazorPages.Data.ActividadEvaluableUT8RazorPagesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Logia Logia { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logia = await _context.Logia.FirstOrDefaultAsync(m => m.logia_id == id);

            if (logia == null)
            {
                return NotFound();
            }
            else
            {
                Logia = logia;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logia = await _context.Logia.FindAsync(id);
            if (logia != null)
            {
                Logia = logia;
                _context.Logia.Remove(Logia);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
