namespace Mc2.CrudTest.AcceptanceTests.Then;

[Binding]
public class CanFindCustomerWithFirstName
{
    [Then(@"I can find a customer with '(.*)' first name and above info")]
    public void ThenICanFindACustomerWithFirstNameAndAboveInfo(string ali)
    {
        ScenarioContext.StepIsPending();
    }
}