using Models;

namespace Technical.Rest.Questions;

public class LastMakingPaymentResponseApi : Shared.Questions.LastMakingPaymentResponse
{
	#region Static Member(s)
	public static LastMakingPaymentResponseApi LastMakingPaymentResponse
	{
		get
		{
			return new LastMakingPaymentResponseApi();
		}
	}
	#endregion /Static Member(s)

	#region Constructor(s)
	public LastMakingPaymentResponseApi() : base()
	{
	}
	#endregion /Constructor(s)

	#region Execute()
	public override
		Shared.Infrastructure.Result<PaymentResponse>
		Execute
		(long transactionId, Suzianna.Core.Screenplay.Actors.Actor actor)
	{
		var path = $"Users/Payment/{transactionId}";

		var task = Suzianna.Rest.Screenplay
			.Interactions.Get.ResourceAt(resource: path);

		actor.AttemptsTo(tasks: task);

		var question =
			Suzianna.Rest.Screenplay.Questions.LastResponse
			.Content<Shared.Infrastructure.Result<PaymentResponse>>();

		var result =
			actor.AsksFor(question: question);

		return result;
	}
	#endregion /Execute()
}

