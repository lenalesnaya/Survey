﻿using System.Threading.Tasks;
using ItechArt.Common;
using ItechArt.Survey.DomainModel;

namespace ItechArt.Survey.Foundation.Authentication.Abstractions;

public interface IAuthenticateService
{
    Task<OperationResult<User, UserRegistrationErrors>> RegisterAsync(User user, string password);

    Task<OperationResult<User, UserAuthenticationErrors>> AuthenticateAsync(User user, string password);

    Task SignOutAsync();
}