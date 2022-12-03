namespace Models;

public class DepositeRequestUser : object
{
	#region Constructor
	public DepositeRequestUser() : base()
	{
		IP = string.Empty;
		DisplayName = string.Empty;
		CellPhoneNumber = string.Empty;
	}
	#endregion /Constructor

	#region Properties

	public string IP { get; set; }

	public string DisplayName { get; set; }

	public string CellPhoneNumber { get; set; }

	public string? EmailAddress { get; set; }

	public string? NationalCode { get; set; }

	public string? AdditionalData { get; set; }

	public bool PaymentFeatureIsEnabled { get; set; }

	public bool DepositeFeatureIsEnabled { get; set; }

	public bool WithdrawFeatureIsEnabled { get; set; }

	public bool TransferFeatureIsEnabled { get; set; }

	#endregion /Properties
}
