namespace Shared.Questions;

public abstract class LastBalance : object,
	Suzianna.Core.Screenplay.Questions.IQuestion<Infrastructure.Result<Models.GetBalanceResponse>>
{
	public LastBalance() : base()
	{
	}

	public Infrastructure.Result<Models.GetBalanceResponse>
		AnsweredBy(Suzianna.Core.Screenplay.Actors.Actor actor)
	{
		var result =
			actor.Recall<Infrastructure.Result<Models.GetBalanceResponse>>
			(key: Constants.Keys.Balance.GetBalanceId);

		return result;
	}

	public abstract
		Infrastructure.Result<Models.GetBalanceResponse>
		Execute
		(Models.GetBalanceRequest request,
		Suzianna.Core.Screenplay.Actors.Actor actor);
}
