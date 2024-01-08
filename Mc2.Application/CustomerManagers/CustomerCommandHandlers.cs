using Mc2.Application.Contracts.CustomerManagers;
using Mc2.CrudTest.Presentation.Shared;

namespace Mc2.Application.CustomerManagers;

public class CustomerCommandHandlers :ICommandHandler<DefineCustomerCommand>,
    ICommandHandler<ModifyCustomerCommand>,
    ICommandHandler<RemoveCustomerCommand>
{
    public Task Handle(DefineCustomerCommand command)
    {
        throw new NotImplementedException();
    }

    public Task Handle(ModifyCustomerCommand command)
    {
        throw new NotImplementedException();
    }

    public Task Handle(RemoveCustomerCommand command)
    {
        throw new NotImplementedException();
    }
}