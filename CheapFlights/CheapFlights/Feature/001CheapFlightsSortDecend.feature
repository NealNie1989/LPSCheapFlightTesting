Feature: 001CheapFlightsSortDecend
	In order to see the decending sort 
	As a testing engineer
	I want to see the decending sort text in the droplist

@SearchForTheCheapestFare01
Scenario: See the fares sorted decending
	Given I have visit the Flight Centre Page
	And I have choose one flight
	When I press the Lowest price on drop list
	Then the result should be show on the screen
