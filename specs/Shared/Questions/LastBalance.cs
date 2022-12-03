namespace Shared.Questions;

public abstract class LastBalance : object,
	Suzianna.Core.Screenplay.Questions.IQuestion<Infrastructure.Result<decimal?>>
{
	public LastBalance() : base()
	{
	}

	public Infrastructure.Result<decimal?>
		AnsweredBy(Suzianna.Core.Screenplay.Actors.Actor actor)
	{
		var result =
			actor.Recall<Infrastructure.Result<decimal?>>
			(key: Constants.Keys.Balance.GetBalanceId);

		return result;
	}

	public abstract
		Infrastructure.Result<decimal>
		Execute
		(Models.GetBalanceRequest request,
		Suzianna.Core.Screenplay.Actors.Actor actor);
}
