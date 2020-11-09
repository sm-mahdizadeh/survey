using Survey.Application.Interfaces;
using Survey.Application.Utilites;
using Survey.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey.Application.Services.Users.Queries
{
    public interface IGetUserService
    {
        ServiceResultDto<GetUserDto> Execute(string username, string password);
    }

    public class GetUserService : BaseService, IGetUserService
    {

        public GetUserService(IDatabaseContext context) : base(context) { }

        public ServiceResultDto<GetUserDto> Execute(string username, string password)
        {

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return new ServiceResultDto<GetUserDto>("نام کاربری و رمز عبور را وارد نمایید");

            }



            var user = Context.Users.FirstOrDefault(p => p.Email.Equals(username) && p.IsActive == true);

            if (user == null)
            {
                return new ServiceResultDto<GetUserDto>("ایمیل یا رمز عبور اشتباه است");

            }


            var isVerify = new PasswordUtility().Verify(password, user.PasswordHash, user.PasswordSalt);
            if (!isVerify)
            {
                return new ServiceResultDto<GetUserDto>("ایمیل یا رمز عبور اشتباه است");
            }


            return new ServiceResultDto<GetUserDto>(new GetUserDto
            {
                UserId = user.Id,
                Name = user.FullName
            });
        }
    }

    public class GetUserDto
    {
        public long UserId { get; set; }
        public string Name { get; set; }
    }

    public class ServiceResultDto<T> : ServiceResultDto
    {
        public ServiceResultDto() { }
        public ServiceResultDto(string message) : base(message) { }
        public ServiceResultDto(T data, string message = "عملیات با موفقیت انجام شد.")
        {
            IsSuccess = true;
            Data = data;
            Message = message;
        }
        public T Data { get; set; }
    }
    public class ServiceResultDto
    {
        public ServiceResultDto() { }
        public ServiceResultDto(string message)
        {
            Message = message;
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
