using AutoMapper;
using FirstWebDBApp.DTO;
using FirstWebDBApp.Models;
using FirstWebDBApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebStarterDBApp.Models;

namespace FirstWebDBApp.Pages.Customers
{
    public class IndexModel : PageModel
    {
        public List<CustomerReadOnlDTO>? Customers { get; set; } = new();
        public Error? ErrorObj { get; set; } = new();

        private readonly IMapper? _mapper;
        private readonly ICustomerService? _customerService;

        public IndexModel(IMapper? mapper, ICustomerService? customerService)
        {
            _mapper = mapper;
            _customerService = customerService;
        }

        public void OnGet()
        {
            try
            {
                ErrorObj = null;
                IList<Customer> customers = _customerService!.GetAllCustomers();

                foreach (var customer in customers)
                {
                    CustomerReadOnlDTO? customerDTO = _mapper!.Map<CustomerReadOnlDTO>(customer);
                    Customers.Add(customerDTO);
                }
            }
            catch (Exception e)
            {
                ErrorObj = new Error(" ", e.Message, "");
            }
        }
    }
}
