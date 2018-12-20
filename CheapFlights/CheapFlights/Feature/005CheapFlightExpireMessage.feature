Feature: 005CheapFlightExpireMessage
	In order to get the expire session clearly
	As a testing engineer
	I want to get the proper info when it expired

@SearchForTheCheapestFare05
Scenario: Get the porper info when it expired
	Given I have visited the home page
	And I have selected info
	When I wait until it expired
	Then the porper message should be on the screen
