using System.Linq;
using Specs.Infrastructure.Settings;

namespace Specs.Screenplay;

public static class Factory : object
{
	private static System.Collections.Generic.Dictionary<string, System.Type> _cachedTypes;

	static Factory()
	{
#pragma warning disable CS8602 // Dereference of a possibly null reference.
		_cachedTypes =
				Infrastructure.Config.Current.ExecutionAssembly
				.GetExportedTypes()
				.Where(current => current.IsTask() || current.IsQuestion())
				.Where(current => current.BaseType != null)
				.ToDictionary(current => current.BaseType.Name, current => current);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
	}

	public static T? CreateTask<T>(params object[] parameters) where T : Suzianna.Core.Screenplay.ITask
	{
		var type =
			_cachedTypes[typeof(T).Name];

		var result =
			(T?)System.Activator.CreateInstance
			(type: type, args: parameters);

		return result;
	}

	public static T? CreateQuestion<T>(params object[] parameters)
	{
		var type =
			_cachedTypes[typeof(T).Name];

		var result =
			(T?)System.Activator.CreateInstance
			(type: type, args: parameters);

		return result;
	}
}
