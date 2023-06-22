using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dotnet;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Taghelpers.Pages.SP
{
    public class IndexModel : PageModel
    {
        private readonly dotnet.DatabaseCV _context;

        public IndexModel(dotnet.DatabaseCV context)
        {
            _context = context;
        }
        public IList<CV_Info> CV_Info { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CVS != null)
            {
                CV_Info = await _context.CVS.ToListAsync();
            }
        }
        [HttpPost]
        public IActionResult OnPost()
        {
            // Retrieve data from the database(ntebe 3al context whot lmodel te3 ltable in the database)
            var data = _context.CVS.ToList(); // Replace "YourDataModel" with your actual data model

            // Generate the PDF file
            byte[] pdfBytes = GeneratePdf(data);

            // Return the PDF file for download
            return File(pdfBytes, "application/pdf", "filled_data.pdf");
        }

        private byte[] GeneratePdf(List<CV_Info> data)
        {
            // Create a new PDF document using iTextSharp
            Document document = new Document();
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
            document.Open();

            // Add content to the PDF document
            foreach (var item in data)
            {
                // Example: Adding each item's data to the PDF
                Paragraph paragraph = new Paragraph($"Name: {item.first_Name}\nlastName: {item.last_Name}\n Email {item.email} \n grade {item.grade}\n\n\b");
                document.Add(paragraph);
            }


            // Close the document
            document.Close();

            // Get the PDF document as a byte array
            byte[] pdfBytes = memoryStream.ToArray();

            return pdfBytes;
        }
    }
}
