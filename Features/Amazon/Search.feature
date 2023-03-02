Feature: Amazon Search Feature

Test Cases for Amazon Search Feature

Background: 
	Given the user navigates to 'https://amazon.com'
	And click the Sign-in button in the pop-up
	And the user enters 'gingersoul2318@gmail.com' in the email field
	And click the Continue button
	And the user enters 'Qwer123!' in the password field
	And click the Sign-in button
	And the user should be redirected to amazon dashboard

@Search
Scenario: Verify result list is paginated if there are more than 16 items and can be sorted on demand
	When the user clicks the Search-in dropdown
	And I select 'Books' option in Search-in dropdown
	And I enter 'apple' in the Search bar
	And I click the Search button
	Then I verify that the search result in the page is exactly 16 items
	And I verify that the pagination bar is displayed
	When I select 'Publication Date' option in Sort By dropdown
	Then I verify that the search result is sorted by publication date