using MapApiWithMongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MapApiWithMongoDB.Actions;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace MapApiWithMongoDB.Controllers
{
    public class MapController : ApiController
    {
        [HttpGet]
        public async Task<List<Poi>> GetPoiList(double longitude, double latitude, double distance)
        {
            return await MapActions.GetPOIList(longitude, latitude, distance);
        }

        [HttpGet]
        public async Task<List<Poi>> GetPoiListWithCat(double longitude, double latitude, double distance, string cat)
        {
            return await MapActions.GetPOIListWithCat(longitude, latitude, distance, cat);
        }

        [HttpGet]
        public async Task<Neighbourhood> GetNeighbourHood(double longitude, double latitude)
        {
            return await MapActions.GetNeighbourhoodWithLoc(longitude, latitude);
        }


        [HttpGet]
        public async Task<List<Poi>> GetPoiListWithNeighbourhood(int? hoodId, string hoodName = "")
        {
            return await MapActions.GetPoiListWithNeighbourhood(hoodId,hoodName);
        }
    }
}
