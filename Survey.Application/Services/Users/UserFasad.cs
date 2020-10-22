using Survey.Application.Interfaces;
using Survey.Application.Services.Users.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Application.Services.Users
{
    public class UserFasad : BaseService, IUserFasad
    {
        public UserFasad(IDatabaseContext context) : base(context) { }


        private IAddUserService _signin;
        public IAddUserService Signin => _signin = _signin ?? new AddUserService(Context);
    }
}
