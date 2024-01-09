using Mc2.Application.Contracts.CustomerManagers;
using Mc2.CrudTest.Presentation.Shared;

namespace Mc2.Application.CustomerManagers;

public class CustomerCommandHandlers :ICommandHandler<DefineCustomerCommand>,
    ICommandHandler<ModifyCustomerCommand>,
    ICommandHandler<RemoveCustomerCommand>
{
    public void Handle(DefineCustomerCommand command)
    {
        throw new NotImplementedException();
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