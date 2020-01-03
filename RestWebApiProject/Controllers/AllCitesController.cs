using Microsoft.AspNetCore.Mvc;
using RestWebApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWebApiProject.Controllers
{
    [Route("api/[controller]")]
    public class AllCitesController:Controller
    {
        [HttpGet]
        public JsonResult GetAllCites()
        {
            //return new JsonResult(new List<object>
            //{
            //    new {id=1, name="Dhaka"},
            //    new {id=2, name="Rajshahi"},
            //     new {id=3, name="Khulna"}
            //});
            var temp=new JsonResult(CityDataStore.Curren.Cities);
            temp.StatusCode = 200;
            return temp;
        }

        [HttpGet("{id}",Name = "GetCity")]
        public IActionResult GetCites(int id)
        {
            var ReturnCity=CityDataStore.Curren.Cities.FirstOrDefault(x=>x.Id == id);
            if (ReturnCity == null)
            {
                return NotFound();
            }
            return Ok(ReturnCity);
        }

        [HttpPost]
        public IActionResult PostCity([FromBody] City item)
        {
            CityDataStore.Curren.Cities.Add(item);
            return CreatedAtRoute("GetCity", new {id=item.Id},item);
        }

        [HttpPut("{id}")]
        public IActionResult PutCity(int id, [FromBody] City item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            if (item.Name == null & item.Description == null)
            {
                return BadRequest();
            }

            var data = CityDataStore.Curren.Cities.FirstOrDefault(c => c.Id == id);
            if (data == null)
            {
                return NotFound();
            }

            data.Name = item.Name;
            data.Description = item.Description;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult deleteCity(int id)
        {
            var data = CityDataStore.Curren.Cities.FirstOrDefault(c => c.Id == id);
            if (data == null)
            {
                return BadRequest();
            }

            CityDataStore.Curren.Cities.Remove(data);
            return NoContent();
        }
    }
}
