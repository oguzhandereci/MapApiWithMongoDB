using MapApiWithMongoDB.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MongoDB.Bson.Serialization;
using MongoDB.Driver.Linq;
using Poi = MapApiWithMongoDB.Models.Poi;

namespace MapApiWithMongoDB.Actions
{
    public class MapActions
    {
        public static MongoClient client = new MongoClient("mongodb://localhost:27017");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="LongX"></param>
        /// <param name="LatY"></param>
        /// <param name="dist"></param>
        /// <returns></returns>
        public static async Task<List<Poi>> GetPOIList(double LongX,double LatY,double dist)
        {
            var db = client.GetDatabase("ADR1901");
            var collection = db.GetCollection<BsonDocument>("POI");
            var filter = Builders<BsonDocument>.Filter.GeoWithinCenterSphere("GEO", LongX, LatY, dist / 6378100);

            var result =  await collection.Find(filter).ToListAsync();
            var poiList = new List<Poi>();

            foreach (var item in result)
            {
                var poi = BsonSerializer.Deserialize<Poi>(item);
                poiList.Add(poi);
            }
            return poiList;
        }

        public static async Task<List<Poi>> GetPOIListWithCat(double longX, double latY, double dist,string cat)
        {
            var db = client.GetDatabase("ADR1901");
            var collection = db.GetCollection<BsonDocument>("POI");
            var filter = Builders<BsonDocument>.Filter.GeoWithinCenterSphere("GEO", longX, latY, dist / 6378100) & Builders<BsonDocument>.Filter.Eq("KATEGORI",cat);

            var result = await collection.Find(filter).ToListAsync();
            var poiList = new List<Poi>();

            foreach (var item in result)
            {
                var poi = BsonSerializer.Deserialize<Poi>(item);
                poiList.Add(poi);
            }
            return poiList;
        }

        public static async Task<Neighbourhood> GetNeighbourhoodWithLoc(double longX, double latY)
        {
            var db = client.GetDatabase("ADR1901");
            var collection = db.GetCollection<BsonDocument>("MAHALLE");
            var geometry = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(new GeoJson2DGeographicCoordinates(longX, latY));
            var filter = Builders<BsonDocument>.Filter.GeoIntersects<GeoJson2DGeographicCoordinates>("GEO", geometry);

            var result = await collection.Find(filter).FirstAsync<BsonDocument>();
            var neighbourhood = BsonSerializer.Deserialize<Neighbourhood>(result);

            return neighbourhood;
        }

        public static async Task<List<Poi>> GetPoiListWithNeighbourhood(int? hoodId, string hoodName="")
        {
            var db = client.GetDatabase("ADR1901");
            var collection = db.GetCollection<BsonDocument>("MAHALLE");
            var poiCollection = db.GetCollection<BsonDocument>("POI");
            List<Poi> listOfPoiInHood = new List<Poi>();

            if (hoodName != "")
            {
                foreach (var item in collection.Find(x=>true).ToList())
                {
                    
                    var hood = BsonSerializer.Deserialize<Neighbourhood>(item);
                    if (hood.ADI == hoodName)
                    {
                        listOfPoiInHood = await collection.Aggregate().Lookup(foreignCollection: poiCollection,
                            localField: x => hoodId, foreignField: y => hoodId, @as: (Poi p) => "POIs").ToListAsync();
                    }
                }
            }
            //else if (hoodId != null)
            //{
                
            //}

            return listOfPoiInHood;
        }
    }
}