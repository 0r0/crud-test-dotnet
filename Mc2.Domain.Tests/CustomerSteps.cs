using Mc2.Domain.Contracts.CustomerManagers;
using Mc2.Domain.CustomerManagers;
using Mc2.Domain.Tests.Stub;
using NSubstitute;

namespace Mc2.Domain.Tests;

public class CustomerSteps : TestBaseStep
{
    private Dictionary<string, Customer> _customers = new();
    private readonly ICustomerService _service;

    protected CustomerSteps()
    {
        _service = Substitute.For<ICustomerService>();
    }

    protected void IRegisterCustomerWithFollowingProperties(CustomerArgs customerArgs)
    {
        try
        {
            var customer = Customer.Create(customerArgs, _service);
            _customers.Add(customerArgs.FirstName, customer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Exception = e;
        }
    }

    protected void ICanFindACustomerWithAboveInfo(CustomerArgs customerArgs)
    {
        _service.IsEmailDuplicated(customerArgs.Id, customerArgs.Email).Returns(false);
        _service.IsCustomerDuplicatedByFirstNameLastNameAndDateOfBirth(customerArgs.FirstName, customerArgs.LastName,
            customerArgs.DateOfBirth).Returns(false);
        var expected = new CustomerDefined(customerArgs.Id, customerArgs.FirstName, customerArgs.LastName,
            customerArgs.DateOfBirth, customerArgs.PhoneNumber, customerArgs.Email, customerArgs.BankAccountNumber);
        _customers[customerArgs.FirstName].ShouldContainsEquivalencyOfDomainEvent(expected);
    }
}