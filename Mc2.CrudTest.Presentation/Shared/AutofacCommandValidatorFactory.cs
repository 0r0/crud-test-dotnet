// using Arius.Application.Contracts.CommandValidations;
// using Autofac;
//
// namespace Arius.Config.Autofac
// {
//     public class AutofacCommandValidatorFactory : ICommandValidatorFactory
//     {
//         readonly ILifetimeScope _lifetimeScope;
//
//         public AutofacCommandValidatorFactory(ILifetimeScope lifetimeScope)
//         {
//             _lifetimeScope = lifetimeScope;
//         }
//
//         public ICommandValidator<T> CreateValidator<T>()
//         {
//             return _lifetimeScope.IsRegistered<ICommandValidator<T>>() 
//                 ? _lifetimeScope.Resolve<ICommandValidator<T>>() : null;
//         }
//     }
// }