namespace Models;

public class PaymentResponse : object
{
	#region Constructor
	public PaymentResponse() : base()
	{
	}
	#endregion /Constructor

	#region Properties

	public decimal? Balance { get; set; }

	public long? TransactionId { get; set; }

	#endregion /Properties
}
