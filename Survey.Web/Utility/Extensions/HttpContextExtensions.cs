using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Web.Utility.Extensions
{
    public static class HttpContextExtensions
    {
        public static string UserInfo(this HttpContext httpContext)
        {
            var cookies = new CookiesUtility();
            var browserId = cookies.GetBrowserId(httpContext);
            return browserId.ToString();
        }
    }
}
