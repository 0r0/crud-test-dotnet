using Mc2.CrudTest.AcceptanceTests.ScreenPlay.CustomerManager.Commands;
using TechTalk.SpecFlow.Assist;

namespace Mc2.CrudTest.AcceptanceTests.Features.CustomerManagers.ScenarioModels;

[Binding]
public class CustomerModelTransformer
{
    [StepArgumentTransformation]
    public DefineCustomerManagerCommand ConvertToDefineCommand(Table table)
    {
        var model = table.CreateInstance<CustomerModel>();
        return new DefineCustomerManagerCommand()
        {
            BankAccountNumber = model.BankAccountNumber,
            Email = model.Email,
            Id = default,
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
            DateOfBirth = model.DateOfBirth
        };
    }

    [StepArgumentTransformation]
    public ModifyCustomerManagerCommand ConvertToModifyCommand(Table table)
    {
        var model = table.CreateInstance<CustomerModel>();
        return new ModifyCustomerManagerCommand()
        {
            BankAccountNumber = model.BankAccountNumber,
            Email = model.Email,
            Id = default,
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
            DateOfBirth = model.DateOfBirth
        };
    }
}