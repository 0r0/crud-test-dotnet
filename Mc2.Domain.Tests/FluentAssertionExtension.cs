using FluentAssertions;
using Mc2.CrudTest.Presentation.Shared;

namespace Mc2.Domain.Tests;

public static  class FluentAssertionExtension
{
    public static void ShouldContainsEquivalencyOfDomainEvent<TKey, TExpectation>(
        this AggregateRoot<TKey> aggregate,
        TExpectation expectation,
        string because = null,
        params object[] becauseArgs) where TExpectation : DomainEvent
    {
        aggregate.GetUncommittedEvents().First(z => z.GetType() == expectation.GetType()).Should().NotBeNull();
        aggregate.GetUncommittedEvents().Where(z => z.GetType() == expectation.GetType()).Should().ContainEquivalentOf(
            expectation, opt => opt
                .Excluding(a => a.PublishDateTime)
                .Excluding(a => a.EventId)
                .Excluding(a => a.UserId)
                .Excluding(a => a.Version)
            , because, becauseArgs);
    }
}