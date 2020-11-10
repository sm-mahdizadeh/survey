using Survey.Application.Services.Users.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Services.Users.Commands
{
    public interface IAddUserService
    {
        ServiceResultDto<bool> Execute(string fullName,string email,string password);
        Task<ServiceResultDto<bool>> ExecuteAsync(string fullName, string email, string password);
    }
}
