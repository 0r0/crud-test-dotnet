namespace Mc2.CrudTest.AcceptanceTests.When;

[Binding]
public class IRemoveCustomerWithFirstName
{
    [When(@"I remove the customer  with first name '(.*)'")]
    public void WhenIRemoveTheCustomerWithFirstName(string ali)
    {
        ScenarioContext.StepIsPending();
    }
}