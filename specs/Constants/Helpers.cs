namespace Constants;

public static class Helpers : object
{
	static Helpers()
	{
	}

	public static class Actor : object
	{
		static Actor()
		{
		}

		public static readonly Models.Entities.User Dariush = new
		(
			ip: "127.0.0.1",
			nationalCode: "1234567891",
			displayName: "داریوش تصدیقی",
			cellPhoneNumber: "09121087461",
			emailAddress: "dariusht@gmail.com"
		);

		public static readonly Models.Entities.User Reza = new
		(
			ip: "127.0.0.1",
			displayName: "رضا قدیمی",
			nationalCode: "1987654321",
			cellPhoneNumber: "09215149218",
			emailAddress: "rezaqadimi.ir@gmail.com"
		);
	}

	public static class Company : object
	{
		static Company()
		{
		}

		public static readonly Models.Entities.Company Hit = new
		(
			name: "شرکت داد و ستد هستی",

			token: new(g: "D24295E9-DAC0-4FE3-957F-6674F9FD0728")
		);
	}

	public static class Wallet : object
	{
		static Wallet()
		{
		}

		public static readonly Models.Entities.Wallet Hit = new
		(
			name: "کیف پول هستی",

			token: new(g: "D630496E-3F91-4127-9DBC-F03B14ECD6D2")
		);
	}

	public static class Provider : object
	{
		static Provider()
		{
		}

		public static readonly string Sina = "Sina";

		public static readonly string Saman = "Saman";
	}
}
