Feature: Customer Manager

As a an operator I wish to be able to Create, Update, Delete customers and list all customers

    @mytag
    Scenario: a Customer can be defined with valid properties

        When I register customer with following properties
          | FirstName | Lastname | DateOfBirth          | PhoneNumber | Email                | BankAccountNumber      |
          | Ali       | Hassani  | 2000-02-01T00:00:01Z | 09131922393 | ali.hassani@mail.com | IE12BOFI90000112345678 |
        Then I can find a customer with above info