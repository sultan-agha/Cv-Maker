using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dotnet;

namespace Taghelpers.Pages.SP
{
    public class EditModel : PageModel
    {
        private readonly dotnet.DatabaseCV _context;

        public EditModel(dotnet.DatabaseCV context)
        {
            _context = context;
        }

        [BindProperty]
        public CV_Info CV_Info { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CVS == null)
            {
                return NotFound();
            }

            var cv_info =  await _context.CVS.FirstOrDefaultAsync(m => m.Id == id);
            if (cv_info == null)
            {
                return NotFound();
            }
            CV_Info = cv_info;
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

            _context.Attach(CV_Info).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CV_InfoExists(CV_Info.Id))
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

        private bool CV_InfoExists(int id)
        {
          return (_context.CVS?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
