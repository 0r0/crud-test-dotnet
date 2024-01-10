using FizzWare.NBuilder;
using Mc2.Domain.Contracts.CustomerManagers;
using Mc2.Domain.CustomerManagers;
using TestStack.BDDfy;

namespace Mc2.Domain.Tests;


public class CustomerDefinedTest :CustomerSteps
{
    [Theory]
    [InlineData("Ali","Karami","1990/01/01",09381982893,"ali.karami@gmail.com","IE12BOFI90000112345678")]
    public void a_customer_can_be_defined_with_valid_properties(string firstName,string lastName,DateTime dateOfBirth,long phoneNumber,string email,string bankOfAccount)
    {
        var customer = CustomerArgs.Builder
            .With(a => a.Id, new CustomerId(Guid.NewGuid()))
            .With(a => a.FirstName, firstName)
            .With(a => a.LastName, lastName)
            .With(a=>a.DateOfBirth,dateOfBirth)
            .With(a => a.Email, email)
            .With(a => a.PhoneNumber, phoneNumber)
            .With(a => a.BankAccountNumber, bankOfAccount).Build();
        this.When(a => IRegisterCustomerWithFollowingProperties(customer))
            .Then(a=>ICanFindACustomerWithAboveInfo(customer))
            .BDDfy();


    }
}