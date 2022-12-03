namespace Models.Entities;

public class Company : object
{
	public Company(string name, System.Guid token) : base()
	{
		Name = name;
		Token = token;
	}

	public string Name { get; }

	public System.Guid Token { get; }
}
