namespace WebAPI_EFCodeFirst.Models
{
    public interface ICustomerDataAccess
    {
        void Add(Customer customer);
        void Delete(int id);
        void Update(Customer customer);
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
    }

    public class CustomerDataAccess : ICustomerDataAccess
    {
        private readonly CustomerDBContext _dbContext;
        public CustomerDataAccess(CustomerDBContext customerDBContext)
        {
            this._dbContext = customerDBContext;
        }

        public void Add(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var record = _dbContext.Customers.Find(id);
            if(record != null)
            {
                _dbContext.Customers.Remove(record);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Customer id not found");
            }
        }

        public List<Customer> GetAllCustomers()
        {
            return _dbContext.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            var record = _dbContext.Customers.Find(id);
            if (record != null)
            {
                return record;
            }
            else
            {
                throw new Exception("Customer id not found");
            }
        }

        public void Update(Customer customer)
        {
            var record = _dbContext.Customers.Find(customer.Id);
            if (record != null)
            {
                record.Name = customer.Name;
                record.City = customer.City;
                record.State = customer.State;
                record.Country= customer.Country;
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Customer id not found");
            }
        }
    }
}
