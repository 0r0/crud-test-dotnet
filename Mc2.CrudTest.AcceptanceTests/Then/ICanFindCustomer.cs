using FluentAssertions;
using Mc2.CrudTest.AcceptanceTests.ScreenPlay.CustomerManager.Commands;
using Mc2.CrudTest.AcceptanceTests.ScreenPlay.CustomerManager.Requests;
using Mc2.CrudTest.AcceptanceTests.When;
using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;

namespace Mc2.CrudTest.AcceptanceTests.Then;

[Binding]
public class ICanFindCustomer
{
    private readonly ScenarioContext _context;
    private readonly Actor _actor;

    public ICanFindCustomer(ScenarioContext context, Stage stage)
    {
        _context = context;
        _actor = stage.ActorInTheSpotlight;
    }

    [Then(@"I can find a customer with above info")]
    public void ThenICanFindACustomerWithAboveInfo()
    {
        if (_context.ContainsKey(typeof(ModifyCustomerManagerCommand).ToString()))
            Modify();
        else
            Define();
    }

    private void Define()
    {
        var expected = _context.Get<DefineCustomerManagerCommand>();
        var actual = _actor.AsksFor(new GetCustomerByIdQuestion(expected.Id));
        actual.Should().BeEquivalentTo(expected);
    }

    private void Modify()
    {
        throw new NotImplementedException();
    }
}