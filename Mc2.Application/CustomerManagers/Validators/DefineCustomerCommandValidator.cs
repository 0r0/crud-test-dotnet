using System.ComponentModel.DataAnnotations;
using FluentValidation;
using IbanNet;
using Mc2.Application.Contracts.CustomerManagers;
using Mc2.Domain.Contracts.CustomerManagers.Exceptions;
using PhoneNumbers;

namespace Mc2.Application.CustomerManagers.Validators;

public class DefineCustomerCommandValidator : AbstractValidator<DefineCustomerCommand>
{
    public DefineCustomerCommandValidator()
    {
        RuleFor(a => a.PhoneNumber).Custom((value, _) =>
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            var phoneNumber = phoneNumberUtil.Parse(value.ToString(), null);

            if (!phoneNumberUtil.IsPossibleNumber(phoneNumber))
                throw new PhoneNumberIsNotValidException();
        });
        RuleFor(a => a.Email).Custom((value, _) =>
        {
            var emailValidator = new EmailAddressAttribute();
            if (emailValidator.IsValid(value))
                throw new EmailIsNotValidException();
        });
        RuleFor(a => a.BankAccountNumber).Custom((value, _) =>
        {
            IIbanValidator validator = new IbanValidator();
            var validationResult = validator.Validate(value);
            if (!validationResult.IsValid)
                throw new BankAccountNumberIsNotValidException();
        });
    }
}