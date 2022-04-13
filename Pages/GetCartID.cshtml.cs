using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using IT499_Capstone_Project;

namespace IT499_Test_App.Pages
{
    public class GetCartIDModel : PageModel
    {
        [TempData]
        public string formResult { get; set; }
        [BindProperty]
        public string emailAddress { get; set; }

        public static ShoppingCart shopCart;
        public string dbStatus;

        public void OnGet()
        {
            shopCart = new ShoppingCart();

            dbStatus = shopCart.dbStatus;
        }
        public IActionResult OnPost()
        {
            try
            {
                var email = emailAddress;
                //formResult = shopCart.Load_Cart(email);

                return RedirectToPage("/ShoppingCart", new { email = email});
            }
            catch (FormatException ex)
            {
                ModelState.AddModelError("EmailAddress", "Invalid email address");
                return Page();
            }
        }
    }
}
