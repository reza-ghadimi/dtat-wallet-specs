namespace Models;

public class GetBalanceRequestUser : object
{
	#region Constructor
	public GetBalanceRequestUser() : base()
	{
		CellPhoneNumber = string.Empty;
	}
	#endregion /Constructor

	#region Properties

	public string? IP { get; set; }

	public string CellPhoneNumber { get; set; }

	#endregion /Properties
}