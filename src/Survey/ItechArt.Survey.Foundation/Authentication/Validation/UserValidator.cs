﻿using ItechArt.Common.Validation;
using ItechArt.Survey.DomainModel;
using ItechArt.Survey.Foundation.Authentication.Abstractions;
using ItechArt.Survey.Foundation.Authentication.Configuration;
using ItechArt.Survey.Foundation.Authentication.Validation.Abstractions;
using Microsoft.Extensions.Options;

namespace ItechArt.Survey.Foundation.Authentication.Validation;

public class UserValidator :Validator, IUserValidator
{
    private readonly RegistrationOptions _options;


    public UserValidator(IOptions<RegistrationOptions> options)
    {
        _options = options.Value;
    }


    public ValidationResult<UserRegistrationErrors> ValidatePassword(string password)
    {
        var error = ValidateUserPassword(password);

        if (error.HasValue)
        {
            return ValidationResult<UserRegistrationErrors>.CreateFailureResult(error.Value);
        }

        return ValidationResult<UserRegistrationErrors>.CreateSuccessfulResult();
    }


    protected override UserRegistrationErrors? ValidateWithErrorReturning(User user)
    {
        var error = ValidateUserName(user.UserName);

        if (error != null)
        {
            return error;
        }

        error = ValidateUserEmail(user.Email);

        if (error != null)
        {
            return error;
        }

        return null;
    }


    private UserRegistrationErrors? ValidateUserName(string userName)
    {
        var isNameLengthValid = _options.UserNameMinLength <= userName.Length && userName.Length <= _options.UserNameMaxLength;

        if (string.IsNullOrEmpty(userName))
        {
            return UserRegistrationErrors.UserNameIsRequired;
        }

        if (!isNameLengthValid)
        {
            return UserRegistrationErrors.InvalidUserNameLength;
        }

        var match = _options.UserNamePattern.Match(userName);

        if (string.IsNullOrEmpty(match.Value))
        {
            return UserRegistrationErrors.IncorrectUserName;
        }

        return null;
    }

    private UserRegistrationErrors? ValidateUserEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return UserRegistrationErrors.EmailIsRequired;
        }

        var match = _options.EmailPattern.Match(email);

        if (string.IsNullOrEmpty(match.Value))
        {
            return UserRegistrationErrors.IncorrectEmail;
        }

        return null;
    }

    private UserRegistrationErrors? ValidateUserPassword(string password)
    {
        var isPasswordLengthValid = _options.PasswordMinLength <= password.Length && password.Length <= _options.PasswordMaxLength;

        if (string.IsNullOrEmpty(password))
        {
            return UserRegistrationErrors.PasswordIsRequired;
        }

        if (!isPasswordLengthValid)
        {
            return UserRegistrationErrors.InvalidPasswordLength;
        }

        var match = _options.PasswordPattern.Match(password);

        if (string.IsNullOrEmpty(match.Value))
        {
            return UserRegistrationErrors.IncorrectPassword;
        }

        return null;
    }
}