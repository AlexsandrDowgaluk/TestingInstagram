Feature: LoginToAccount
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@login
Scenario: Login to account
	Given I is on Login Page
	When I enter following creadentids
	And I click button registration
	Then The profile page will open
