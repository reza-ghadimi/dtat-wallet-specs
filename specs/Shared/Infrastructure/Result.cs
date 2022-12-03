namespace Shared.Infrastructure;

public class Result : object
{
	public Result() : base()
	{
		ErrorMessages =
			new System.Collections.Generic.List<string>();

		SuccessMessages =
			new System.Collections.Generic.List<string>();
	}

	public bool IsSuccess { get; set; }

	public System.Collections.Generic.IList<string> ErrorMessages { get; set; }

	public System.Collections.Generic.IList<string> SuccessMessages { get; set; }
}

public class Result<T> : Result
{
	public Result() : base()
	{
	}

	public T? Data { get; set; }
}
