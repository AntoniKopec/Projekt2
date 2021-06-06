using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using Restaurator.Models.Models;

namespace Restaurator.Controllers
{
    public class PlaceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [ActionName("place")]
        [HttpGet]
        public ActionResult Sum_get()
        {
            return View();
        }
        [ActionName("place")]
        [HttpPost]
        public ActionResult Sum_post(string cn)
        {
            string City_Name = cn;
            var doc = XElement.Load($"https://maps.googleapis.com/maps/api/place/textsearch/xml?key=AIzaSyDuzPcOAZnhzFy4tt1YMLI65d2zXVYfOrs&query=restaurants+in+{City_Name}&language=pl&fields=place_id");
            IEnumerable<PlaceIdModel> IdList = doc.Descendants("result").Select(n => new PlaceIdModel
            {
                PlaceId = n.Element("place_id").Value
            });

            var placeDetailsModel = new List<PlaceDetailsModel>();
            foreach (var item in IdList)
            {
                var doc2 = XElement.Load($"https://maps.googleapis.com/maps/api/place/details/xml?key=AIzaSyDuzPcOAZnhzFy4tt1YMLI65d2zXVYfOrs&place_id={item.PlaceId}&language=pl&fields=name,vicinity,geometry/location,rating,website,opening_hours/weekday_text");
                placeDetailsModel.AddRange(doc2.Descendants("result").Select(x => new PlaceDetailsModel
                {
                    Name = x.Element("name").Value,
                    Vicinity = x.Element("vicinity").Value,
                    Rating = x.Element("rating").Value,
                    Website = x.Element("website").Value,
                    Lat = x.Element("geometry").Element("location").Element("lat").Value,
                    Lng = x.Element("geometry").Element("location").Element("lng").Value,
                    Opening_hours = x.Descendants("weekday_text").Select(y => y.Value).ToList()
                }));
            }
            string markers = "[";
            foreach (var item in placeDetailsModel)
            {
                markers += "{";
                markers += string.Format("'title': '{0}',", item.Name);
                markers += string.Format("'lat': '{0}',", item.Lat);
                markers += string.Format("'lng': '{0}',", item.Lng);
                markers += string.Format("'description': '{0}'", item.Vicinity);
                markers += "},";
            }
            markers += "];";
            ViewBag.Markers = markers;
            ViewBag.pd = placeDetailsModel;
            return View();
        }
    }
}
