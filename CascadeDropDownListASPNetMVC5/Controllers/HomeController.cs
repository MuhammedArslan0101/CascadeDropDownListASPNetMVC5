using CascadeDropDownListASPNetMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CascadeDropDownListASPNetMVC5.Controllers
{
    public class HomeController : Controller
    {
        public DataContext db = new DataContext();
        public ActionResult Index(int? defaultCountryId = 1)
        {
            PersonModel model = new PersonModel();
            //get all country
            var allCountrylist = db.Countrys.ToList();
            //get all states according to defaultCountryId
            var allStatelist = db.States.Where(m => m.CountryId == defaultCountryId).ToList();
            //set defaultStateId
            var defaultStateId = allStatelist.Select(m => m.StateId).FirstOrDefault();
            //Get all cities according to defaultStateId
            var allCitylist = db.Citys.Where(m => m.StateId == defaultStateId).ToList();
            //set defaultCityId 
            var defaultCityId = allCitylist.Select(m => m.CityId).FirstOrDefault();
            model.Countries = new SelectList(allCountrylist, "CountryId", "CountryName", defaultCountryId);
            model.States = new SelectList(allStatelist, "StateId", "StateName", defaultStateId);
            model.Cities = new SelectList(allCitylist, "CityId", "CityName", defaultCityId);
            return View(model);
        }
        [HttpPost]
        public JsonResult setDropDrownList(string type, int value)
        {
            PersonModel model = new PersonModel();
            switch (type)
            {
                case "CountryId":
                    var statesList = db.States.Where(m => m.CountryId == value).ToList();
                    model.States = new SelectList(statesList, "StateId", "StateName");
                    var defaultStateId = statesList.Select(m => m.StateId).FirstOrDefault();
                    model.Cities = new SelectList(db.Citys.Where(m => m.StateId == defaultStateId).ToList(), "CityId", "CityName");
                    break;
                case "StateId":
                    model.Cities = new SelectList(db.Citys.Where(m => m.StateId == value).ToList(), "CityId", "CityName");
                    break;
            }
            return Json(model);
        }
        [HttpPost]
        public ActionResult Index(PersonModel model)
        {
            model.Countries = new SelectList(db.Countrys.ToList(), "CountryId", "CountryName", model.CountryId);
            model.States = new SelectList(db.States.Where(m => m.CountryId.ToString() == model.CountryId).ToList(), "StateId", "StateName", model.StateId);
            model.Cities = new SelectList(db.Citys.Where(m => m.StateId.ToString() == model.StateId).ToList(), "CityId", "CityName", model.CityId);
            return View(model);
        }
    }
}
