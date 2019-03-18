Feature: Valtech Exercises

Scenario: Exercise 2A
	Given I open the homepage
    Then Check the homepage is opened
    When I accept cookies
    Then I confirm blog title is "RECENT BlOGS"

Scenario: Exercise 2B
	Given I open the homepage
    Then Check the homepage is opened
    When I accept cookies
    When I click on the "first" blog
    Then Check page title is "Where Experiences are Engineered - Valtech"

Scenario: Exercise 3A
    Given I open the homepage
    Then Check the homepage is opened
    When I accept cookies
    And I click top navigation "About" link
    Then Check the about page is opened
    And the about page header name should be "About"
    When I click top navigation "Services" link
    Then Check the services page is opened
    And the services page header name should be "Services"
    When I click top navigation "Work" link
    Then Check the work page is opened
    And the work page header name should be "Work"


    Scenario: Exercise 3B
    Given I open the homepage
    Then Check the homepage is opened
    When I accept cookies
    And I click top navigation "About" link
    Then Check the about page is opened
    When I click on on 'Our offices' link
    Then Check the contact page is opened
    And Get the number of offices