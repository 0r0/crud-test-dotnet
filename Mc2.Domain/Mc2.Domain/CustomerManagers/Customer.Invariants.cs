namespace Mc2.Domain.CustomerManagers;

public partial class Customer
{
    private void GuardAgainstSameFirstNameAndLastNameAndDateOfBirth(CustomerArgs args, ICustomerService service)
    {
        if (service.IsCustomerDuplicatedByFirstNameLastNameAndDateOfBirth(args.FirstName, args.LastName,
                args.DateOfBirth))
            throw new CustomerWithSameFirstNameLastNameAndDateOfBirthExistException();
    }
}

public class CustomerWithSameFirstNameLastNameAndDateOfBirthExistException : BusinessException
{
    public CustomerWithSameFirstNameLastNameAndDateOfBirthExistException():base(Customer_Error.CS_1004)
    {
    }
}