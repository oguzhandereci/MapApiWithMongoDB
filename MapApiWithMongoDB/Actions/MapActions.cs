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
        public static List<BsonDocument> GetPOIList(double LongX,double LatY,double dist)
        {
            var db = client.GetDatabase("ADR1901");
            var collection = db.GetCollection<BsonDocument>("POI");
            var filter = Builders<BsonDocument>.Filter.GeoWithinCenterSphere("GEO", LongX, LatY, dist / 6378100);

            var poiList = collection.Find(filter).ToList();
            return poiList;
        }

        public static async Task<List<BsonDocument>> GetPOIListWithCat(double longX, double latY, double dist,string cat)
        {
            var db = client.GetDatabase("ADR1901");
            var collection = db.GetCollection<BsonDocument>("POI");
            var filter = Builders<BsonDocument>.Filter.GeoWithinCenterSphere("GEO", longX, latY, dist / 6378100) & Builders<BsonDocument>.Filter.Eq("KATEGORI",cat);

            var poiList =await collection.Find(filter).ToListAsync();
            return poiList;
        }

        public static async Task<BsonDocument> GetNeighbourhoodWithLoc(double longX, double latY)
        {
            var db = client.GetDatabase("ADR1901");
            var collection = db.GetCollection<BsonDocument>("MAHALLE");
            var geometry = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(new GeoJson2DGeographicCoordinates(longX, latY));
            var filter = Builders<BsonDocument>.Filter.GeoIntersects<GeoJson2DGeographicCoordinates>("GEO", geometry);

            var neighbourhood = await collection.Find(filter).FirstAsync<BsonDocument>();
            return neighbourhood;
        }
    }
}