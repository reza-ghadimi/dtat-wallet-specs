namespace Models;

public class DepositeRequest : object
{
	public DepositeRequest() : base()
	{
	}

	#region Properties

	public DepositeRequestUser? User { get; set; }

	public decimal Amount { get; set; }

	public System.Guid WalletToken { get; set; }

	public System.Guid CompanyToken { get; set; }

	public string? ProviderName { get; set; }

	public string? ReferenceCode { get; set; }

	public string? UserDescription { get; set; }

	public string? SystemicDescription { get; set; }

	public string? AdditionalData { get; set; }

	#endregion /Properties
}
