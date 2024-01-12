using Suzianna.Rest;

namespace Mc2.CrudTest.AcceptanceTests.Hooks;

public class CustomHttpRequestSender : IHttpRequestSender
{
    private static readonly HttpClient Client;

    static CustomHttpRequestSender()
    {
        Client = new HttpClient();
    }

    public HttpResponseMessage Send(HttpRequestMessage message)
    {
        message.Headers.Add("X-DateTime", new List<string> { DateTimeProvider.Now.ToShortDateString() });
        message.Headers.Add("X-SyncExecutionMode", new List<string> { $"{true}" });

        return Client.SendAsync(message).GetAwaiter().GetResult();
    }
}