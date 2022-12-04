Feature: Do Payment

	In order to make an online payment
	As a Dtat wallet user
	I want to be able to pay it with my wallet credit

@Api-Level
Scenario: [Buy products and pay it online]
	Given [I logged into my wallet account with my phone as an user named Dariush]
		| IP        | NationalCode | DisplayName          | cellPhoneNumber | EmailAddress       |
		| 127.0.0.1 | 1234567891   | Mr. Dariush Tasdighi | 09121087461     | dariusht@gmail.com |
	And [I add $'20000000' rials to my wallet credit]
	When [I want to pay the amount of $'1500000' rials to finalize my order]
	Then [My payment must be successful]
	And [My wallet credit must be equal to last wallet balance minus purchase cost]
	
@Api-Level
Scenario: [Buy products and pay it online with insufficient credit]
	Given [I logged into my wallet account with my phone as an user named Reza]
		| IP        | NationalCode | DisplayName     | cellPhoneNumber | EmailAddress            |
		| 127.0.0.1 | 1987654321   | Mr. Reza Qadimi | 09215149218     | RezaQadimi.ir@Gmail.com |
	And [I charged my wallet account $'5000000' rials]
	And [I want to spend more than my wallet credit]
	When [I want to pay the price to finalize my new order]
	Then [I should get insufficient balance error]
	And [my wallet credit must remain unchanged]
