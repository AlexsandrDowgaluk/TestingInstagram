Feature: WrongPassword
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@wrongPassword
Scenario: Enterin the wrong password
	Given I is on registration page
	When I enters following credention
	And User click button registration
	Then Alert error message
