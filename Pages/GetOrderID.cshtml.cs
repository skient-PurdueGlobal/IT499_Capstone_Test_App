using System;
using System.Net.Mail;
using IT499_Capstone_Project;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT499_Test_App.Pages
{
    public class GetOrderIDModel : PageModel
    {
        [TempData]
        public string formResult { get; set; }
        [BindProperty]
        public string emailAddress { get; set; }

        public static OrderStatus ordStatus;
        public string dbStatus;

        public void OnGet()
        {
            ordStatus = new OrderStatus();

            dbStatus = ordStatus.dbStatus;
        }
        public IActionResult OnPost()
        {
            try
            {
                var email = emailAddress;
                formResult = ordStatus.Load_Orders(email);

                return RedirectToPage("/OrderStatus");
            }
            catch(FormatException ex)
            {
                ModelState.AddModelError("EmailAddress", "Invalid email address");
                return Page();
            }
        }
    }
}
