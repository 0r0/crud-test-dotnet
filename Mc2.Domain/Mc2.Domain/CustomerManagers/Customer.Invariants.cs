using Mc2.Domain.Contracts.CustomerManagers.Exceptions;

namespace Mc2.Domain.CustomerManagers;

public partial class Customer
{
    private static void GuardAgainstSameFirstNameAndLastNameAndDateOfBirth(CustomerArgs args, ICustomerService service)
    {
        if (service.IsCustomerDuplicatedByFirstNameLastNameAndDateOfBirth(args.Id, args.FirstName, args.LastName,
                args.DateOfBirth))
            throw new CustomerWithSameFirstNameLastNameAndDateOfBirthExistException();
    }

    private static void GuardAgainstSameEmail(CustomerArgs args, ICustomerService service)
    {
        if (service.IsEmailDuplicated(args.Id, args.Email))
            throw new CustomerWithSameEmailExistException();
    }
}