using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ActividadEvaluableUT8RazorPages.Data;
using ActividadEvaluableUT8RazorPages.Models;

namespace ActividadEvaluableUT8RazorPages.Pages.Masones
{
    public class EditModel : PageModel
    {
        private readonly ActividadEvaluableUT8RazorPages.Data.ActividadEvaluableUT8RazorPagesContext _context;

        public EditModel(ActividadEvaluableUT8RazorPages.Data.ActividadEvaluableUT8RazorPagesContext context)
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

            var mason =  await _context.Mason.FirstOrDefaultAsync(m => m.masone_id == id);
            if (mason == null)
            {
                return NotFound();
            }
            Mason = mason;
           ViewData["logia_id"] = new SelectList(_context.Logia, "logia_id", "name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Mason).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasonExists(Mason.masone_id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MasonExists(int id)
        {
            return _context.Mason.Any(e => e.masone_id == id);
        }
    }
}
