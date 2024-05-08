using FirstWebDBApp.DTO;
using FirstWebDBApp.Models;
using FirstWebDBApp.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebStarterDBApp.Models;

namespace FirstWebDBApp.Pages.Customers
{
    public class CreateModel : PageModel
    {
        public List<Error>? ErrorArray { get; set; } = new();
        public CustomerInsertDTO? CustomerInsertDTO { get; set; } = new();

        private readonly ICustomerService? _customerService;
        private readonly IValidator<CustomerInsertDTO>? _customerInsertValidator;

        public CreateModel(ICustomerService? customerService, IValidator<CustomerInsertDTO>? customerInsertValidator)
        {
            _customerService = customerService;
            _customerInsertValidator = customerInsertValidator;
        }

        public void OnGet()
        {

        }

        public void OnPost(CustomerInsertDTO dto)
        {
            CustomerInsertDTO = dto;

            var validationResult = _customerInsertValidator!.Validate(dto);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ErrorArray!.Add(new Error(error.ErrorCode, error.ErrorMessage, error.PropertyName));
                }
                return;
            }

            try
            {
                Customer? customer = _customerService!.InsertCustomer(dto);
                Response.Redirect("/Customers/getall");

            }
            catch (Exception e)
            {
                ErrorArray!.Add(new Error("", e.Message, ""));
            }
        }
    }
}
