using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Pos.WebApi.Controllers
{
    public class BaseApiController : ApiController
    {
        protected string _message = "";
        protected string _controllerName = "";
        protected string _actionName = "";
    }
}