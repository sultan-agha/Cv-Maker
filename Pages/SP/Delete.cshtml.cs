using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dotnet;

namespace Taghelpers.Pages.SP
{
    public class DeleteModel : PageModel
    {
        private readonly dotnet.DatabaseCV _context;

        public DeleteModel(dotnet.DatabaseCV context)
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

            var cv_info = await _context.CVS.FirstOrDefaultAsync(m => m.Id == id);

            if (cv_info == null)
            {
                return NotFound();
            }
            else 
            {
                CV_Info = cv_info;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CVS == null)
            {
                return NotFound();
            }
            var cv_info = await _context.CVS.FindAsync(id);

            if (cv_info != null)
            {
                CV_Info = cv_info;
                _context.CVS.Remove(CV_Info);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
