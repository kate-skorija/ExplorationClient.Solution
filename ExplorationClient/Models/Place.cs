using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExplorationClient.Models
{
  public class Place
  {
    public int PlaceId { get;set; }
    public string Name { get;set; }
    public string UserName { get;set; }
    public int Rating { get;set; }
    public string Description { get;set; }
    public string Country { get;set; }
    
    public static List<Place> GetPlaces()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Place> placeList = JsonConvert.DeserializeObject<List<Place>>(jsonResponse.ToString());

      return placeList;
    }
  }
}