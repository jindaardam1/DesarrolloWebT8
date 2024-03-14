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

namespace ActividadEvaluableUT8RazorPages.Pages.Logias
{
    public class EditModel : PageModel
    {
        private readonly ActividadEvaluableUT8RazorPages.Data.ActividadEvaluableUT8RazorPagesContext _context;

        public EditModel(ActividadEvaluableUT8RazorPages.Data.ActividadEvaluableUT8RazorPagesContext context)
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

            var logia =  await _context.Logia.FirstOrDefaultAsync(m => m.logia_id == id);
            if (logia == null)
            {
                return NotFound();
            }
            Logia = logia;
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

            _context.Attach(Logia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogiaExists(Logia.logia_id))
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

        private bool LogiaExists(int id)
        {
            return _context.Logia.Any(e => e.logia_id == id);
        }
    }
}
