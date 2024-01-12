using Mc2.CrudTest.AcceptanceTests.ScreenPlay.CustomerManager.Commands;
using Suzianna.Core.Screenplay;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Rest.Screenplay.Interactions;

namespace Mc2.CrudTest.AcceptanceTests.ScreenPlay.CustomerManager.RestApiTask;

public class DefineCustomerRestApiTask : ITask
{
    private readonly DefineCustomerManagerCommand _command;

    public DefineCustomerRestApiTask(DefineCustomerManagerCommand command)
    {
        _command = command;
    }

    public void PerformAs<T>(T actor) where T : Actor
        => actor.AttemptsTo(Post.DataAsJson(_command).To("/api/customer"));
}