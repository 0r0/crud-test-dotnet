// using Autofac;
//
// namespace Mc2.CrudTest.Presentation.Shared
// {
//     public class AutofacCommandHandlerFactory : ICommandHandlerFactory
//     {
//         private readonly IComponentContext _context;
//         public AutofacCommandHandlerFactory(IComponentContext context)
//         {
//             _context = context;
//         }
//
//         public CommandHandlerContainer<T> CreateHandlers<T>(T command)
//         {
//             var handlers = _context.Resolve<ICommandHandler<T>>();
//             return new CommandHandlerContainer<T>(new List<ICommandHandler<T>> { handlers });
//         }
//     }
// }
