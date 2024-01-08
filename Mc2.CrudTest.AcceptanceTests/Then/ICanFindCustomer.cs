namespace Mc2.CrudTest.AcceptanceTests.Then;

[Binding]
public class ICanFindCustomer
{
    [Then(@"I can find a customer with above info")]
    public void ThenICanFindACustomerWithAboveInfo()
    {
        ScenarioContext.StepIsPending();
    }
}