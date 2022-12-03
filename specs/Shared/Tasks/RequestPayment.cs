namespace Shared.Tasks;

public abstract class RequestPayment : object, Suzianna.Core.Screenplay.ITask
{
	public RequestPayment(Models.PaymentRequest request) : base()
	{
		Request = request;
	}

	protected Models.PaymentRequest Request { get; }

	public void PerformAs<T>(T actor)
		where T : Suzianna.Core.Screenplay.Actors.Actor
	{
		var paymentResult =
			Execute(actor: actor);

		actor.Remember
			(key: Constants.Keys.Payment.PaymentTransactionId,
			value: paymentResult);
	}

	protected abstract
		Infrastructure.Result<Models.PaymentResponse>
		Execute<T>(T actor)
		where T : Suzianna.Core.Screenplay.Actors.Actor;
}
