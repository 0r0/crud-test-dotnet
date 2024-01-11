// using Mc2.CrudTest.Presentation.Shared;
// using Mc2.Domain.Contracts.CustomerManagers;
// using Mc2.Domain.CustomerManagers;
// using Mc2.Domain.Tests.Stub;
// using NSubstitute;
//
// namespace Mc2.Domain.Tests;
//
// public class CustomerSteps : TestBaseStep
// {
//     private Dictionary<string, Customer> _customers = new();
//     private readonly ICustomerService _service;
//
//     protected CustomerSteps()
//     {
//         _service = Substitute.For<ICustomerService>();
//     }
//
//     protected void ThereIsARegisteredCustomerWithTheFollowingProperties(CustomerArgs args)
//     {
//         _service.IsEmailDuplicated(args.Id, args.Email).Returns(false);
//         _service.IsCustomerDuplicatedByFirstNameLastNameAndDateOfBirth(args.Id, args.FirstName, args.LastName,
//             args.DateOfBirth).Returns(false);
//         var e = new CustomerDefined(args.Id,args.FirstName,args.LastName,args.DateOfBirth,args.PhoneNumber,args.Email,args.BankAccountNumber);
//         var customer = CreateFromEvents<Customer, CustomerId>(e);
//         _customers.Add(args.Id.Id.ToString(),customer);
//     }
//     
//     
//
//     protected void IRegisterCustomerWithFollowingProperties(CustomerArgs customerArgs)
//     {
//         try
//         {
//             var customer = Customer.Create(customerArgs, _service);
//             _customers.Add(customerArgs.Id.Id.ToString(), customer);
//         }
//         catch (BusinessException e)
//         {
//             Exception = e;
//         }
//     }
//
//     protected void ICanFindACustomerWithAboveInfo(CustomerArgs customerArgs)
//     {
//         
//         var expected = new CustomerDefined(customerArgs.Id, customerArgs.FirstName, customerArgs.LastName,
//             customerArgs.DateOfBirth, customerArgs.PhoneNumber, customerArgs.Email, customerArgs.BankAccountNumber);
//         _customers[customerArgs.Id.Id.ToString()].ShouldContainsEquivalencyOfDomainEvent(expected);
//     }
//
//     #region Helper
//
//     protected void EmailIsNotDuplicated(CustomerArgs customerArgs)
//     {
//         _service.IsEmailDuplicated(customerArgs.Id, customerArgs.Email).Returns(false);
//
//     }   protected void EmailIsDuplicated(CustomerArgs customerArgs)
//     {
//         _service.IsEmailDuplicated(customerArgs.Id, customerArgs.Email).Returns(true);
//
//     }
//
//     protected void CustomerIsNotDuplicatedBasedOnFirstNameLastNameAndDateOfBirth(CustomerArgs customerArgs)
//     {
//         _service.IsCustomerDuplicatedByFirstNameLastNameAndDateOfBirth(customerArgs.Id,customerArgs.FirstName, customerArgs.LastName,
//             customerArgs.DateOfBirth).Returns(false);
//     }
//     protected void CustomerIsDuplicatedBasedOnFirstNameLastNameAndDateOfBirth(CustomerArgs customerArgs)
//     {
//         _service.IsCustomerDuplicatedByFirstNameLastNameAndDateOfBirth(customerArgs.Id,customerArgs.FirstName, customerArgs.LastName,
//             customerArgs.DateOfBirth).Returns(true);
//     }
//
//     #endregion
//     
// }