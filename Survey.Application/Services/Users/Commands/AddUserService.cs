using Survey.Application.Interfaces;
using Survey.Application.Services.Users.Queries;
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

        public ServiceResultDto<bool> Execute(string fullName, string email, string password)
        {
            var isValidEmail = StringUtility.IsValidEmail(email);
            if (!isValidEmail)
            {
                return new ServiceResultDto<bool>("Invalid Email Address");
            }
            (var hash, var salt) = new PasswordUtility().Hash(password);
            var user = new User
            {
                FullName = fullName,
                Email = email,
                PasswordHash = hash,
                PasswordSalt = salt,
                IsActive = true
            };
            Context.Users.Add(user);
            var result= Context.SaveChanges() > 0;

            return new ServiceResultDto<bool>(result);
        }
    }
}
