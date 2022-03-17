﻿using ItechArt.Common.Validation;
using ItechArt.Common.Validation.Abstractions;
using ItechArt.Survey.DomainModel;
using ItechArt.Survey.Foundation.Authentication.Abstractions;
using ItechArt.Survey.Foundation.Authentication.Configuration;
using ItechArt.Survey.Foundation.Authentication.Validation.Abstractions;
using Microsoft.Extensions.Options;

namespace ItechArt.Survey.Foundation.Authentication.Validation;

public class UserValidator : Validator<User, UserRegistrationErrors>, IUserValidator
{
    private readonly RegistrationOptions _options;

    private string _password;

    public UserValidator(IOptions<RegistrationOptions> options)
    {
        _options = options.Value;
    }


    public ValidationResult<UserRegistrationErrors> Validate(User user, string password)
    {
        _password = password;

        return Validate(user);
    }


    protected override UserRegistrationErrors? HandleValidate(User user)
    {
        var userNameError = ValidateUserName(user.UserName);
        if (userNameError != null)
        {
            return userNameError;
        }

        var userEmailError = ValidateUserEmail(user.Email);
        if (userEmailError != null)
        {
            return userEmailError;
        }

        var userPasswordError = ValidateUserPassword(_password);

        return userPasswordError;
    }


    private UserRegistrationErrors? ValidateUserName(string userName)
    {
        if (string.IsNullOrEmpty(userName))
        {
            return UserRegistrationErrors.UserNameIsRequired;
        }

        var isNameLengthValid = _options.UserNameMinLength <= userName.Length && userName.Length <= _options.UserNameMaxLength;
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
        if (string.IsNullOrEmpty(password))
        {
            return UserRegistrationErrors.PasswordIsRequired;
        }

        var isPasswordLengthValid = _options.PasswordMinLength <= password.Length && password.Length <= _options.PasswordMaxLength;
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