namespace Specs.Steps.SharedItems;

[TechTalk.SpecFlow.Binding]
public class StepBase : object
{
	public StepBase(Suzianna.Core.Screenplay.Stage stage) : base()
	{
		Stage = stage;

		Wallet = Constants.Helpers.Wallet.Hit;

		Company = Constants.Helpers.Company.Hit;
	}

	protected Suzianna.Core.Screenplay.Stage Stage { get; }

	protected Models.Entities.Wallet Wallet  { get; set; }
	protected Models.Entities.Company Company { get; set; }
	protected Models.Entities.User? WalletUser { get; set; }
}
