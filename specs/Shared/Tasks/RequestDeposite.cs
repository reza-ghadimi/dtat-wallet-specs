namespace Shared.Tasks;

public abstract class RequestDeposite : object, Suzianna.Core.Screenplay.ITask
{
	public RequestDeposite(Models.DepositeRequest request) : base()
	{
		Request = request;
	}

	protected Models.DepositeRequest Request { get; }

	public void PerformAs<T>(T actor)
		where T : Suzianna.Core.Screenplay.Actors.Actor
	{
		var depositeResult =
			Execute(actor: actor);

		actor.Remember
			(key: Constants.Keys.Deposite.DepositeTransactionId,
			value: depositeResult);
	}

	protected abstract
		Infrastructure.Result<Models.DepositeResponse>
		Execute<T>(T actor)
		where T : Suzianna.Core.Screenplay.Actors.Actor;
}
