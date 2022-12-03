using FluentAssertions;

namespace Specs.Steps.DoPaymentScenarios;

public partial class DoPaymentStepDefinitions
{
	[TechTalk.SpecFlow.Given
		(@"\[I logged into my wallet account with my phone as a wallet user named Dariush]")]
	public void GivenILoggedIntoMyWalletAccountWithMyPhoneAsAWalletUserNamedDariush()
	{
		// **************************************************
		WalletUser = Constants.Helpers.Actor.Dariush;
		// **************************************************

		// **************************************************
		PaymentRequestBuilder =
			TestBuilders.RequestPaymentBuilder
			.Create().MapUserInformation(user: WalletUser)
			;
		// **************************************************

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
		PaymentRequestBuilder.WithAmount(amount: amount);
	}

	[TechTalk.SpecFlow.Then(@"\[I should be able to pay]")]
	public void ThenIShouldBeAbleToPay()
	{
		// **************************************************
		var doPaymentRequest =
			PaymentRequestBuilder
			.Build();

		var doPaymentTask =
			Screenplay.Tasks.DoTransaction.Payment
			(request: doPaymentRequest);

		Stage.ActorInTheSpotlight.AttemptsTo(tasks: doPaymentTask);
		// **************************************************
	}

	[TechTalk.SpecFlow.Then
		(@"\[My new wallet balance must be equal current balance to minus purchase cost]")]
	public void ThenMyNewWalletBalanceMustBeEqualCurrentBalanceToMinusPurchaseCost()
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
