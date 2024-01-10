using FizzWare.NBuilder;
using Mc2.Domain.Contracts.CustomerManagers;
using Mc2.Domain.CustomerManagers;
using TestStack.BDDfy;

namespace Mc2.Domain.Tests;

public class CustomerDefinedTest : CustomerSteps
{
    [Theory]
    [InlineData("Ali", "Karami", "1990/01/01", 09381982893, "ali.karami@gmail.com", "IE12BOFI90000112345678")]
    public void a_customer_can_be_defined_with_valid_properties(string firstName, string lastName, DateTime dateOfBirth,
        long phoneNumber, string email, string bankOfAccount)
    {
        var customer = CustomerArgs.Builder
            .With(a => a.Id, new CustomerId(Guid.NewGuid()))
            .With(a => a.FirstName, firstName)
            .With(a => a.LastName, lastName)
            .With(a => a.DateOfBirth, dateOfBirth)
            .With(a => a.Email, email)
            .With(a => a.PhoneNumber, phoneNumber)
            .With(a => a.BankAccountNumber, bankOfAccount).Build();
        
        this.Given(a=>EmailIsNotDuplicated(customer))
            .And(a=>CustomerIsNotDuplicatedBasedOnFirstNameLastNameAndDateOfBirth(customer))
            .When(a => IRegisterCustomerWithFollowingProperties(customer))
            .Then(a => ICanFindACustomerWithAboveInfo(customer))
            .BDDfy();
    }

    [Theory]
    [InlineData("CS-1004", "first name and last name and date of birth must be unique when customer defined", "Ali",
        "Karami", "1990/01/01", 09131982893, "ali.karami@gmail.com", "IE12BOFI90000112345678")]
    public void
        a_customer_can_be_defined_when_there_are_no_customer_with_same_first_name_and_last_name_and_birth_of_date(
            string code, string message, string firstName,
            string lastName, DateTime dateOfBirth, long phoneNumber, string email, string bankOfAccount)
    {
        var oldCustomer = CustomerArgs.Builder
            .With(a => a.Id, new CustomerId(Guid.NewGuid()))
            .With(a => a.FirstName, firstName)
            .With(a => a.LastName, lastName)
            .With(a => a.DateOfBirth, dateOfBirth)
            .With(a => a.Email, "Mahya@gmail.com")
            .With(a => a.PhoneNumber, phoneNumber)
            .With(a => a.BankAccountNumber, bankOfAccount).Build();
        var newCustomer = CustomerArgs.Builder
            .With(a => a.Id, new CustomerId(Guid.NewGuid()))
            .With(a => a.FirstName, firstName)
            .With(a => a.LastName, lastName)
            .With(a => a.DateOfBirth, dateOfBirth)
            .With(a => a.Email, email)
            .With(a => a.PhoneNumber, phoneNumber)
            .With(a => a.BankAccountNumber, bankOfAccount).Build();
        this.Given(a=>ThereIsARegisteredCustomerWithTheFollowingProperties(oldCustomer))
            .When(a => IRegisterCustomerWithFollowingProperties(newCustomer))
            .Then(a => MustThrowException(code, message))
            .BDDfy();
    }

    [Theory]
    [InlineData("CS-1005", "email must be unique when customer defined", "Ali", "Karami", "1990/01/01", 09381982893,
        "alikarami@gmail.com", "IE12BOFI90000112345678")]
    public void a_customer_can_not_be_defined_when_a_customer_with_same_email_address_registered(string code,
        string message, string firstName,
        string lastName, DateTime dateOfBirth, long phoneNumber, string email, string bankOfAccount)
    {
        var oldCustomer = CustomerArgs.Builder
            .With(a => a.Id, new CustomerId(Guid.NewGuid()))
            .With(a => a.FirstName, firstName)
            .With(a => a.LastName, lastName)
            .With(a => a.DateOfBirth, dateOfBirth)
            .With(a => a.Email, email)
            .With(a => a.PhoneNumber, phoneNumber)
            .With(a => a.BankAccountNumber, bankOfAccount).Build();
        var newCustomer = CustomerArgs.Builder
            .With(a => a.Id, new CustomerId(Guid.NewGuid()))
            .With(a => a.FirstName, "Akbar")
            .With(a => a.LastName, "Akbari")
            .With(a => a.DateOfBirth, dateOfBirth)
            .With(a => a.Email, email)
            .With(a => a.PhoneNumber, phoneNumber)
            .With(a => a.BankAccountNumber, bankOfAccount).Build();
        this.Given(a=>ThereIsARegisteredCustomerWithTheFollowingProperties(oldCustomer))
            .When(a => IRegisterCustomerWithFollowingProperties(newCustomer))
            .Then(a => MustThrowException(code, message))
            .BDDfy();
        
    }
}