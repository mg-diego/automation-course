Feature: Products Interactions

A short summary of the feature

Background: 
	Given the user enters username "standard_user"
	And the user enters password "secret_sauce"
	And the user submit a login action


Scenario: Cart show the number of products added
	When the user adds "Sauce Labs Onesie" to the cart
	Then The number of cart items is 1


Scenario: Cart counter increase with multiple products
	When the user adds multiple products to the cart
	| product					| 
    | Sauce Labs Onesie			| 
    | Sauce Labs Backpack       |
    | Sauce Labs Fleece Jacket  | 
	Then The number of cart items is 3