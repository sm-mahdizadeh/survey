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
        public static int GetUserId(ClaimsPrincipal User,int defaulltValue=0)
        {
            try
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                var userId = int.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
                return userId;
            }
            catch (Exception)
            {

                return defaulltValue;
            }

        }


        public static int GetId(this IIdentity identity,int defaultValue=0)
        {
           
            try
            {
                var userId = int.Parse((identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier).Value);
                return userId;
            }
            catch (Exception)
            {

                return defaultValue;
            }
        }
    }
}
