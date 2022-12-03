using System;

namespace Specs.Screenplay.Tasks;

public static class DoTransaction : object
{
	static DoTransaction()
	{
	}

	public static
		Suzianna.Core.Screenplay.ITask?
		Deposite(Models.DepositeRequest request)
	{
		var result =
			Factory.CreateTask<Shared.Tasks.RequestDeposite>
			(parameters: request);

		return result;
	}

	public static
		Suzianna.Core.Screenplay.ITask?
		Payment(Models.PaymentRequest request)
	{
		var result =
			Factory.CreateTask<Shared.Tasks.RequestPayment>
			(parameters: request);

		return result;
	}
}

