namespace Constants;

public static class Keys : object
{
	static Keys()
	{
	}

	public static class Deposite : object
	{
		static Deposite()
		{
		}

		public static readonly string DepositeTransactionId = "DepositeTransactionId";
	}

	public static class Payment : object
	{
		static Payment()
		{
		}

		public static readonly string PaymentTransactionId = "PaymentTransactionId";
	}

	public static class Balance : object
	{
		static Balance()
		{
		}

		public static readonly string GetBalanceId = "GetBalanceId";
	}
}
