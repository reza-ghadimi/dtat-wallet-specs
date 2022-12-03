using Microsoft.Extensions.Configuration;

namespace Specs.Infrastructure;

public static class Config : object
{
	static Config()
	{
		Current =
			GetRoot(System.AppDomain.CurrentDomain.BaseDirectory)
			// using Microsoft.Extensions.Configuration;
			.Get<Settings.TestConfiguration>();

		if ((Current != null) && (Current.ExecutionAssemblyName != null))
		{
			Current.ExecutionAssembly =
				System.Reflection.Assembly.Load(Current.ExecutionAssemblyName);
		}
	}

	public static Settings.TestConfiguration? Current { get; private set; }

	private static Microsoft.Extensions.Configuration.IConfigurationRoot GetRoot(string outputPath)
	{
		var result =
			new Microsoft.Extensions.Configuration.ConfigurationBuilder()
			.SetBasePath(outputPath)
			.AddJsonFile("appsettings.json", true)
			.Build();

		return result;
	}
}
