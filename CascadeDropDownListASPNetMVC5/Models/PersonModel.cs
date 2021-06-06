using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CascadeDropDownListASPNetMVC5.Models
{
    public class PersonModel
    {
        public string CountryId { get; set; }
        public string StateId { get; set; }
        public string CityId { get; set; }
        public SelectList Countries { get; set; }
        public SelectList States { get; set; }
        public SelectList Cities { get; set; }
    }
}