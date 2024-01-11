using Mc2.CrudTest.Presentation.Shared;
using Mc2.Query.Contracts.Requests;
using Mc2.Query.Contracts.Responses;
using Neo4jClient;
using Neo4jClient.Cypher;

namespace Mc2.Query.CustomerManagers;

public class CustomerQueryHandlers : IQueryHandler<GetCustomerById, CustomerResponse>,
    IQueryHandler<GetAllCustomers, IReadOnlyCollection<CustomerResponse>>,
    IQueryHandler<IsSameEmailExist, bool>,
    IQueryHandler<IsCustomerWithSameFirstNameLastNameAndBirthDateExist, bool>
{
    private readonly GraphClient _client;

    public CustomerQueryHandlers(GraphClient client)
    {
        _client = client;
        _client.ConnectAsync().GetAwaiter().GetResult();
    }

    public CustomerResponse Handle(GetCustomerById query)
    {
        var result = _client.Cypher.Match("(c:Customer)")
            .Where("c.Id = $id")
            .WithParam("id", query.Id.Id.ToString())
            .Return(() => new
            {
                Customer = Return.As<CustomerResponse>("c")
            }).ResultsAsync.Result.FirstOrDefault();
        return result?.Customer;
    }

    public IReadOnlyCollection<CustomerResponse> Handle(GetAllCustomers query)
    {
        var result = _client.Cypher.Match("(c:Customer)")
            .Return(() => new
            {
                Customer = Return.As<CustomerResponse>("c")
            }).ResultsAsync.Result.ToList();
        if (!result.Any()) return new List<CustomerResponse>();
        return result.Select(a => a.Customer).ToList().AsReadOnly();
    }

    public bool Handle(IsSameEmailExist query)
    {
        return _client.Cypher.Match("(c:Customer)")
                   .Where("c.Id <> $id ")
                   .AndWhere("c.Email = $email")
                   .WithParams(new
                   {
                       id = query.Id.Id.ToString(),
                       email = query.Email
                   })
                   .Return<bool?>("CASE WHEN c IS NULL RETURN FALSE ELSE TRUE END").ResultsAsync.Result
                   .FirstOrDefault() ??
               false;
    }

    public bool Handle(IsCustomerWithSameFirstNameLastNameAndBirthDateExist query)
    {
        return _client.Cypher.Match("(c:Customer)")
            .Where("c.Id <> $id ")
            .AndWhere("c.FirstName = $firstName")
            .AndWhere("c.LastName = $lastName")
            .AndWhere("c.DateOfBirth = $dateOfBirth")
            .WithParams(new
            {
                id = query.Id.Id.ToString(),
                firstName = query.FirstName,
                lastName = query.LastName,
                dateOfBirth = query.DateOfBirth
            })
            .Return<bool?>("CASE WHEN c IS NULL RETURN FALSE ELSE TRUE END").ResultsAsync.Result
            .FirstOrDefault() ?? false;
    }
}