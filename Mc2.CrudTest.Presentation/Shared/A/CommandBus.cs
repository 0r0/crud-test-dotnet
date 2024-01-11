// using System;
// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using Arius.Application.Contracts;
// using Arius.Application.Contracts.Exceptions;
// using Arius.Core;
// using Mc2.CrudTest.Presentation.Shared;
// using Microsoft.Extensions.Logging;
//
// namespace Arius.Application
// {
//     public class CommandBus : ICommandBus
//     {
//         private readonly ICommandHandlerFactory _commandHandlerFactory;
//         
//         public CommandBus(ICommandHandlerFactory commandHandlerFactory)
//         {
//             _commandHandlerFactory = commandHandlerFactory ?? throw new ArgumentNullException(nameof(commandHandlerFactory));
//             
//         }
//
//         public async Task Dispatch<T>(T command)
//         {
//             // TODO: Command handler of a specific command must be individual instead of being a list of handlers
//             using (var container = _commandHandlerFactory.CreateHandlers(command))
//             {
//                 foreach (var handler in container.Handlers)
//                 {
//                     await handler.Handle(command).ConfigureAwait(false);
//                 }
//             }
//         }
//     }
// }
