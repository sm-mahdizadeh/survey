using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Survey.Web.Utility
{
    public static class UserUtility
    {
        public static int? GetUserId(ClaimsPrincipal User)
        {
            try
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                var userId = int.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
                return userId;
            }
            catch (Exception)
            {

                return null;
            }

        }

        //public static int? Id(this ClaimsPrincipal user)
        //{
        //    try
        //    {
        //        //var userId = int.Parse(user.FindFirst(ClaimTypes.NameIdentifier).Value);
        //        //return userId;
        //    }
        //    catch (Exception)
        //    {

        //        return null;
        //    }
        //}
        //public static int? Id(this IIdentity user)
        //{
        //    try
        //    {
        //        var userId = int.Parse(user.FindFirst(ClaimTypes.NameIdentifier).Value);
        //        return userId;
        //        return user.Id;

        //    }
        //    catch (Exception)
        //    {

        //        return null;
        //    }
        //}
    }
}
