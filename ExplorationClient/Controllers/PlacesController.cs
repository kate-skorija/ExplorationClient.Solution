using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExplorationClient.Models;

namespace ExplorationClient.Controllers
{
  public class PlacesController : Controller
  {
    public IActionResult Index()
    {
      var allPlaces = Place.GetPlaces();
      return View(allPlaces);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Place place)
    {
      Place.Post(place);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var thisPlace = Place.GetDetails(id);
      return View(thisPlace);
    }
    public IActionResult Edit(int id)
    {
      var place = Place.GetDetails(id);
      return View(place);
    }

    [HttpPost]
    public IActionResult Details(int id, Place place)
    {
      place.PlaceId = id;
      Place.Put(place);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      Place.Delete(id);
      return RedirectToAction("Index");
    }
  }
}
