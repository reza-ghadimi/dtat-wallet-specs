namespace Models.Base;

public class Response : object
{
	#region Properties

	#region Balance
	/// <summary>
	/// مبلغ کل قابل خرید
	/// </summary>
	public decimal Balance { get; set; }
	#endregion /Balance

	#region WithdrawBalance
	/// <summary>
	/// صرفا مبلغ قابل برداشت
	/// </summary>
	public decimal WithdrawBalance { get; set; }
	#endregion /WithdrawBalance

	#endregion /Properties
}
