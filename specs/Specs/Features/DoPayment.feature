Feature: Do Payment

	In order to make an online payment
	As a Dtat wallet user
	I want to be able to pay it with my wallet credit

@Api-Level
Scenario: [Buy products and pay it online]
	Given [I logged into my wallet account with my phone as a wallet user named Dariush]
	And [I add $'20000000' rials to my wallet credit]
	When [I want to pay the amount of $'1500000' rials to finalize my order]
	Then [I should be able to pay]
	And [My new wallet balance must be equal current balance to minus purchase cost]
	
@Api-Level
Scenario: [Buy products and pay it online with insufficient credit]
	Given [I logged into my wallet account with my phone as a wallet user named Reza]
	And [I charged my wallet account $'5000000' rials]
	And [I want to spend more than my wallet credit]
	When [I want to pay the price to finalize my new order]
	Then [I should get insufficient balance error]
	And [my wallet credit must remain unchanged]
