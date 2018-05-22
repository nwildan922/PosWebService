using Pos.Helpers;
using Pos.Model.Core;
using Pos.Repository.DataAccess;
using Pos.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Pos.WebApi.Controllers
{
    [RoutePrefix("api/Province")]
    public class ProvinceController : ApiController
    {

        private readonly UnitOfWork _unitOfWork;
        public ProvinceController()
        {
            _unitOfWork = new UnitOfWork(new DataContext());
        }
        [HttpGet]
        [Route(nameof(GetAll))]
        public IHttpActionResult GetAll()
        {
            var data = _unitOfWork.Provinces.GetAll();
            return Ok(data);
        }
        [HttpPost]
        [Route(nameof(Submit))]
        public IHttpActionResult Submit(Province model)
        {
            string message = "Name Is Empty";
            if (GlobalHelper.IsNullHelper(model.Name))
            {
                
                return Ok(message);
            }
            return Ok("asdf");
        }
    }
}