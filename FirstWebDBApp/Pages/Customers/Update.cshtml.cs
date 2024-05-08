using AutoMapper;
using FirstWebDBApp.DTO;
using FirstWebDBApp.Models;
using FirstWebDBApp.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebStarterDBApp.Models;

namespace FirstWebDBApp.Pages.Customers
{
    public class UpdateModel : PageModel
    {
        public CustomerUpdateDTO? CustomerUpdateDTO { get; set; } = new();
        public List<Error> ErrorArray { get; set; } = new();

        public readonly ICustomerService? _customerService;
        public readonly IValidator<CustomerUpdateDTO>? _customerUpdateValidator;
        public readonly IMapper? _mapper;

        public UpdateModel(ICustomerService? customerService, IValidator<CustomerUpdateDTO>? customerUpdateValidator, IMapper? mapper)
        {
            _customerService = customerService;
            _customerUpdateValidator = customerUpdateValidator;
            _mapper = mapper;
        }

        public IActionResult OnGet(int id)
        {
            try
            {
                Customer? customer = _customerService!.GetCustomer(id);
                CustomerUpdateDTO = _mapper!.Map<CustomerUpdateDTO>(customer);
            }
            catch (Exception e)
            {
                ErrorArray.Add(new Error("", e.Message, ""));
            }
            return Page();
        }

        public void OnPost(CustomerUpdateDTO dto)
        {
            CustomerUpdateDTO = dto;

            var validationResult = _customerUpdateValidator!.Validate(dto);


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
                Customer? customer = _customerService!.UpdateCustomer(dto);
                Response.Redirect("/Customers/getall");
            }
            catch (Exception e)
            {
                ErrorArray!.Add(new Error("", e.Message, ""));
            }
        }
    }
}
