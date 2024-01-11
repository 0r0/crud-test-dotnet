using Mc2.Application.Contracts.CustomerManagers;
using Mc2.CrudTest.Presentation.Shared;
using Mc2.CrudTest.Presentation.Shared.EventStore;
using Mc2.Domain.Contracts.CustomerManagers;
using Mc2.Domain.CustomerManagers;

namespace Mc2.Application.CustomerManagers;

public class CustomerCommandHandlers : ICommandHandler<DefineCustomerCommand>,
    ICommandHandler<ModifyCustomerCommand>,
    ICommandHandler<RemoveCustomerCommand>
{
    private readonly ICustomerService _service;
    private readonly ICustomerRepository _customerRepository;
    private readonly ICustomerArgsFactory _argsFactory;

    public CustomerCommandHandlers(ICustomerService service, ICustomerRepository customerRepository,
        ICustomerArgsFactory argsFactory)
    {
        _service = service;
        _customerRepository = customerRepository;
        _argsFactory = argsFactory;
    }

    public void Handle(DefineCustomerCommand command)
    {
        var customerArgs = _argsFactory.CreateFrom(command);
        var customer = Customer.Create(customerArgs, _service);
        _customerRepository.Add(customer);
    }

    public void Handle(ModifyCustomerCommand command)
    {
        throw new NotImplementedException();
    }

    public void Handle(RemoveCustomerCommand command)
    {
        throw new NotImplementedException();
    }
}