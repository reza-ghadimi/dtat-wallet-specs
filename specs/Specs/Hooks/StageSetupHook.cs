namespace Specs.Hooks;

[TechTalk.SpecFlow.Binding]
public class StageApiSetupHook : object
{
	public StageApiSetupHook(BoDi.IObjectContainer container)
	{
		Container = container;
	}

	protected BoDi.IObjectContainer Container { get; }


	[TechTalk.SpecFlow.BeforeScenario]
	//[TechTalk.SpecFlow.BeforeScenario("Api-Level")]
	public void SetupStage()
	{
		var callAnApiAbility =
			Suzianna.Rest.Screenplay.Abilities.CallAnApi.At
			(baseUrl: Constants.Shared.BaseUrl);

		var abilities =
			new System.Collections.Generic.List
			<Suzianna.Core.Screenplay.IAbility>
			{
				callAnApiAbility
			};

		var cast = Suzianna.Core.Screenplay.Cast
			.WhereEveryoneCan(abilities: abilities);

		var stage =
			new Suzianna.Core.Screenplay.Stage(cast: cast);

		Container.RegisterInstanceAs(stage);
	}
}
