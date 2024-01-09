﻿namespace Mc2.CrudTest.Presentation.Shared.AggregateRootFactory;

/// <summary>
/// stream events convention {aggregateType}-{aggregateId}
/// </summary>
public interface IAggregateRootFactory
{
    public T Create<T>(IReadOnlyCollection<DomainEvent> events) where T : IAggregateRoot;
}