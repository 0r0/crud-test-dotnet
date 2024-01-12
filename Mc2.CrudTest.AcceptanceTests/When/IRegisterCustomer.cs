using Mc2.CrudTest.AcceptanceTests.ScreenPlay.CustomerManager.Commands;
using Mc2.CrudTest.AcceptanceTests.Shared;
using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest.Screenplay.Questions;

namespace Mc2.CrudTest.AcceptanceTests.When;

[Binding]
public class IRegisterCustomer
{
    private readonly ScenarioContext _context;
    private readonly ICommandBus _commandBus;
    private readonly Actor _actor;

    public IRegisterCustomer(ScenarioContext context, ICommandBus commandBus, Stage stage)
    {
        _context = context;
        _commandBus = commandBus;
        _actor = stage.ActorInTheSpotlight;
    }

    [When(@"I register customer with following properties")]
    public void WhenIRegisterCustomerWithFollowingProperties(DefineCustomerManagerCommand command)
    {
        _commandBus.Dispatch(command);
        command.Id = _actor.AsksFor(LastResponse.Content<Guid>());
        _context.Set(command);
        _context.Set(command.Id, command.FirstName);
    }
}