using Models;

namespace Technical.Rest.Tasks;

public class GetBalanceApi : Shared.Tasks.GetBalance
{
	public GetBalanceApi
		(GetBalanceRequest request) : base(request: request)
	{
	}

	protected override
		Shared.Infrastructure.Result<Models.GetBalanceResponse> Execute<T>(T actor)
	{
		var task =
			Suzianna.Rest.Screenplay.Interactions.Post.DataAsJson(content: Request)
			.To("Users/GetBalance");

		actor.AttemptsTo(tasks: task);

		var question =
			Suzianna.Rest.Screenplay.Questions.LastResponse.Content
			<Shared.Infrastructure.Result<Models.GetBalanceResponse>>();

		var result =
			actor.AsksFor
			(question: question);

		return result;
	}
}
