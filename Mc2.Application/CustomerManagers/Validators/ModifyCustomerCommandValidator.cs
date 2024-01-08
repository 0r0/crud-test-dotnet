using FluentValidation;
using Mc2.Application.Contracts.CustomerManagers;

namespace Mc2.Application.CustomerManagers.Validators;

public class ModifyCustomerCommandValidator : AbstractValidator<ModifyCustomerCommand>
{
    public ModifyCustomerCommandValidator()
    {
        RuleFor(a => a.PhoneNumber).Custom((value, _) =>
        {

        });
        RuleFor(a => a.Email).Custom((value, _) =>
        
        {

        });
        RuleFor(a => a.BankAccountNumber).Custom((value, _) =>
        {

        });
        
    }
}