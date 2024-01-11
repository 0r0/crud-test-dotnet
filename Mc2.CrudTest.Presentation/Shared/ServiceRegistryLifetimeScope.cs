using Autofac;

namespace Mc2.CrudTest.Presentation.Server.Handlers
{
    public class ServiceRegistryLifetimeScope : IServiceRegistryLifetimeScope
    {
        private readonly ILifetimeScope _scope;
        private bool _isDisposed;

        public ServiceRegistryLifetimeScope(ILifetimeScope lifetimeScope)
        {
            _scope = lifetimeScope;
        }

        public IServiceRegistryLifetimeScope BeginLifetimeScope()
        {
            CheckNotDisposed();
            return new ServiceRegistryLifetimeScope(_scope.BeginLifetimeScope());
        }

        public object Resolve(Type serviceType)
        {
            CheckNotDisposed();
            return _scope.Resolve(serviceType);
        }

        public T Resolve<T>()
        {
            CheckNotDisposed();
            return _scope.Resolve<T>();
        }

        public bool TryResolve(Type serviceType, out object? instance)
        {
            return _scope.TryResolve(serviceType, out instance);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsync(true);
        }

        private void CheckNotDisposed()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException("LifetimeScopeResources.", innerException: null);
            }
        }

        private void Dispose(bool disposing)
        {
            if (!disposing) return;
            _scope.Dispose();
            _isDisposed = true;
        }

        private async Task DisposeAsync(bool disposing)
        {
            if (disposing)
            {
                await _scope.DisposeAsync();
                _isDisposed = true;
            }
        }
    }
}