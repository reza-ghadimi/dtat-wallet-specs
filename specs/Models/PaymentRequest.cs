namespace Models;

public class PaymentRequest : object
{
	#region Constructor
	public PaymentRequest() : base()
	{
		User = new();

		ReferenceCode = string.Empty;
	}
	#endregion /Constructor

	#region Properties

	public PaymentRequestUser User { get; set; }

	public decimal Amount { get; set; }

	public System.Guid WalletToken { get; set; }

	public System.Guid CompanyToken { get; set; }

	public string ReferenceCode { get; set; }

	public string? UserDescription { get; set; }

	public string? SystemicDescription { get; set; }

	public string? AdditionalData { get; set; }

	#endregion /Properties
}
