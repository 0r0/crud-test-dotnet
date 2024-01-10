using Mc2.CrudTest.Presentation.Shared;
using Mc2.Domain.Contracts.CustomerManagers;

namespace Mc2.Domain.CustomerManagers;

public partial class Customer : AggregateRoot<CustomerId>
{
    public Customer()
    {
    }

    public Customer(CustomerArgs args, ICustomerService service)
    {
        GuardAgainstSameFirstNameAndLastNameAndDateOfBirth(args, service);
        GuardAgainstSameEmail(args, service);
        ApplyAndPublish(new CustomerDefined(args.Id, args.FirstName, args.LastName, args.DateOfBirth, args.PhoneNumber,
            args.Email, args.BankAccountNumber));
    }


    public static Customer Create(CustomerArgs args, ICustomerService service)
    {
        Customer customer = new(args, service);
        return customer;
    }

    public void Modify(CustomerArgs args, ICustomerService service)
    {
        GuardAgainstSameFirstNameAndLastNameAndDateOfBirth(args, service);
        GuardAgainstSameEmail(args, service);
        ApplyAndPublish(new CustomerModified(args.Id, args.FirstName, args.LastName, args.DateOfBirth, args.PhoneNumber,
            args.Email, args.BankAccountNumber));
    }


    public void Remove(ICustomerService service)
    {
        //todo Add guards here!
        ApplyAndPublish(new CustomerRemoved(Id));
    }
}