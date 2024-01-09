using Mc2.Domain.Contracts.CustomerManagers;
using Mc2.Domain.CustomerManagers;

namespace Mc2.Query;

public class CustomerRepository : ICustomerRepository
{
    public void Add(Customer customer)
    {
        throw new NotImplementedException();
    }

    public Customer GetById(CustomerId id)
    {
        throw new NotImplementedException();
    }
}