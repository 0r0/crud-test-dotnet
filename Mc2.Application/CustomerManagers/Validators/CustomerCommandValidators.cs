using Mc2.Application.Contracts.CustomerManagers;
using Mc2.CrudTest.Presentation.Shared;

namespace Mc2.Application.CustomerManagers.Validators;

public class CustomerCommandValidators : ICommandValidator<DefineCustomerCommand>,
    ICommandValidator<ModifyCustomerCommand>
{
    public void Validate(DefineCustomerCommand command)
    {
        new DefineCustomerCommandValidator().Validate(command);
    }

    public void Validate(ModifyCustomerCommand command)
    {
        new ModifyCustomerCommandValidator().Validate(command);
    }
}