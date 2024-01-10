using Mc2.Application.Contracts.CustomerManagers;
using Mc2.CrudTest.Presentation.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerManagerController : ControllerBase
{
    private readonly ICommandBus _commandBus;

    public CustomerManagerController(ICommandBus commandBus)
    {
        _commandBus = commandBus;
    }

    [HttpPost]
    public IActionResult Post(DefineCustomerCommand command)
    {
        _commandBus.Dispatch(command);
        return Created("", command.Id);
    }

    [HttpPut("{id:guid}")]
    public IActionResult Put(Guid id, ModifyCustomerCommand command)
    {
        _commandBus.Dispatch(command);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var command = new RemoveCustomerCommand()
        {
            Id = id
        };

        _commandBus.Dispatch(command);
        return NoContent();
    }
}