using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IT499_Capstone_Project;

namespace IT499_Test_App.Pages
{
    public class CancelOrderModel : PageModel
    {
        public int canceledOrder;
        public string cancelStatus;

        public void OnGet()
        {
            canceledOrder = Convert.ToInt32(Request.Query["orderID"]);
            bool ordCanceled = false;
            OrderStatus ordStatus = new OrderStatus();

            ordCanceled = ordStatus.Cancel_Order(canceledOrder);

            if (ordCanceled)
            {;
                cancelStatus = "Order was successfully cancelled.";
            }
            else
                cancelStatus = "There was an error and we are unable to cancel the order at this time.";

        }
    }
}
