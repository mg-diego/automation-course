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

Scenario: Buy a product
	When the user adds "Sauce Labs Onesie" to the cart
	Then The number of cart items is 1
	When the user opens the cart
	Then the "Sauce Labs Onesie" product has amount 1 in the shopping cart
	And the user clicks in the Checkout button
	When the user sets 'Diego' as name in Checkout Information
	And the user sets 'Diego' as surname in Checkout Information
	And the user sets '123' as zipcode in Checkout Information
	And the user clicks in Continue button
	Then the "Sauce Labs Onesie" product has amount 1 in the checkout overview
	When the user clicks in the Finish button
	Then the order finished message appears