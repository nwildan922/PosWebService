using Pos.Helpers;
using Pos.Helpers.Helper;
using Pos.Model.Core;
using Pos.Repository.DataAccess;
using Pos.Repository.UnitOfWork;
using Pos.WebApi.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Pos.WebApi.Controllers
{
    [RoutePrefix("api/City")]
    [DeflateCompression]
    public class CityController : BaseApiController
    {

        private readonly UnitOfWork _unitOfWork;
        public CityController()
        {
            _controllerName = "CityController";
            _unitOfWork = new UnitOfWork(new DataContext());
        }
        [HttpGet]
        [Route(nameof(GetAll))]
        public IHttpActionResult GetAll()
        {            
            var data = _unitOfWork.Cities.GetAll();            
            var json = JilHelper.Serialize(data);            
            return Ok(json);
        }

        [HttpGet]
        [Route(nameof(Get))]
        public IHttpActionResult Get(string id)
        {
            var data = _unitOfWork.Cities.Get(id);
            var json = JilHelper.Serialize(data);
            return Ok(json);
        }

        [HttpPost]
        [Route(nameof(Submit))]
        public IHttpActionResult Submit(City model)
        {
            string _message = "";
            
            if (GlobalHelper.IsNullHelper(model.Name))
            {
                _message = "Name is empty";
                return BadRequest(_message);
            }
            if (GlobalHelper.IsNullHelper(model.ProvinceId))
            {
                _message = "Province is empty";
                return BadRequest(_message);
            }
            try
            {
                
                if (model.Id == "")
                {
                    var data = new City();
                    data.Id = Guid.NewGuid().ToString();
                    data.Name = model.Name;
                    data.ProvinceId = model.ProvinceId;
                    data.IsActive = model.IsActive;
                    data.CreatedBy = "admin insert";
                    data.CreatedDate = DateTime.Now;
                    _unitOfWork.Cities.Add(data);
                    _unitOfWork.Complete();
                    _unitOfWork.Dispose();
                    _message = GlobalResources.MsgSave;
                }
                else
                {
                    var data = new City();
                    data = _unitOfWork.Cities.Get(model.Id);
                    data.Name = model.Name;
                    data.IsActive = model.IsActive;
                    data.ProvinceId = model.ProvinceId;
                    data.UpdatedBy = "admin update";
                    data.UpdatedDate = DateTime.Now;
                    _unitOfWork.Complete();
                    _unitOfWork.Dispose();
                    _message = GlobalResources.MsgUpdate;
                }
            }
            catch (Exception exc)
            {
                _actionName = "Insert Or Update";
                _message = exc.ToString();
                Log.Write(_controllerName,_actionName,_message);
            }


            return Ok(_message);
        }

        [HttpPost]
        [Route(nameof(Delete))]
        public IHttpActionResult Delete(string id)
        {
            _message = GlobalResources.MsgDelete;
            var temp = _unitOfWork.Cities.Get(id);
            _unitOfWork.Cities.Remove(temp);
            _unitOfWork.Complete();
            _unitOfWork.Dispose();
            return Ok(_message);
        }

        [HttpPost]
        [Route(nameof(DeleteRange))]
        public IHttpActionResult DeleteRange(List<City> listId)
        {
            _message = GlobalResources.MsgDelete;
            var temp = new List<City>();
            foreach (var item in listId)
            {
                var tempData = _unitOfWork.Cities.Get(item.Id);
                if (tempData != null)
                {
                    temp.Add(tempData);
                }
            }            
            _unitOfWork.Cities.RemoveRange(temp);
            _unitOfWork.Complete();
            _unitOfWork.Dispose();
            return Ok(_message);
        }

    }
}