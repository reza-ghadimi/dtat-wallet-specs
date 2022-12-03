namespace Shared.Questions;

public abstract class LastMakingPaymentResponse : object,
	Suzianna.Core.Screenplay.Questions.IQuestion<Infrastructure.Result<Models.PaymentResponse>>
{
	public LastMakingPaymentResponse() : base()
	{
	}

	public Infrastructure.Result<Models.PaymentResponse>
		AnsweredBy(Suzianna.Core.Screenplay.Actors.Actor actor)
	{
		var result = actor.Recall
			<Infrastructure.Result<Models.PaymentResponse>>
			(key: Constants.Keys.Payment.PaymentTransactionId);

		return result;
	}

	public abstract
		Infrastructure.Result<Models.PaymentResponse>
		Execute
		(long transactionId, Suzianna.Core.Screenplay.Actors.Actor actor);
}
