namespace Models.Entities;

public class Wallet : object
{
	public Wallet(string name, System.Guid token) : base()
	{
		Name = name;
		Token = token;
	}

	public string Name { get; }

	public System.Guid Token { get; }
}
