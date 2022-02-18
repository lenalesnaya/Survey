﻿using System.Threading.Tasks;
using ItechArt.Common;
using ItechArt.Survey.DomainModel;
using ItechArt.Survey.Foundation.Authentication.Abstractions;
using ItechArt.Survey.Foundation.Authentication.Validation;
using Microsoft.AspNetCore.Identity;
using UserOptions = ItechArt.Survey.Foundation.Authentication.Validation.UserOptions;

namespace ItechArt.Survey.Foundation.Authentication;

public class AuthenticateService : IAuthenticateService
{
    private readonly UserManager<User> _userManager;


    public AuthenticateService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }


    public async Task<OperationResult<User, UserRegistrationStatusErrors>> RegistrationAsync(User user, string password)
    {
        var userOptions = new UserOptions();
        var userValidation = new UserValidator();

        userOptions.UserName = user.UserName;
        userOptions.Email = user.Email;
        userOptions.Password = password;
        userOptions.RepeatPassword = repeatPassword;
        var validateOptionsResult = userValidation.Validate("UserOptions", userOptions);

        if (validateOptionsResult.Failed)
            return OperationResult<User, UserRegistrationStatus>.FailureResult(
                UserRegistrationStatus.UnknownError,
                validateOptionsResult.FailureMessage);

        var userExists = await _userManager.FindByEmailAsync(user.Email);

        if (userExists != null)
        {
            return OperationResult<User, UserRegistrationStatusErrors>.GetFailureResult(
                UserRegistrationStatusErrors.UserAlreadyExists);
        }

        var createResult = await _userManager.CreateAsync(user, password);
        var addToRoleResult = await _userManager.AddToRoleAsync(user, "User");

        return createResult.Succeeded
            ? OperationResult<User, UserRegistrationStatusErrors>.GetSuccessResult(user)
            : OperationResult<User, UserRegistrationStatusErrors>.GetFailureResult(UserRegistrationStatusErrors.UnknownError);
    }
}