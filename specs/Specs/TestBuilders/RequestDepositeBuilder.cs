namespace Specs.TestBuilders;

internal class RequestDepositeBuilder : object
{
	#region Static Member(s)
	public static RequestDepositeBuilder Create()
	{
		var returnValue =
			new RequestDepositeBuilder();

		return returnValue;
	}
	#endregion /Static Member(s)

	#region Constructor(s)
	public RequestDepositeBuilder() : base()
	{
		Amount = 100_000;

		PaymentFeatureIsEnabled = true;

		DepositeFeatureIsEnabled = true;

		WithdrawFeatureIsEnabled = true;

		TransferFeatureIsEnabled = true;

		UserAdditionalData = string.Empty;

		IP =
			Constants.Helpers.Actor.Dariush.IP;

		DisplayName =
			Constants.Helpers.Actor.Dariush.DisplayName;

		NationalCode =
			Constants.Helpers.Actor.Dariush.NationalCode;

		EmailAddress =
			Constants.Helpers.Actor.Dariush.EmailAddress;

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

	#region Method(s)

	#region User

	public RequestDepositeBuilder
		MapUserInformation(Models.Entities.User? user)
	{
		if (user == null)
		{
			return this;
		}

		IP = user.IP;
		DisplayName = user.DisplayName;
		NationalCode = user.NationalCode;
		EmailAddress = user.EmailAddress;
		CellPhoneNumber = user.CellPhoneNumber;

		return this;
	}

	public RequestDepositeBuilder WithUserIP(string userIP)
	{
		IP = userIP;

		return this;
	}

	public RequestDepositeBuilder WithDisplayName(string displayName)
	{
		DisplayName = displayName;

		return this;
	}

	public RequestDepositeBuilder WithEmailAddress(string emailAddress)
	{
		EmailAddress = emailAddress;

		return this;
	}

	public RequestDepositeBuilder WithNationalCode(string nationalCode)
	{
		NationalCode = nationalCode;

		return this;
	}

	public RequestDepositeBuilder WithUserDescription(string description)
	{
		UserDescription = description;

		return this;
	}

	public RequestDepositeBuilder WithCellPhoneNumber(string cellPhoneNumber)
	{
		CellPhoneNumber = cellPhoneNumber;

		return this;
	}

	public RequestDepositeBuilder WithUesrAdditionalData(string additionalData)
	{
		UserAdditionalData = additionalData;

		return this;
	}

	public RequestDepositeBuilder HasFeatures
		(bool paymentFeatureIsEnabled = true, bool depositeFeatureIsEnabled = true,
		bool withdrawFeatureIsEnabled = true, bool transferFeatureIsEnabled = true)
	{
		PaymentFeatureIsEnabled = paymentFeatureIsEnabled;

		DepositeFeatureIsEnabled = depositeFeatureIsEnabled;

		WithdrawFeatureIsEnabled = withdrawFeatureIsEnabled;

		TransferFeatureIsEnabled = transferFeatureIsEnabled;

		return this;
	}

	#endregion /User

	public RequestDepositeBuilder WithAmount(decimal amount)
	{
		Amount = amount;

		return this;
	}

	public RequestDepositeBuilder WithReferenceCode(string referenceCode)
	{
		ReferenceCode = referenceCode;

		return this;
	}

	public RequestDepositeBuilder WithWalletToken(System.Guid walletToken)
	{
		WalletToken = walletToken;

		return this;
	}

	public RequestDepositeBuilder WithCompanyToken(System.Guid companyToken)
	{
		CompanyToken = companyToken;

		return this;
	}

	public RequestDepositeBuilder WithSystemicDescription(string systemicDescription)
	{
		SystemicDescription = systemicDescription;

		return this;
	}

	public RequestDepositeBuilder WithAdditionalData(string additionalData)
	{
		AdditionalData = additionalData;

		return this;
	}

	#endregion /Method(s)

	#region Property(ies)

	public decimal Amount { get; private set; }

	public System.Guid WalletToken { get; private set; }

	public System.Guid CompanyToken { get; private set; }

	public string ReferenceCode { get; private set; }

	public string? UserDescription { get; private set; }

	public string? SystemicDescription { get; private set; }

	public string? AdditionalData { get; private set; }

	#region User

	public string IP { get; private set; }

	public string CellPhoneNumber { get; private set; }

	public string DisplayName { get; set; }

	public string? EmailAddress { get; set; }

	public string? NationalCode { get; set; }

	public string? UserAdditionalData { get; set; }

	public bool PaymentFeatureIsEnabled { get; set; }

	public bool DepositeFeatureIsEnabled { get; set; }

	public bool WithdrawFeatureIsEnabled { get; set; }

	public bool TransferFeatureIsEnabled { get; set; }

	#endregion /User

	#endregion /Property(ies)

	#region Build()
	public Models.DepositeRequest Build()
	{
		var user =
			new Models.DepositeRequestUser()
			{
				IP = IP,
				DisplayName = DisplayName,
				EmailAddress = EmailAddress,
				NationalCode = NationalCode,
				CellPhoneNumber = CellPhoneNumber,
				AdditionalData = UserAdditionalData,
				PaymentFeatureIsEnabled = PaymentFeatureIsEnabled,
				WithdrawFeatureIsEnabled = WithdrawFeatureIsEnabled,
				TransferFeatureIsEnabled = TransferFeatureIsEnabled,
				DepositeFeatureIsEnabled = DepositeFeatureIsEnabled,
			};

		var paymentRequest = new Models.DepositeRequest()
		{
			User = user,
			Amount = Amount,
			WalletToken = WalletToken,
			CompanyToken = CompanyToken,
			ReferenceCode = ReferenceCode,
			AdditionalData = AdditionalData,
			UserDescription = UserDescription,
			SystemicDescription = SystemicDescription,
			ProviderName = Constants.Helpers.Provider.Saman,
		};

		return paymentRequest;
	}
	#endregion /Build()
}
