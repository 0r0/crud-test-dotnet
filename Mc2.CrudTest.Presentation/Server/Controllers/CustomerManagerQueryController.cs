using Mc2.CrudTest.Presentation.Shared;
using Mc2.Domain.Contracts.CustomerManagers;
using Mc2.Query.Contracts.Requests;
using Mc2.Query.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerManagerQueryController : ControllerBase
{
    private readonly IQueryBus _queryBus;

    public CustomerManagerQueryController(IQueryBus queryBus)
    {
        _queryBus = queryBus;
    }

    [HttpGet]
    public IReadOnlyCollection<CustomerResponse> Get()
    {
        return _queryBus.Execute<GetAllCustomers, IReadOnlyCollection<CustomerResponse>>(new GetAllCustomers());
    }

    [HttpGet("{id:guid}")]
    public CustomerResponse Get(Guid id)
    {
        return _queryBus.Execute<GetCustomerById, CustomerResponse>(new GetCustomerById(new CustomerId(id)));
    }
}