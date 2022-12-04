using FluentAssertions;
using TechTalk.SpecFlow;

namespace Specs.Steps.DoPaymentScenarios;

public partial class DoPaymentStepDefinitions
{
	private Models.PaymentRequest? _doPaymentRequest;

	[TechTalk.SpecFlow.Given
		(@"\[I logged into my wallet account with my phone as an user named Reza]")]
	public void GivenILoggedIntoMyWalletAccountWithMyPhoneAsAnUserNamedReza()
	{
		WalletUser = Constants.Helpers.Actor.Reza;

		// **************************************************
		Stage.ShineSpotlightOn(actorName: WalletUser.DisplayName);
		// **************************************************
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
			.LastRequestDepositeResponseApi.Instance)
			?.Data?.Balance;

		var myNewOrderPrice =
			myWalletBalanceAfterLastSuccessfulTransaction!.Value * 2;

		_doPaymentRequest =
			TestBuilders.RequestPaymentBuilder
			.Create()
			.WithAmount(amount: myNewOrderPrice)
			.MapUserInformation(user: WalletUser)
			.Build()
			;
		// **************************************************
	}

	[TechTalk.SpecFlow.When
		(@"\[I want to pay the price to finalize my new order]")]
	public void WhenIWantToPayThePriceToFinalizeMyNewOrder()
	{
		// **************************************************
		var doPaymentTask =
			Screenplay.Tasks.DoTransaction.Payment
			(request: _doPaymentRequest!);

		Stage.ActorInTheSpotlight.AttemptsTo(tasks: doPaymentTask);
		// **************************************************
	}

	[Then(@"\[I should get insufficient balance error]")]
	public void ThenIShouldGetInsufficientBalanceError()
	{
		// **************************************************
		var lastTransactionResponse = Stage.ActorInTheSpotlight.AsksFor
			(Technical.Rest.Questions.LastMakingPaymentResponseApi.Instance);

		lastTransactionResponse.Data.Should().BeNull();
		lastTransactionResponse.IsSuccess.Should().BeFalse();

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
			(Technical.Rest.Questions.LastRequestDepositeResponseApi.Instance)
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
			(question: Technical.Rest.Questions.CurrentBalanceApi.Instance)?.Data;
		// **************************************************

		// **************************************************
		myCurrentWalletBalance.Should()
			.Be(expected: myWalletBalanceAfterLastSuccessfulTransaction);
		// **************************************************
	}
}
