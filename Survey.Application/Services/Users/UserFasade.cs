using Survey.Application.Interfaces;
using Survey.Application.Services.Users.Commands;
using Survey.Application.Services.Users.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Application.Services.Users
{
    public class UserFasade : BaseService, IUserFasade
    {
        public UserFasade(IDatabaseContext context) : base(context) { }


        private IAddUserService _signin;
        public IAddUserService Signin => _signin = _signin ?? new AddUserService(Context);

        private IGetUserService _signup;
        public IGetUserService Signup => _signup = _signup ?? new GetUserService(Context);

        private IGetUsersService _list;
        public IGetUsersService List => _list = _list ?? new GetUsersService(Context);
    }
}
