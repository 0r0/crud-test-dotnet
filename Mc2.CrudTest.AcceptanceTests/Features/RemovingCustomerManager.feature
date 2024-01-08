Feature: RemovingCustomerManager
As a an operator I wish to be able to Remove customer

    Scenario: a customer can be removed with it has not been used
        Given There is a registered customer with the following properties
          | FirstName | Lastname | DateOfBirth          | PhoneNumber | Email                 | BankAccountNumber      |
          | Ali       | Hassani  | 2000-02-01T00:00:01Z | 09131485424 | ali.hassani@gmail.com | IE12BOFI90000112345678 |
        When I remove the customer  with first name 'Ali'
        Then I can not find a customer  with first name 'Ali' and above info