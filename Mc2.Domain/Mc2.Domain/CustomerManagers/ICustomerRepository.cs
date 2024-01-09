using DDDFramework.Core;
using Mc2.Domain.Contracts.CustomerManagers;

namespace Mc2.Domain.CustomerManagers;

public interface ICustomerRepository : IRepository
{
    void Add(Customer customer);
    Customer GetById(CustomerId id);
}