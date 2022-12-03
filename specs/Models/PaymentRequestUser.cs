namespace Models;

public class PaymentRequestUser : object
{
	#region Constructor
	public PaymentRequestUser() : base()
	{
		IP = string.Empty;
		CellPhoneNumber = string.Empty;
	}
	#endregion /Constructor

	#region Properties

	public string IP { get; set; }

	public string CellPhoneNumber { get; set; }

	#endregion /Properties
}
