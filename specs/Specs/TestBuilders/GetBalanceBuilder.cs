namespace Specs.TestBuilders;

public class GetBalanceBuilder : object
{
	#region Static Member(s)
	public static GetBalanceBuilder Create()
	{
		var returnValue =
			new GetBalanceBuilder();

		return returnValue;
	}
	#endregion /Static Member(s)

	#region Constructor(s)
	private GetBalanceBuilder() : base()
	{
		IP =
			Constants.Helpers.Actor.Dariush.IP;

		CellPhoneNumber =
			Constants.Helpers.Actor.Dariush.CellPhoneNumber;

		WalletToken =
			Constants.Helpers.Wallet.Hit.Token;

		CompanyToken =
			Constants.Helpers.Company.Hit.Token;
	}
	#endregion /Constructor(s)

	#region Method(s)

	public GetBalanceBuilder
		MapUserInformation(Models.Entities.User? user)
	{
		if (user == null)
		{
			return this;
		}

		IP = user.IP;

		CellPhoneNumber = user.CellPhoneNumber;

		return this;
	}

	public GetBalanceBuilder WithUserIP(string userIP)
	{
		IP = userIP;

		return this;
	}

	public GetBalanceBuilder WithCellPhoneNumber(string cellPhoneNumber)
	{
		CellPhoneNumber = cellPhoneNumber;

		return this;
	}


	public GetBalanceBuilder WithWalletToken(System.Guid token)
	{
		WalletToken = token;

		return this;
	}

	public GetBalanceBuilder WithCompanyToken(System.Guid token)
	{
		CompanyToken = token;

		return this;
	}
	#endregion /Method(s)

	#region Property(ies)
	public string IP { get; private set; }

	public string CellPhoneNumber { get; private set; }

	public System.Guid CompanyToken { get; private set; }

	public System.Guid WalletToken { get; private set; }
	#endregion /Property(ies)

	#region Build()
	public Models.GetBalanceRequest Build()
	{
		var user =
			new  Models.GetBalanceRequestUser()
			{
				IP = IP,

				CellPhoneNumber = CellPhoneNumber,
			};

		var result =
			new Models.GetBalanceRequest()
			{
				User = user,
				WalletToken = WalletToken,
				CompanyToken = CompanyToken,
			};

		return result;
	}
	#endregion /Build()
}
