using Mc2.CrudTest.AcceptanceTests.ScreenPlay.CustomerManager.Commands;
using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest.Screenplay.Interactions;

namespace Mc2.CrudTest.AcceptanceTests.ScreenPlay.CustomerManager.RestApiTask;

public class RemoveCustomerRestApiTask : ITask
{
    private readonly RemoveCustomerManagerCommand _command;

    public RemoveCustomerRestApiTask(RemoveCustomerManagerCommand command)
    {
        _command = command;
    }

    public void PerformAs<T>(T actor) where T : Actor
    {
        actor.AttemptsTo(Delete.From($"/api/customer/{_command.Id}"));
    }
}