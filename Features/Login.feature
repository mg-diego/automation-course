Feature: Login

A short summary of the feature


Scenario: User perform a valid login
	Given the user enters username "standard_user"
	And the user enters password "secret_sauce"
	When the user submit a login action
	Then the user can login

Scenario Outline: Login 
	Given the user enters username "<username>"
	And the user enters password "<password>"
	When the user submit a login action
	Then the user can login

	Examples: 
	 | Example Description | username      | password     |
	 | standard            | standard_user | secret_sauce |
	 | problem             | problem_user  | secret_sauce |

Scenario: User attempts a login with invalid credentials
	Given the user enters username "bad_user"
	And the user enters password "bad_password"
	When the user submit a login action
	Then the user can see the next error message
	"""
	Epic sadface: Username and password do not match any user in this service
	"""