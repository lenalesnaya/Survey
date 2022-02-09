﻿using System.Net;
using System.Threading.Tasks;
using ItechArt.Survey.DomainModel;

namespace ItechArt.Survey.Foundation.Authentication.Abstractions;

public interface IAuthenticateService
{ 
    Task<OperationResult<int, UserRegistrationStatus>> RegistrationAsync(User entity, string password);
}