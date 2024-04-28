using EcommerceWebsite.Server.Data;
using EcommerceWebsite.Server.Models;
using EcommerceWebsite.Server.Services.Infrastructures;

namespace EcommerceWebsite.Server.Services.Repositories
{
    public class CustomerRepository : ICustomer
    {
        private ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public void Insert(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}