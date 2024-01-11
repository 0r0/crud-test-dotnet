using Mc2.CrudTest.Presentation.Shared;
using Mc2.CrudTest.Presentation.Shared.EventStore;
using Mc2.Domain.Contracts.CustomerManagers;
using Mc2.Domain.CustomerManagers;

namespace Mc2.Query;

public class CustomerRepository : ICustomerRepository
{
    private readonly IEventSourceRepository<Customer, CustomerId> _repository;

    public CustomerRepository(IEventSourceRepository<Customer, CustomerId> repository) => _repository = repository;

    public void Add(Customer customer)
        => _repository.AppendEvents(customer);

    public Customer GetById(CustomerId id)
        => _repository.GetById(id);
}