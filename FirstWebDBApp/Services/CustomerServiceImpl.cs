using AutoMapper;
using FirstWebDBApp.DAO;
using FirstWebDBApp.DTO;
using FirstWebDBApp.Models;
using System.Transactions;

namespace FirstWebDBApp.Services
{
    public class CustomerServiceImpl : ICustomerService
    {
        private readonly ICustomerDAO? _customerDAO;
        private readonly IMapper? _mapper;
        private readonly ILogger<CustomerServiceImpl>? _logger;

        public CustomerServiceImpl(ICustomerDAO? customerDAO, IMapper? mapper, ILogger<CustomerServiceImpl>? logger)
        {
            _customerDAO = customerDAO;
            _mapper = mapper;
            _logger = logger;
        }

        public Customer? DeleteCustomer(int id)
        {
            Customer? customerToReturn = null;

            try
            {
                using TransactionScope scope = new();
                customerToReturn = _customerDAO!.GetById(id);
                _customerDAO.Delete(id);
                scope.Complete();

                _logger!.LogInformation("Delete successful!");
                return customerToReturn;
            }
            catch (Exception e)
            {
                _logger!.LogInformation("Error during delete" + e.Message);
                throw;
            }
        }

        public IList<Customer> GetAllCustomers()
        {
            try
            {
                IList<Customer> customers = _customerDAO!.GetAll();
                return customers;
            }
            catch (Exception e)
            {
                _logger!.LogInformation("Error during fetching customers" + e.Message);
                throw;
            }
        }

        public Customer? GetCustomer(int id)
        {
            try
            {
                Customer? customer = _customerDAO!.GetById(id);
                return customer;
            }
            catch (Exception e)
            {
                _logger!.LogInformation("Error during fetching a customer" + e.Message);
                throw;
            }
        }

        public Customer? InsertCustomer(CustomerInsertDTO dTO)
        {
            if (dTO is null) return null;

            try
            {
                var customer = _mapper!.Map<Customer>(dTO);
                using TransactionScope scope = new();
                Customer? insertedCustomer = _customerDAO!.Insert(customer);
                scope.Complete();
                _logger!.LogInformation("Success insert!");
                return insertedCustomer;
            }
            catch (Exception e)
            {
                _logger!.LogInformation("Error during inserting customer" + e.Message);
                throw;
            }
        }

        public Customer? UpdateCustomer(CustomerUpdateDTO dTO)
        {
            if (dTO is null) return null;
            Customer? customerToReturn = null;

            try
            {
                var customer = _mapper!.Map<Customer>(dTO);
                using TransactionScope scope = new();
                customerToReturn = _customerDAO!.Update(customer);
                scope.Complete();
                _logger!.LogInformation("Succesfull update");
                return customerToReturn;
            }
            catch (Exception e)
            {
                _logger!.LogInformation("Error during update" + e.Message);
                throw;
            }
        }
    }
}
