Feature: HomePage

Scenario: Can Sign in to Home Page
	Given The Home Page is Loaded
	When I Sign In to my Account
	And I enter correct Credentials
	Then I am logged in
	