using Autofac;
using Mc2.CrudTest.AcceptanceTests.Hooks;
using Suzianna.Core.Screenplay;

namespace Mc2.CrudTest.AcceptanceTests.Shared;

public class CommandBus : ICommandBus
{
    private readonly Stage _stage;

    public CommandBus(Stage stage)
    {
        _stage = stage;
    }

    public void Dispatch<T>(T command) where T : ICommand
    {
        var builder = Dependencies.CreateContainerBuilder();
        var container = builder.Build();

        using var scope = container.BeginLifetimeScope();
        var handler = scope.Resolve<ICommandHandler<T>>();
        _stage.ActorInTheSpotlight.AttemptsTo(handler.Handle(command));
    }
}