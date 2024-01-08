using FizzWare.NBuilder;
using Mc2.Application.Contracts.CustomerManagers;
using Mc2.Domain.Contracts.CustomerManagers;
using Mc2.Domain.CustomerManagers;

namespace Mc2.Application.CustomerManagers;

public class CustomerArgsFactory : ICustomerArgsFactory
{
    public CustomerArgs CreateFrom(DefineCustomerCommand command)
    {
        command.Id = Guid.NewGuid();
        return CustomerArgs.Builder
            .With(a => a.Id, new CustomerId(command.Id))
            .With(a=>a.FirstName,command.FirstName)
            .With(a=>a.LastName,command.LastName)
            .With(a=>a.Email,command.Email)
            .With(a=>a.PhoneNumber,command.PhoneNumber)
            .With(a=>a.BankAccountNumber,command.BankAccountNumber)
            .With(a=>a.DateOfBirth,command.DateOfBirth)
            .Build();
    }

    public CustomerArgs CreateFrom(ModifyCustomerCommand command)
    {
        return CustomerArgs.Builder
            .With(a => a.Id, new CustomerId(command.Id))
            .With(a=>a.FirstName,command.FirstName)
            .With(a=>a.LastName,command.LastName)
            .With(a=>a.Email,command.Email)
            .With(a=>a.PhoneNumber,command.PhoneNumber)
            .With(a=>a.BankAccountNumber,command.BankAccountNumber)
            .With(a=>a.DateOfBirth,command.DateOfBirth)
            .Build();
    }
}