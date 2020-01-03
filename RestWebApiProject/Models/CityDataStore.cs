using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWebApiProject.Models
{
    public class CityDataStore
    {
        public static CityDataStore Curren { get; }=new CityDataStore();
        public List<City> Cities { get; set; }

        public CityDataStore()
        {
            Cities = new List<City>()
            {
                new City {Id = 1, Name = "Dhaka", Description = "Dhaka is a good city"},
                new City {Id = 2, Name = "Rajshahi", Description = "Rajshahi is a good city"},
                new City {Id = 3, Name = "Sirajgong", Description = "Sirajgong is a good city"},
            };
        }
    }
}
