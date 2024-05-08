using FirstWebDBApp.DTO;
using FirstWebDBApp.Models;

namespace FirstWebDBApp.Services
{
    public interface ICustomerService
    {
        Customer? InsertCustomer(CustomerInsertDTO dTO);
        Customer? UpdateCustomer(CustomerUpdateDTO dTO);
        Customer? DeleteCustomer(int id);
        Customer? GetCustomer(int id);
        IList<Customer> GetAllCustomers();
    }
}
