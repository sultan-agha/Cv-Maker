using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
//hot using dotnet
using dotnet;
using System.Diagnostics.Metrics;

namespace Taghelpers.Pages
{
    public class newcvModel : PageModel
    {
        // dependency injection kermel bas a3mel submit lahalo yroh ya3mel add lal d.b
        private readonly DatabaseCV _databaseCV;
        public newcvModel(DatabaseCV databaseCV)
        {
            _databaseCV = databaseCV;
        }
        // binding ......

        [BindProperty]
        [Required(ErrorMessage = "First Name field is required")]
        [StringLength(50, ErrorMessage = "Max length {1}")]
        [Display(Name = "First Name")]
        public string first_Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Last Name field is required")]
        [StringLength(50, ErrorMessage = "Max length {1}")]
        [Display(Name = "Last Name")]
        public string last_Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Birth Date field is required")]
        [DataType(DataType.Date, ErrorMessage = "Please Enter a valid date")]
        [Display(Name = "Birth Date")]
        public DateTime bdate { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Nation field is required")]
        [StringLength(50, ErrorMessage = "Max length {1}")]
        [Display(Name = "Nation")]
        public string nation { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Gender field is required")]
        [StringLength(50, ErrorMessage = "Max length {1}")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [BindProperty]
        [Required]
        public bool java { get; set; }

        [BindProperty]
        [Required]
        public bool python { get; set; }

        [BindProperty]
        [Required]

        public bool ASP { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Email field is required")]
        [EmailAddress(ErrorMessage = "This is not a valid email")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "confirm email field is required")]
        [EmailAddress(ErrorMessage = "This is not a valid email")]
        [Compare("email", ErrorMessage = "The emails don't match")]
        [Display(Name = "Confirm Email")]
        public string confirm_email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "THe password field is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string pass { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "nb1 field is required")]
        [Range(1, 20, ErrorMessage = "The number must be between 1 and 20.")]

        public int first_number { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "nb2 field is required")]
        [Range(1, 20, ErrorMessage = "The number must be between 1 and 20.")]
        public int second_number { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "sum field is required")]
        public int res { get; set; }






        // valdating when to redirect and when not to .........
        // and to access the data in the second page 
        public IActionResult OnPost()
        {
            int Counter = 0;
            // Retrieve form data to access them in the redirected page 


            // validating and redirecting 
            if (first_number + second_number != res)
        {
            ModelState.AddModelError("", "The sum is not valid.");
            return Page();
    }
          //checking if the no range
          if(first_number <= 0 || first_number > 20 || second_number < 0 || second_number > 20)
            {
                ModelState.AddModelError("", "please enter a number between 1 and 19.");
                return Page();
            }
            //to check for radio buttons
            if (Gender == null)
            {
                ModelState.AddModelError("SelectedOption", "Please select an option.");
                return Page();
            }
            //checking the password
            if (!IsPasswordValid(pass))
            {
                ModelState.AddModelError("pass", "please enter a coreect password that have more than 8 and have 1 number at least.");
                return Page();
            }
            if (Gender.Equals("male"))
            {
                if (java)
                {
                    Counter += 5;
                }
                if (python)
                {
                    Counter += 5;
                }
                if (ASP)
                {
                    Counter += 5;
                }
            }
            if (Gender.Equals("female"))
            {
                if (java)
                {
                    Counter += 10;
                }
                if (python)
                {
                    Counter +=  10;
                }
                if (ASP)
                {
                    Counter += 10;
                }
            }

            // else
            // data lbel database
            var entity = new CV_Info
            {
                first_Name = first_Name,
                last_Name = last_Name,
                email = email,
                Gender =  Gender,
                grade = Counter
               
            };
            // lakan hone ba3d ma elet shu bade hot feha 
            // 3meltela add bass w3mlt save changes

            _databaseCV.CVS.Add(entity);
            _databaseCV.SaveChanges();
            // redirect bas ekbos submit
            return RedirectToPage("SummaryCV", new {Counter});
}






        //class for password
            
            private bool IsPasswordValid(string password)
            {
            // Add your password validation logic here
            // Return true if the password meets the criteria, false otherwise
            //  Password must have at least 8 characters
            if (string.IsNullOrEmpty(password) && password.Length <= 8)
                return false;


            bool hasLetter = false;
                bool hasNumber = false;

                foreach (char c in password)
                {
                    if (char.IsLetter(c))
                    {
                        hasLetter = true;
                    }
                    else if (char.IsDigit(c))
                    {
                        hasNumber = true;
                    }
                }
            

            return hasLetter && hasNumber;
            }
            
            
        }
    }
   
    

