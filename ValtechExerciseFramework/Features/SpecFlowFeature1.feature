Feature: BBCHeaderLinks


@mytag
Scenario: Clicking on BBC links
	Given I open the BBC Homepage
	Then the homepage is displayed
	When I click the sports link
	Then the sports page is displayed