Feature: TestingUI
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Login user as Administrator
	Given  navigate to application 
	And enter username id and password
| name      | id | contactNumber |
| Alexander | 4 | 0939517619    |
    And  click login
	Then  should see user logger to the application

	


