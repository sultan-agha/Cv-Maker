using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using dotnet;

namespace Taghelpers.Pages.SP
{
    public class CreateModel : PageModel
    {
        private readonly dotnet.DatabaseCV _context;

        public CreateModel(dotnet.DatabaseCV context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CV_Info CV_Info { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.CVS == null || CV_Info == null)
            {
                return Page();
            }

            _context.CVS.Add(CV_Info);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
