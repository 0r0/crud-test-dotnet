using Mc2.CrudTest.Presentation.Shared;

namespace Mc2.Domain.Contracts.CustomerManagers;

public class CustomerId :ValueObject
{
    public Guid Id { get; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}