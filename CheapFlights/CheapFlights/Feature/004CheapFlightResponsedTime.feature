Feature: 004CheapFlightResponsedTime
	In order to test the response time
	As a testing engineer
	I want to ensure that response time less than 3.5s

@SearchForTheCheapestFare04
Scenario: Submit page response time
	Given I have visited the main page 
	And I have submited the information
	When I press submit
	Then the response time should be less than 3.5
