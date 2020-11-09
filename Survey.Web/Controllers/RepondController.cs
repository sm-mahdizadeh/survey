using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Survey.Application.Services.Responds;

namespace Survey.Web.Controllers
{
    public class RespondController : Controller
    {
        private readonly IRespondFasade _respondServices;
        public RespondController(IRespondFasade respondServices)
        {
            _respondServices = respondServices;
        }
        public IActionResult List(int id)
        {
            var model=_respondServices.GetResponds.Execute(id);
            return PartialView(model);
        }
    }
}