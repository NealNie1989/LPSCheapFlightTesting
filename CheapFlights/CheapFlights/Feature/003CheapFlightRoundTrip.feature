Feature: CheapFlightRoundTrip
	In order to get the correct fares for round trip
	As a testing engineer
	I want to sum the fares of the trip

@SearchForTheCheapestFare03
Scenario: Total fee for the Round trip is correct
	Given I have visited the flight centre page
	And I have select the round trip from Auckland to Melbourne
	When I selected the depart flight and arrive flight
	Then the result should be calculator correctly
