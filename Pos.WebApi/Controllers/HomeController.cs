using Pos.Helpers;
using Pos.Model.Core;
using Pos.Repository.DataAccess;
using Pos.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pos.WebApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork _unitOfWork;
        public HomeController()
        {
            _unitOfWork = new UnitOfWork(new DataContext());
        }

        public ActionResult Index()
        {
            
            var data = _unitOfWork.Provinces.GetAll();
            _unitOfWork.Dispose();

            //using (var unitOfWork = new UnitOfWork(new DataContext()))
            //{
            //    //var data = unitOfWork.Provinces.GetTop10();

            //    //var temp = new Province();
            //    //temp.Id = Guid.NewGuid().ToString();
            //    //temp.Name = "Jawa Tengah";
            //    //temp.IsActive = true;
            //    //temp.CreatedBy = "Wildan";
            //    //temp.CreatedDate = DateTime.Now;
            //    //insert
            //    //unitOfWork.Provinces.Add(temp);

            //    //var listProvince = new List<Province>();

            //    //bulk insert
            //    //for (int i = 0; i < 3; i++)
            //    //{
            //    //    temp.Id = Guid.NewGuid().ToString();
            //    //    listProvince.Add(temp);
            //    //}
            //    //unitOfWork.Provinces.AddRange(listProvince);
            //    //unitOfWork.Complete();

            //    //update
            //    //var selecteddata = unitOfWork.Provinces.Get("c800eaf5-753a-4a9b-929c-87b1b17fd8a9");
            //    //selecteddata.UpdatedBy = "Wildan Too";
            //    //selecteddata.UpdatedDate = DateTime.Now;
            //    //unitOfWork.Complete();

            //    //delete
            //    //var dataforRemove = unitOfWork.Provinces.Get("1");
            //    //unitOfWork.Provinces.Remove(dataforRemove);
            //    //unitOfWork.Complete();

            //    //bulk delete

            //    //var listForDelete = new List<string>();
            //    //listForDelete.Add("1");
            //    //listForDelete.Add("2");
            //    //listForDelete.Add("3");

            //    //var selectedForDelete = new List<Province>();
            //    //foreach (var item in listForDelete)
            //    //{
            //    //    var temp = unitOfWork.Provinces.Get(item);
            //    //    selectedForDelete.Add(temp);
            //    //}

            //    //unitOfWork.Provinces.RemoveRange(selectedForDelete);
            //    //unitOfWork.Complete();


            //    //get all paged asdf
            //    var currentPage = 2;
            //    var rowPerPage = 2;
            //    var totalPage = 0;
            //    var data = unitOfWork.Provinces.GetAll().OrderByDescending(c=>c.CreatedDate);
            //    totalPage = data.Count();
            //    var result = data.Skip((currentPage - 1)*rowPerPage).Take(rowPerPage).ToList();
            //    var final = result.Where(c=>c.Name.Contains("ali"));
            //}
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
