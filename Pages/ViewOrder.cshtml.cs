using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Data;
using IT499_Capstone_Project;

namespace IT499_Test_App.Pages
{
    public class ViewOrderModel : PageModel
    {
        [TempData]
        public string formResult { get; set; }

        public int viewedOrder;
        public DataTable order = new DataTable();

        public void OnGet()
        {
            OrderStatus ord = new OrderStatus();

            viewedOrder = Convert.ToInt32(Request.Query["orderID"]);

            order = ord.View_Orders(viewedOrder);
        }
    }
}
