using Mc2.CrudTest.AcceptanceTests.ScreenPlay.CustomerManager.Responses;
using Suzianna.Core.Screenplay.Actors;
using Suzianna.Core.Screenplay.Questions;
using Suzianna.Rest.Screenplay.Interactions;
using Suzianna.Rest.Screenplay.Questions;

namespace Mc2.CrudTest.AcceptanceTests.ScreenPlay.CustomerManager.Requests;

public class GetCustomerByIdQuestion : IQuestion<CustomerResponse>
{
    private Guid Id { get; }

    public GetCustomerByIdQuestion(Guid id)
    {
        Id = id;
    }

    public CustomerResponse AnsweredBy(Actor actor)
    {
        actor.AttemptsTo(Get.ResourceAt($"/api/customerManagerQuery/{Id}"));
        return actor.AsksFor(LastResponse.Content<CustomerResponse>());
    }
}