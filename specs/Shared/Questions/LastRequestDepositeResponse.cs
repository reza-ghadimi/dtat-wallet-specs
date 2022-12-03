namespace Shared.Questions;

public abstract class LastRequestDepositeResponse : object,
	Suzianna.Core.Screenplay.Questions.IQuestion<Infrastructure.Result<Models.DepositeResponse>>
{
	public LastRequestDepositeResponse() : base()
	{
	}

	public Infrastructure.Result<Models.DepositeResponse>
		AnsweredBy
		(Suzianna.Core.Screenplay.Actors.Actor actor)
	{
		var result = actor.Recall
			<Infrastructure.Result<Models.DepositeResponse>>
			(key: Constants.Keys.Deposite.DepositeTransactionId);

		return result;
	}

	public abstract
		Infrastructure.Result<Models.DepositeResponse>
		Execute
		(long transactionId, Suzianna.Core.Screenplay.Actors.Actor actor);
}
