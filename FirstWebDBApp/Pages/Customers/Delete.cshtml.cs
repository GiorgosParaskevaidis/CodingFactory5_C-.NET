using FirstWebDBApp.Models;
using FirstWebDBApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebStarterDBApp.Models;

namespace FirstWebDBApp.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        public List<Error> ErrorArray { get; set; } = new();
        private readonly ICustomerService _customerService;

        public DeleteModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public void OnGet( int id)
        {
            try
            {
                Customer? customer = _customerService?.DeleteCustomer(id);
                Response.Redirect("/Customers/getall");
            }
            catch (Exception e)
            {
                ErrorArray.Add(new Error("", e.Message, ""));
            }
        }
    }
}
