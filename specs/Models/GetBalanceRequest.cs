namespace Models;

public class GetBalanceRequest : object
{
	#region Constructor
	public GetBalanceRequest() : base()
	{
		User = new();
	}
	#endregion /Constructor

	#region Properties

	public GetBalanceRequestUser User { get; set; }

	public System.Guid WalletToken { get; set; }

	public System.Guid CompanyToken { get; set; }


	#endregion /Properties
}
