namespace Mc2.CrudTest.AcceptanceTests.When;

[Binding]
public class IRegisterCustomer
{
    [When(@"I register customer with following properties")]
    public void WhenIRegisterCustomerWithFollowingProperties(Table table)
    {
        ScenarioContext.StepIsPending();
    }
}