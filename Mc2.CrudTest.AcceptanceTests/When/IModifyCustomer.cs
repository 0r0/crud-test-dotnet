namespace Mc2.CrudTest.AcceptanceTests.When;

[Binding]
public class IModifyCustomer
{
    [When(@"I modify customer with following '(.*)' first name and properties")]
    public void WhenIModifyCustomerWithFollowingFirstNameAndProperties(string ali, Table table)
    {
        ScenarioContext.StepIsPending();
    }
}