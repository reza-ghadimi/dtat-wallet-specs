using Models;

namespace Technical.Rest.Tasks;

public class RequestDepositeApi : Shared.Tasks.RequestDeposite
{
	public RequestDepositeApi
		(DepositeRequest request) : base(request: request)
	{
	}

	protected override
		Shared.Infrastructure.Result
		<DepositeResponse> Execute<T>(T actor)
	{
		var task =
			Suzianna.Rest.Screenplay.Interactions.Post.DataAsJson(content: Request)
			.To("Users/Deposite");

		actor.AttemptsTo(tasks: task);

		var question =
			Suzianna.Rest.Screenplay.Questions.LastResponse.Content
			<Shared.Infrastructure.Result<DepositeResponse>>();

		var result =
			actor.AsksFor
			(question: question);

		return result;
	}
}
