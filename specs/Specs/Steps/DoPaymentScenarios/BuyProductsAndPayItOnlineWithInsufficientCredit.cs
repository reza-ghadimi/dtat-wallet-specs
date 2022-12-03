using FluentAssertions;
using TechTalk.SpecFlow;

namespace Specs.Steps.DoPaymentScenarios;

public partial class DoPaymentStepDefinitions
{
	[TechTalk.SpecFlow.Given
		(@"\[I logged into my wallet account with my phone as a wallet user named Reza]")]
	public void GivenILoggedIntoMyWalletAccountWithMyPhoneAsAWalletUserNamedReza()
	{
		// **************************************************
		WalletUser = Constants.Helpers.Actor.Reza;
		// **************************************************

		// **************************************************
		PaymentRequestBuilder =
			TestBuilders.RequestPaymentBuilder
			.Create()
			.MapUserInformation(user: WalletUser)
			;
		// **************************************************

		Stage.ShineSpotlightOn(actorName: WalletUser.DisplayName);
	}

	[TechTalk.SpecFlow.Given(@"\[I charged my wallet account \$'([^']*)' rials]")]
	public void GivenIChargedMyWalletAccountRials(decimal amount)
	{
		// **************************************************
		var makingDepositeRequest =
			TestBuilders.RequestDepositeBuilder.Create()
			.WithAmount(amount: amount)
			.MapUserInformation(user: WalletUser)
			.Build();

		var makingDepositeTask =
			Screenplay.Tasks.DoTransaction.Deposite
			(request: makingDepositeRequest);

		Stage.ActorInTheSpotlight.AttemptsTo(tasks: makingDepositeTask);
		// **************************************************
	}

	[TechTalk.SpecFlow.Given(@"\[I want to spend more than my wallet credit]")]
	public void GivenIWantToSpendMoreThanMyWalletCredit()
	{
		// **************************************************
		var myWalletBalanceAfterLastSuccessfulTransaction =
			Stage.ActorInTheSpotlight.AsksFor(question: Technical.Rest.Questions
			.LastRequestDepositeResponseApi.LastRequestDepositeResponse)
			?.Data?.Balance;

		var myNewOrderPrice =
			myWalletBalanceAfterLastSuccessfulTransaction!.Value * 2;

		PaymentRequestBuilder.WithAmount(amount: myNewOrderPrice);
		// **************************************************
	}

	[TechTalk.SpecFlow.When
		(@"\[I want to pay the price to finalize my new order]")]
	public void WhenIWantToPayThePriceToFinalizeMyNewOrder()
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


	[Then(@"\[I should get insufficient balance error]")]
	public void ThenIShouldGetInsufficientBalanceError()
	{
		// **************************************************
		var lastPaymentTransactionResponse = Stage.ActorInTheSpotlight.AsksFor
			(Technical.Rest.Questions.LastMakingPaymentResponseApi.LastMakingPaymentResponse);

		lastPaymentTransactionResponse.Data.Should().BeNull();
		lastPaymentTransactionResponse.IsSuccess.Should().BeFalse();

		//var errorMessage =
		//	$"The amount value is more than user balance value!";

		//lastPaymentResponse.ErrorMessages.Contains(item: errorMessage);
		// **************************************************
	}

	[TechTalk.SpecFlow.Then(@"\[my wallet credit must remain unchanged]")]
	public void ThenMyWalletCreditMustRemainUnchanged()
	{
		// **************************************************
		var myWalletBalanceAfterLastSuccessfulTransaction =
			Stage.ActorInTheSpotlight.AsksFor
			(Technical.Rest.Questions.LastRequestDepositeResponseApi.LastRequestDepositeResponse)
			?.Data?.Balance;
		// **************************************************

		// **************************************************
		var getCurrentBalanceRequest =
			TestBuilders.GetBalanceBuilder.Create()
			.WithWalletToken(token: Wallet.Token)
			.WithCompanyToken(token: Company.Token)
			.MapUserInformation(user: WalletUser)
			.Build();

		var getCurrentBalanceTask =
			Screenplay.Tasks.Get.Balance(request: getCurrentBalanceRequest);

		Stage.ActorInTheSpotlight.AttemptsTo(tasks: getCurrentBalanceTask);

		var myCurrentWalletBalance = Stage.ActorInTheSpotlight.AsksFor
			(question: Technical.Rest.Questions.CurrentBalanceApi.CurrentBalance)?.Data;
		// **************************************************

		// **************************************************
		myCurrentWalletBalance.Should()
			.Be(expected: myWalletBalanceAfterLastSuccessfulTransaction);
		// **************************************************
	}
}
