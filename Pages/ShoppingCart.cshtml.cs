using IT499_Capstone_Project;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Net;
using Newtonsoft.Json;
using HtmlAgilityPack;
using System.Linq;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Web;

namespace IT499_Test_App.Pages
{
    public class UpdatedQuantity
    {
        public string orderNum { get; set; }
        public string quantity { get; set; }
    }

    public class ShoppingCartModel : PageModel
    {
        [TempData]
        public string formResult { get; set; }
        [BindProperty]
        public string emailAddress { get; set; }

        public ShoppingCart shopCart;
        public DataTable cart = new DataTable();
        public double totalCost = 0;
        public DataColumn col = new DataColumn();
        public List<UpdatedQuantity> updated = new List<UpdatedQuantity>();
        public string saveStatus = "";
        public string lastSaved = "";

        public void OnGet()
        {
            emailAddress = Request.Query["email"];
            var email = emailAddress;

            shopCart = new ShoppingCart();
            formResult = shopCart.Load_Cart(email);

            cart = (DataTable)JsonConvert.DeserializeObject(formResult, (typeof(DataTable)));

            try
            {
                lastSaved = cart.Rows[0]["DateSaved"].ToString();
            }
            catch (Exception ex)
            {
                lastSaved = "Cart Not Found";
            }
            col = cart.Columns[0];
        }
        public IActionResult OnPostSave(string id, string quantity)
        {
            try
            {
                var email = emailAddress;

                shopCart = new ShoppingCart();
                saveStatus = shopCart.Save_Cart(email, id, quantity);

                return RedirectToPage("/ShoppingCart", new { email = email });
            }
            catch (FormatException ex)
            {
                ModelState.AddModelError("EmailAddress", "Invalid email address");
                return Page();
            }
        }
        public IActionResult OnPostUpdate(string id, string quantity)
        {
            try
            {
                var email = emailAddress;

                shopCart = new ShoppingCart();
                saveStatus = shopCart.Update_Cart(email, id, quantity);

                return RedirectToPage("/ShoppingCart", new { email = email });
            }
            catch (FormatException ex)
            {
                ModelState.AddModelError("EmailAddress", "Invalid email address");
                return Page();
            }
        }
    }
}
