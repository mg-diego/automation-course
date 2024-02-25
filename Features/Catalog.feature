Feature: Catalog

A short summary of the feature


Background: Do Login
	Given the user enters username "standard_user"
	And the user enters password "secret_sauce"
	And the user sumbits his credential
	And the user can login


@tag1
Scenario: the Cart is updated when user add a product
	When the user adds the product "Sauce Labs Onesie" to the cart
	Then the number in the cart is 1


Scenario: the Cart is updated when user adds multiple products
	When the user adds multiple products to the cart
	| product               |
	| Sauce Labs Onesie     |
	| Sauce Labs Backpack   |
	| Sauce Labs Bike Light |
	Then the number in the cart is 3
