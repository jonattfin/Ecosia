Feature: Home
  Background:
    Given The user opens the home page

  Scenario: User types for a query in the search input
    And The user search for the query in the search input
    Then The user is redirected to the results page

  Scenario: The countries section is shown
    Then The countries section title and subtitle are shown

  Scenario: The map section is shown
    Then The map section title and discover our project link are shown

  Scenario: The financial section is shown
    Then The financial section title and explore financial reports are shown

  Scenario: The join section is shown
    Then The join section title and share ecosia button are shown
