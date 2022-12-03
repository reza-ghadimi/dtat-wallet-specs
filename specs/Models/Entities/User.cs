namespace Models.Entities;

public class User : object
{
	public User(string ip, string displayName,
		string nationalCode, string cellPhoneNumber, string emailAddress) : base()
	{
		IP = ip ?? "127.0.0.1";
		DisplayName = displayName;
		EmailAddress = emailAddress;
		NationalCode = nationalCode;
		CellPhoneNumber = cellPhoneNumber;
	}

	public string IP { get; private set; }

	public string DisplayName { get; private set; }

	public string NationalCode { get; private set; }

	public string EmailAddress { get; private set; }

	public string CellPhoneNumber { get; private set; }
}
