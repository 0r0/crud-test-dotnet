namespace Mc2.CrudTest.AcceptanceTests.Then;

[Binding]
public class ICanNotFindACustomer
{
    [Then(@"I can not find a customer  with first name '(.*)' and above info")]
    public void ThenICanNotFindACustomerWithFirstNameAndAboveInfo(string ali)
    {
        ScenarioContext.StepIsPending();
    }
}