using Survey.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Application.Services
{
    public class BaseService
    {
        protected readonly IDatabaseContext Context;

        public BaseService(IDatabaseContext context)
        {
            Context = context;
        }
    }
}
