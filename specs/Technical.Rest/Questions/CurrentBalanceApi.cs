using Models;

namespace Technical.Rest.Questions;

public class CurrentBalanceApi : Shared.Questions.LastBalance
{
	#region Static Member(s)
	public static CurrentBalanceApi CurrentBalance
	{
		get
		{
			return new CurrentBalanceApi();
		}
	}
	#endregion /Static Member(s)

	#region Constructor(s)
	private CurrentBalanceApi() : base()
	{
	}
	#endregion /Constructor(s)

	#region Execute()
	public override Shared.Infrastructure.Result<decimal>
		Execute
		(GetBalanceRequest request,
		Suzianna.Core.Screenplay.Actors.Actor actor)
	{
		var path = $"Users/GetBalance";

		var task = Suzianna.Rest.Screenplay
			.Interactions.Get.ResourceAt(resource: path);

		actor.AttemptsTo(tasks: task);

		var question =
			Suzianna.Rest.Screenplay.Questions.LastResponse
			.Content<Shared.Infrastructure.Result<decimal>>();

		var result =
			actor.AsksFor(question: question);

		return result;
	}
	#endregion /Execute()
}

