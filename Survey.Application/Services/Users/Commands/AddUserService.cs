using Survey.Application.Interfaces;
using Survey.Application.Utilites;
using Survey.Common;
using Survey.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Application.Services.Users.Commands
{
    public class AddUserService : BaseService, IAddUserService
    {
        public AddUserService(IDatabaseContext context) : base(context) { }

        public bool Execute(string fullName, string email, string password)
        {
            (var hash,var salt) = new PasswordUtility().Hash(password);
            var user = new User {
                FullName = fullName,
                Email = email,
                PasswordHash = hash,
                PasswordSalt = salt,
                IsActive = true
            };
            Context.Users.Add(user);
            return Context.SaveChanges() > 0;
        }
    }
}
