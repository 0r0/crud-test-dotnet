using System.Diagnostics.CodeAnalysis;

namespace Mc2.CrudTest.Presentation.Server.Handlers;

public interface IServiceRegistryLifetimeScope : IDisposable, IAsyncDisposable
{
    IServiceRegistryLifetimeScope BeginLifetimeScope();
    object Resolve(Type serviceType);
    T Resolve<T>();
    bool TryResolve(Type serviceType, [NotNullWhen(returnValue: true)] out object? instance);
}