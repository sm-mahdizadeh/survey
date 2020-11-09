using Survey.Application.Services.Users.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Application.Services.Users.Commands
{
    public interface IAddUserService
    {
        ServiceResultDto<bool> Execute(string fullName,string email,string password);
    }
}
