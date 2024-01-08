using Mc2.CrudTest.Presentation.Shared;

namespace Mc2.Domain.Contracts.CustomerManagers;

public class CustomerId :ValueObject
{
    public CustomerId(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}