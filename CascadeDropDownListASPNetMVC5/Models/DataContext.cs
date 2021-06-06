using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CascadeDropDownListASPNetMVC5.Models
{
    public class DataContext : DbContext
    {

        public DataContext() : base("dataConnection")
        {
        }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Citys { get; set; }
    }
}