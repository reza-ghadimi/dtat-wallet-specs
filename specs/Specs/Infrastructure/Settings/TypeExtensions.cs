using System.Linq;

namespace Specs.Infrastructure.Settings;

public static class TypeExtensions : object
{
	static TypeExtensions()
	{
	}

	public static bool IsTask(this System.Type type)
	{
		var result =
			typeof(Suzianna.Core.Screenplay.ITask)
			.IsAssignableFrom(c: type);

		return result;
	}

	public static bool IsQuestion(this System.Type type)
	{
		var result =
			type.GetInterfaces()
			.Where(current => current.IsGenericType)
			.Where(current => current.GetGenericTypeDefinition() == typeof(Suzianna.Core.Screenplay.Questions.IQuestion<>))
			.Any();

		return result;
	}
}
