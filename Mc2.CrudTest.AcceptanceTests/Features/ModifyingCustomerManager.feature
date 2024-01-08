﻿Feature: modifying Customer Manager
As a an operator I wish to be able to modify customer 

    Scenario: a Customer can be modified with valid properties
        Given There is a registered customer with the following properties
          | FirstName | Lastname | DateOfBirth          | PhoneNumber | Email                 | BankAccountNumber      |
          | Ali       | Hassani  | 2000-02-01T00:00:01Z | 09131485424 | ali.hassani@gmail.com | IE12BOFI90000112345678 |
        When I modify customer with following 'Ali' first name and properties
          | FirstName | Lastname | DateOfBirth          | PhoneNumber | Email                | BankAccountNumber      |
          | Ali       | Hassani  | 2000-02-01T00:00:01Z | 09131922393 | ali.hassani@mail.com | IE12BOFI90000112345678 |
        Then I can find a customer with 'Ali' first name and above info

    Scenario: a customer can not be modified with invalid properties
        Given There is a registered customer with the following properties
          | FirstName | Lastname | DateOfBirth          | PhoneNumber | Email                 | BankAccountNumber      |
          | Ali       | Hassani  | 2000-02-01T00:00:01Z | 09131485424 | ali.hassani@gmail.com | IE12BOFI90000112345678 |
        When I modify customer with following 'Ali' first name and properties
          | FirstName | Lastname | DateOfBirth          | PhoneNumber   | Email   | BankAccountNumber   |
          | Ali       | Hassani  | 2000-02-01T00:00:01Z | <PhoneNumber> | <Email> | <BankAccountNumber> |
        Then I will see the exception with the following info
          | Code            | Message            |
          | <ExceptionCode> | <ExceptionMessage> |

    Examples:

      | ExceptionCode | ExceptionMessage                  | PhoneNumber | Email               | BankAccountNumber      |
      | CS-1001       | phone number must be valid        | 092         | Mehdi.Ali@gmail.com | IE12BOFI90000112345678 |
      | CS-1002       | email must be valid format        | 09122215698 | Mehdi               | IE12BOFI90000112345678 |
      | CS-1003       | bank account number must be valid | 09122215698 | Mehdi.Ali@gmail.com | 6357ih                 |

    Scenario: a customer can be modified when there are no customer with same first name and last name and birth of date
        Given There is a registered customer with the following properties
          | FirstName | Lastname | DateOfBirth          | PhoneNumber | Email                 | BankAccountNumber      |
          | Ali       | Hassani  | 2000-02-01T00:00:01Z | 09131485424 | ali.hassani@gmail.com | IE12BOFI90000112345678 |
        When I modify customer with following 'Ali' first name and properties
          | FirstName   | Lastname   | DateOfBirth   | PhoneNumber   | Email   | BankAccountNumber   |
          | <FirstName> | <LastName> | <DateOfBirth> | <PhoneNumber> | <Email> | <BankAccountNumber> |
        Then I will see the exception with the following info
          | Code            | Message            |
          | <ExceptionCode> | <ExceptionMessage> |

    Examples:
      | ExceptionCode | ExceptionMessage                                                                 | FirstName | LastName           | DateOfBirth          | PhoneNumber | Email                 | BankAccountNumber      |
      | CS-1004       | first name and last name and date of birth must be unique when customer modified | Ali       | Hassani            | 2000-02-01T00:00:01Z | 09121112131 | Ali.Akbari@gmail.com  | IE12BOFI90000112345677 |
      | CS-1005       | email must be unique when customer modified                                      | AliHassan | Hassani Gharebaghi | 2001-02-01T00:00:01Z | 09915160619 | ali.hassani@gmail.com | IE12BOFI90000112345677 |