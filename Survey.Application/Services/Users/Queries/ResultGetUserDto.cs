using System.Collections.Generic;
namespace Survey.Application.Services.Users.Queries
{
    public class ResultGetUserDto
    {
        public List<GetUsersDto> Users { get; set; }
        public int Total { get; set; }
    }
}
