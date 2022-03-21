﻿using ItechArt.Survey.WebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ItechArt.Survey.WebApp.ViewModels;

public class RegistrationViewModel
{
    [Remote(
        nameof(AccountController.CheckIfUserNameExists),
        "Account",
        ErrorMessage = "This user name already exists")]
    [StringLength(
        Constants.RegistrationOptionsConstants.UserNameMaxLength,
        MinimumLength = Constants.RegistrationOptionsConstants.UserNameMinLength,
        ErrorMessage = "User name must consist of {2}-{1} symbols")]
    [RegularExpression(
       Constants.RegistrationOptionsConstants.UserNamePattern,
       ErrorMessage = "Incorrect user name")]
    [Required(ErrorMessage = "Username name is required")]
    public string UserName { get; set; }

    [Remote(
        nameof(AccountController.CheckIfEmailExists),
        "Account",
        ErrorMessage = "This email already exists")]
    [RegularExpression(
        Constants.RegistrationOptionsConstants.EmailPattern,
        ErrorMessage = "Incorrect email address")]
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }

    [StringLength(
        Constants.RegistrationOptionsConstants.PasswordMaxLength,
        MinimumLength = Constants.RegistrationOptionsConstants.PasswordMinLength,
        ErrorMessage = "Password must consist of {2}-{1} symbols")]
    [RegularExpression(
        Constants.RegistrationOptionsConstants.PasswordPattern,
        ErrorMessage = "Incorrect password")]
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Please, repeat password")]
    [Compare("Password", ErrorMessage = "Password doesn't match, try again !")]
    public string RepeatPassword { get; set; }
}