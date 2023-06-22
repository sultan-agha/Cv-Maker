using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace Taghelpers.Pages
{
    public class BrowseCvModel : PageModel
    {
        // to get the data fro the page 
        public void OnGet(int Counter)
        {
            // put them in variables and print them in the view page 
            @ViewData["Counter"] = Counter;
        }
    }
}
