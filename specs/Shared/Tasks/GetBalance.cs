namespace Shared.Tasks;

public abstract class GetBalance : object, Suzianna.Core.Screenplay.ITask
{
	public GetBalance(Models.GetBalanceRequest request) : base()
	{
		Request = request;
	}

	protected Models.GetBalanceRequest Request { get; }

	public void PerformAs<T>(T actor)
		where T : Suzianna.Core.Screenplay.Actors.Actor
	{
		var getBalanceResult =
			Execute(actor: actor);

		actor.Remember
			(key: Constants.Keys.Balance.GetBalanceId,
			value: getBalanceResult);
	}

	protected abstract
		Infrastructure.Result<Models.GetBalanceResponse>
		Execute<T>(T actor)
		where T : Suzianna.Core.Screenplay.Actors.Actor;
}
