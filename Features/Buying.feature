Feature: Buying products on the website

A short summary of the feature

@tag1
Scenario Outline: Buy a product
	Given the user is logged in with "standard_user" and "secret_sauce"
	And the user adds "<product>" to the cart
	When the user confirms the "<product>"  has <qty> items
	And the user continues his purchase with first name "user", last name "good" and postal code "1234"
	And the user reviews the "<product>"  has <qty> items
	Then the system confirms the successful purchase

	Examples: 
	| product                  | qty |
	| Sauce Labs Fleece Jacket | 1   |