using Autofac;
using BoDi;
using Neo4jClient;
using SpecFlow.Autofac;

namespace Mc2.CrudTest.AcceptanceTests.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _container;

        [ScenarioDependencies]
        public static ContainerBuilder CreateContainerBuilder()
        {
            var builder = Dependencies.CreateContainerBuilder();

            builder.RegisterTypes(typeof(Hooks).Assembly.GetTypes()
                .Where(t => Attribute.IsDefined(t, typeof(BindingAttribute)))
                .ToArray()).InstancePerLifetimeScope();
            return builder;
        }

        [BeforeScenario(Order = 0)]
        public void CleanUpReadModel()
        {
            var client = new GraphClient(new Uri("http://neo4j:Mehdi@localhost:7474"))
            {
                DefaultDatabase = "neo4j"
            };

            client.ConnectAsync().Wait();
            client.Cypher.Match("(n)")
                .DetachDelete("n")
                .ExecuteWithoutResultsAsync()
                .GetAwaiter()
                .GetResult();
        }
    }
}