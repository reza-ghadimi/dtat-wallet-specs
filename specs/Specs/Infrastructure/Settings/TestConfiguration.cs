namespace Specs.Infrastructure.Settings;

public class TestConfiguration : object
{
	public TestConfiguration() : base()
	{
	}

	public string? ExecutionAssemblyName { get; set; }

	public System.Reflection.Assembly? ExecutionAssembly { get; set; }
}
