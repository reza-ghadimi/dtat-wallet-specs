namespace Models;

public class DepositeResponse : object
{
	#region Constructor
	public DepositeResponse() : base()
	{
	}
	#endregion /Constructor

	#region Properties

	public decimal? Balance { get; set; }

	public long? TransactionId { get; set; }

	#endregion /Properties
}
