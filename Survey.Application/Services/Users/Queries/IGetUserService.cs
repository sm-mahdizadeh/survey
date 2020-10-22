using Survey.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Survey.Common;
namespace Survey.Application.Services.Users.Queries
{
    public interface IGetUserService
    {
        List<GetUsersDto> Execute(RequestGetUserDto request);
    }
    public class GetUserService:BaseService, IGetUserService
    {
        public GetUserService(IDatabaseContext context) : base(context) { }


        public List<GetUsersDto> Execute(RequestGetUserDto request)
        {
            var users = Context.Users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.Searchkey))
            {
                 users = users.Where(w => w.FullName.Contains(request.Searchkey) || w.Email.Contains(request.Searchkey));
            }
            return users.ToPaged(request.Page,20,out var total).Select(s=>new GetUsersDto {
                Email=s.Email,
                FullName=s.FullName,
                Id=s.Id
            }).ToList();
        }
    }
}
