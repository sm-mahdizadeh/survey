﻿using Survey.Application.Services.Users.Commands;
using Survey.Application.Services.Users.Queries;

namespace Survey.Application.Services.Users
{
    public interface IUserFasad
    {
        IAddUserService Signin { get; }
        IGetUserService Signup { get; }
        IGetUsersService List { get; }
    }
}
