Feature: 002CheapFlightsOneTrip
	In order to select the cheapest trip
	As a testing engineer
	I want to selcect the cheapest onward trip and backward trip

@SearchForTheCheapestFare02
Scenario: Select the cheapest onward trip
	Given I have visited the flight centre
	And I selected trip from Auckland to Melbourne
	When I press the first onward select button
	Then the onward result should be the cheapest

@SearchForTheCheapestFare02
Scenario: Select the cheapest backward trip
	Given I have went the flight centre
	And I selected trip from Melbourne to Auckland
	When I press the first backward select button
	Then the backward result should be the cheapest