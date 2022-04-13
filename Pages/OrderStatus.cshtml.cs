using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using Newtonsoft.Json;

namespace IT499_Test_App.Pages
{
    public class OrderStatusModel : PageModel
    {
        [TempData]
        public string formResult { get; set; }

        [TempData]
        public string cancelID { get; set; }

        public DataTable orders = new DataTable();
       
        public void OnGet()
        {
            orders = (DataTable)JsonConvert.DeserializeObject(formResult, (typeof(DataTable)));
        }
    }
}
