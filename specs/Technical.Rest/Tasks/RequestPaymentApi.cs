using Models;

namespace Technical.Rest.Tasks;

public class RequestPaymentApi : Shared.Tasks.RequestPayment
{
	public RequestPaymentApi
		(PaymentRequest request) : base(request: request)
	{
	}

	protected override
		Shared.Infrastructure.Result
		<PaymentResponse> Execute<T>(T actor)
	{
		var task =
			Suzianna.Rest.Screenplay.Interactions.Post.DataAsJson(content: Request)
			.To("Users/Payment");

		actor.AttemptsTo(tasks: task);

		var question =
			Suzianna.Rest.Screenplay.Questions.LastResponse.Content
			<Shared.Infrastructure.Result<PaymentResponse>>();

		var result =
			actor.AsksFor
			(question: question);

		return result;
	}
}
