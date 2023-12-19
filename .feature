Feature: Login to SauceDemo and Add to Cart

   As a user
   I want to login to SauceDemo
   So that I can access my inventory and add items to the cart

Scenario: Successful login with standard user and add to cart
   Given I navigate to the SauceDemo login page
   When I login with username "standard_user" and password "secret_sauce"
   And I add an item to the cart
   Then I should be redirected to the inventory page


Scenario: Unsuccessful login with locked out user
   Given I navigate to the SauceDemo login page
   When I login with username "locked_out_user" and password "secret_sauce"
   Then I should see the error message

Scenario: Unsuccessful login without user
   Given I navigate to the SauceDemo login page
   When I login with username "" and password ""
   Then I should see the error message
