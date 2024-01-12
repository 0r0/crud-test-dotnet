using Autofac;
using Mc2.CrudTest.AcceptanceTests.ScreenPlay.CustomerManager.Commands;
using Mc2.CrudTest.AcceptanceTests.ScreenPlay.CustomerManager.RestApiTask;
using Mc2.CrudTest.AcceptanceTests.Shared;
using Suzianna.Core.Screenplay;
using Suzianna.Rest.Screenplay.Abilities;


namespace Mc2.CrudTest.AcceptanceTests.Hooks;

public static class Dependencies
{
    public static ContainerBuilder CreateContainerBuilder()
    {
        var builder = new ContainerBuilder();
        builder.Register(a =>
        {
            var cast = Cast.WhereEveryoneCan(new List<IAbility>
            {
                CallAnApi.At("http://localhost:5090").With(new CustomHttpRequestSender())
            });

            var stage = new Stage(cast);
            stage.ShineSpotlightOn("Ashly");
            return stage;
        }).InstancePerLifetimeScope();

        builder.RegisterType(typeof(CommandBus))
            .As<ICommandBus>()
            .InstancePerLifetimeScope();
        builder.RegisterCustomerHandlers();
        return builder;
    }

    private static void RegisterCustomerHandlers(this ContainerBuilder containerBuilder)
    {
        containerBuilder.RegisterType<CustomerRestApiCommandHandler>()
            .As<ICommandHandler<DefineCustomerManagerCommand>>().InstancePerLifetimeScope();
        containerBuilder.RegisterType<CustomerRestApiCommandHandler>()
            .As<ICommandHandler<ModifyCustomerManagerCommand>>().InstancePerLifetimeScope();
        containerBuilder.RegisterType<CustomerRestApiCommandHandler>()
            .As<ICommandHandler<RemoveCustomerManagerCommand>>().InstancePerLifetimeScope();
    }
}