Feature: Amazon Login Feature

Test Cases for Amazon Login Feature

@Login
Scenario: Login to Amazon using valid credentials
	Given the user navigates to 'https://amazon.com'
	When click the Sign-in button in the pop-up
	And the user enters 'gingersoul2318@gmail.com' in the email field
	And click the Continue button
	And the user enters 'Qwer123!' in the password field
	And click the Sign-in button
	Then the user should be redirected to amazon dashboard

@Login
Scenario: Login to Amazon using an invalid password
	Given the user navigates to 'https://amazon.com'
	When click the Sign-in button in the pop-up
	And the user enters 'gingersoul2318@gmail.com' in the email field
	And click the Continue button
	And the user enters 'Asdf123!' in the password field
	And click the Sign-in button
	Then the alert message 'Your password is incorrect' should be visible