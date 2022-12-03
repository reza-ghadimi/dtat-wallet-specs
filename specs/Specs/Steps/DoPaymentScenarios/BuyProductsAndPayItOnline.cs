using FluentAssertions;

namespace Specs.Steps.DoPaymentScenarios;

public partial class DoPaymentStepDefinitions
{
	[TechTalk.SpecFlow.Given
		(@"\[I logged into my wallet account with my phone as an user named Dariush]")]
	public void GivenILoggedIntoMyWalletAccountWithMyPhoneAsAbUserNamedDariush()
	{
		WalletUser = Constants.Helpers.Actor.Dariush;

		// **************************************************
		Stage.ShineSpotlightOn(actorName: WalletUser.DisplayName);
		// **************************************************
	}

	[TechTalk.SpecFlow.Given
		(@"\[I add \$'([^']*)' rials to my wallet credit]")]
	public void GivenIAddRialsToMyWalletCredit(decimal amount)
	{
		// **************************************************
		var doDepositeRequest =
			TestBuilders.RequestDepositeBuilder.Create()
			.WithAmount(amount: amount)
			.MapUserInformation(user: WalletUser)
			.Build();

		var doDepositeTask =
			Screenplay.Tasks.DoTransaction.Deposite(request: doDepositeRequest);

		Stage.ActorInTheSpotlight.AttemptsTo(tasks: doDepositeTask);
		// **************************************************
	}

	[TechTalk.SpecFlow.When
		(@"\[I want to pay the amount of \$'(.*)' rials to finalize my order]")]
	public void WhenIWantToPayTheAmountOfRialsToFinalizeMyOrder(decimal amount)
	{
		// **************************************************
		_doPaymentRequest =
			TestBuilders.RequestPaymentBuilder
			.Create()
			.WithAmount(amount: amount)
			.MapUserInformation(user: WalletUser)
			.Build()
			;
		// **************************************************

		// **************************************************
		var doPaymentTask =
			Screenplay.Tasks.DoTransaction.Payment
			(request: _doPaymentRequest);

		Stage.ActorInTheSpotlight.AttemptsTo(tasks: doPaymentTask);
		// **************************************************
	}

	[TechTalk.SpecFlow.Then(@"\[My payment must be successful]")]
	public void ThenMyPaymentMustBeSuccessful()
	{
		// **************************************************
		var currentTransactionResponse = Stage.ActorInTheSpotlight.AsksFor
			(question: Technical.Rest.Questions.LastMakingPaymentResponseApi.LastMakingPaymentResponse);

		currentTransactionResponse.IsSuccess.Should().BeTrue();
		// **************************************************
	}

	[TechTalk.SpecFlow.Then
		(@"\[My wallet credit must be equal to last wallet balance minus purchase cost]")]
	public void ThenMyWalletCreditMustBeEqualToLastWalletBalanceMinusPurchaseCost()
	{
		// **************************************************
		var getBalanceRequest =
			TestBuilders.GetBalanceBuilder.Create()
			.WithWalletToken(token: Wallet.Token)
			.WithCompanyToken(token: Company.Token)
			.MapUserInformation(user: WalletUser)
			.Build();

		var getCurrentBalanceTask =
			Screenplay.Tasks.Get.Balance(request: getBalanceRequest);

		Stage.ActorInTheSpotlight.AttemptsTo(tasks: getCurrentBalanceTask);
		// **************************************************

		// **************************************************
		var currentBalanceResponse = Stage.ActorInTheSpotlight.AsksFor
			(question: Technical.Rest.Questions.CurrentBalanceApi.CurrentBalance);

		var lastDoPaymentResponse = Stage.ActorInTheSpotlight.AsksFor
			(question: Technical.Rest.Questions.LastMakingPaymentResponseApi.LastMakingPaymentResponse);
		// **************************************************

		// **************************************************
		lastDoPaymentResponse.Data.Should().NotBeNull();
		lastDoPaymentResponse.IsSuccess.Should().BeTrue();
		lastDoPaymentResponse!.Data!.Balance.Should().Be(expected: currentBalanceResponse.Data);
		// **************************************************
	}
}
