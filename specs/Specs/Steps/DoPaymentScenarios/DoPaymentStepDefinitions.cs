namespace Specs.Steps.DoPaymentScenarios;

[TechTalk.SpecFlow.Binding]
public partial class DoPaymentStepDefinitions : SharedItems.StepBase
{
	public DoPaymentStepDefinitions
		(Suzianna.Core.Screenplay.Stage stage) : base(stage: stage)
	{
		PaymentRequestBuilder =
			TestBuilders.RequestPaymentBuilder.Create();
	}

	private TestBuilders.RequestPaymentBuilder PaymentRequestBuilder { get; set; }
}
