namespace Specs.Screenplay.Tasks;

public static class Get : object
{
	static Get()
	{
	}

	public static
		Suzianna.Core.Screenplay.ITask?
		Balance(Models.GetBalanceRequest request)
	{
		var result =
			Factory.CreateTask<Shared.Tasks.GetBalance>
			(parameters: request);

		return result;
	}
}

