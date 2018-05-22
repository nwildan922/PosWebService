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
    public class ProvinceController : BaseApiController
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

        [HttpGet]
        [Route(nameof(Get))]
        public IHttpActionResult Get(string id)
        {
            var data = _unitOfWork.Provinces.Get(id);
            return Ok(data);
        }

        [HttpPost]
        [Route(nameof(Submit))]
        public IHttpActionResult Submit(Province model)
        {
            string _message = "";
            if (GlobalHelper.IsNullHelper(model.Name))
            {
                _message = "Name is empty";
                return BadRequest(_message);
            }

            if (model.Id == "")
            {
                var data = new Province();
                data.Id = Guid.NewGuid().ToString();
                data.Name = model.Name;
                data.IsActive = model.IsActive;
                data.CreatedBy = "admin insert";
                data.CreatedDate = DateTime.Now;
                _unitOfWork.Provinces.Add(data);
                _unitOfWork.Complete();
                _unitOfWork.Dispose();
                _message = GlobalResources.MsgSave;
            }
            else
            {
                var data = _unitOfWork.Provinces.Get(model.Id);
                data.Name = model.Name;
                data.IsActive = model.IsActive;
                data.UpdatedBy = "admin update";
                data.UpdatedDate = DateTime.Now;
                _unitOfWork.Complete();
                _unitOfWork.Dispose();
                _message = GlobalResources.MsgUpdate;
            }

            return Ok(_message);
        }

        [HttpPost]
        [Route(nameof(Delete))]
        public IHttpActionResult Delete(string id)
        {
            _message = GlobalResources.MsgDelete;
            var temp = _unitOfWork.Provinces.Get(id);
            _unitOfWork.Provinces.Remove(temp);
            _unitOfWork.Complete();
            _unitOfWork.Dispose();
            return Ok(_message);
        }

        [HttpPost]
        [Route(nameof(DeleteRange))]
        public IHttpActionResult DeleteRange(List<Province> listId)
        {
            _message = GlobalResources.MsgDelete;
            var temp = new List<Province>();
            foreach (var item in listId)
            {
                var tempProvince = _unitOfWork.Provinces.Get(item.Id);
                if (tempProvince != null)
                {
                    temp.Add(tempProvince);
                }
            }            
            _unitOfWork.Provinces.RemoveRange(temp);
            _unitOfWork.Complete();
            _unitOfWork.Dispose();
            return Ok(_message);
        }

    }
}