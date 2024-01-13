using System.Reflection;
using Mc2.Domain.Contracts.CustomerManagers;
using Mc2.Domain.CustomerManagers;

namespace Mc2.Domain.Tests;

public class FunctionalityTest
{
    [Fact]
    public void GetStreamIdWithGuidField()
    {
        var stream = new Stream<CustomerId, Customer>();
        var id = new CustomerId(Guid.NewGuid());
        var streamId = stream.GetStreamId(id);
        Assert.Equal(streamId,id.Id.ToString());
    }
    
}


public class Stream<TKey,T>
{
    public string GetStreamId(TKey id)
    {
      return id.GetType().GetFields(BindingFlags.Public | 
                                                      BindingFlags.NonPublic | 
                                                      BindingFlags.Instance).First().GetValue(id).ToString();
        // return $"{typeof(T).Name}-{id.GetType()}";
    }
}