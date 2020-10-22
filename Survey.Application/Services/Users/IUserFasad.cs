using Survey.Application.Services.Users.Commands;

namespace Survey.Application.Services.Users
{
    public interface IUserFasad
    {
        IAddUserService Signin { get; }
    }
}
