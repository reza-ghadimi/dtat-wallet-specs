using Models;

namespace Technical.Rest.Questions;

public class LastRequestDepositeResponseApi : Shared.Questions.LastRequestDepositeResponse
{
	#region Static Member(s)
	public static LastRequestDepositeResponseApi LastRequestDepositeResponse
	{
		get
		{
			return new LastRequestDepositeResponseApi();
		}
	}
	#endregion /Static Member(s)

	#region Constructor(s)
	public LastRequestDepositeResponseApi() : base()
	{
	}
	#endregion /Constructor(s)

	#region Execute()
	public override
		Shared.Infrastructure.Result
		<DepositeResponse>
		Execute
		(long transactionId, Suzianna.Core.Screenplay.Actors.Actor actor)
	{
		var path = $"Users/Deposite/{transactionId}";

		var task = Suzianna.Rest.Screenplay
			.Interactions.Get.ResourceAt(resource: path);

		actor.AttemptsTo(tasks: task);

		var question =
			Suzianna.Rest.Screenplay.Questions.LastResponse
			.Content<Shared.Infrastructure.Result<DepositeResponse>>();

		var result =
			actor.AsksFor(question: question);

		return result;
	}
	#endregion /Execute()
}

