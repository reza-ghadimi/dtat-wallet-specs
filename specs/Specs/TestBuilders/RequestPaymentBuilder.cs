namespace Specs.TestBuilders;

internal class RequestPaymentBuilder : object
{
	#region Static Member(s)
	public static RequestPaymentBuilder Create()
	{
		var returnValue =
			new RequestPaymentBuilder();

		return returnValue;
	}
	#endregion /Static Member(s)

	#region Method(s
	public RequestPaymentBuilder
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

	public RequestPaymentBuilder WithUserIP(string userIP)
	{
		IP = userIP;

		return this;
	}

	public RequestPaymentBuilder
		WithCellPhoneNumber(string cellPhoneNumber)
	{
		CellPhoneNumber = cellPhoneNumber;

		return this;
	}

	public RequestPaymentBuilder WithAmount(decimal amount)
	{
		Amount = amount;

		return this;
	}

	public RequestPaymentBuilder
		WithReferenceCode(string referenceCode)
	{
		ReferenceCode = referenceCode;

		return this;
	}

	public RequestPaymentBuilder
		WithWalletToken(System.Guid walletToken)
	{
		WalletToken = walletToken;

		return this;
	}

	public RequestPaymentBuilder
		WithCompanyToken(System.Guid companyToken)
	{
		CompanyToken = companyToken;

		return this;
	}

	public RequestPaymentBuilder
		WithUserDescription(string userDescription)
	{
		UserDescription = userDescription;

		return this;
	}

	public RequestPaymentBuilder
		WithSystemicDescription(string systemicDescription)
	{
		SystemicDescription = systemicDescription;

		return this;
	}

	public RequestPaymentBuilder
		WithAdditionalData(string additionalData)
	{
		AdditionalData = additionalData;

		return this;
	}
	#endregion /Method(s)

	#region Constructor(s)
	private RequestPaymentBuilder() : base()
	{
		Amount = 100_000;

		IP =
			Constants.Helpers.Actor.Dariush.IP;

		CellPhoneNumber =
			Constants.Helpers.Actor.Dariush.CellPhoneNumber;

		ReferenceCode =
			System.Guid.NewGuid().ToString();

		WalletToken =
			Constants.Helpers.Wallet.Hit.Token;

		CompanyToken =
			Constants.Helpers.Company.Hit.Token;
	}
	#endregion /Constructor(s)

	#region Property(ies)
	public string IP { get; private set; }

	public string CellPhoneNumber { get; private set; }

	public decimal Amount { get; private set; }

	public System.Guid WalletToken { get; private set; }

	public System.Guid CompanyToken { get; private set; }

	public string ReferenceCode { get; private set; }

	public string? UserDescription { get; private set; }

	public string? SystemicDescription { get; private set; }

	public string? AdditionalData { get; private set; }
	#endregion /Property(ies)

	#region Build()
	public Models.PaymentRequest Build()
	{
		var user =
			new Models.PaymentRequestUser()
			{
				IP = IP,

				CellPhoneNumber = CellPhoneNumber,
			};

		var paymentRequest = new Models.PaymentRequest()
		{
			User = user,
			Amount = Amount,
			WaletToken = WalletToken,
			CompanyToken = CompanyToken,
			ReferenceCode = ReferenceCode,
			AdditionalData = AdditionalData,
			UserDescription = UserDescription,
			SystemicDescription = SystemicDescription,
		};

		return paymentRequest;
	}
	#endregion /Build()
}
