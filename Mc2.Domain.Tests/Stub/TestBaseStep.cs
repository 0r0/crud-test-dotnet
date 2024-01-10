using FluentAssertions;
using Mc2.CrudTest.Presentation.Shared;
using Mc2.CrudTest.Presentation.Shared.AggregateRootFactory;

namespace Mc2.Domain.Tests.Stub;

public class TestBaseStep
{
    protected Exception Exception;

    protected TestBaseStep()
    {
    }

    protected TAggregate CreateFromEvents<TAggregate, TKey>(params DomainEvent[] events)
        where TAggregate : AggregateRoot<TKey>
    {
        return new AggregateRootFactory().Create<TAggregate>(events.ToList());
    }

    public void MustThrowExceptionAs<TException>() where TException : Exception
    {
        Exception.Should().BeOfType(typeof(TException));
    }

    public void MustThrowExceptionAs<TException>(string code) where TException : Exception
    {
        Exception.Should().BeOfType(typeof(TException));
        Exception.ToString().Should().Be(code);
    }

    protected void MustThrowException(string code, string message)
    {
        var expected = Exception.ToString().Replace('_', '-');
        var actual = string.Concat(code.Skip(3));
        expected.Should().Be(actual);
    }

    public void MustThrowExceptionAs<TException>(Enum errorCode) where TException : Exception
    {
        Exception.Should().BeOfType(typeof(TException));
        Exception.GetType().GetProperty("ErrorCode")
            .GetValue(Exception).Should().BeEquivalentTo(errorCode);
    }
}