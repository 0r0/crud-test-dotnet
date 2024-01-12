namespace Mc2.CrudTest.AcceptanceTests.Then;

[Binding]
public class IWillSeeException
{
    [Then(@"I will see the exception with the following info")]
    public void ThenIWillSeeTheExceptionWithTheFollowingInfo(Table table)
    {
        ScenarioContext.StepIsPending();
    }
}