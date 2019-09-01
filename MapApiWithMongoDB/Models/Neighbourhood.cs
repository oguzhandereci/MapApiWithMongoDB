using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MapApiWithMongoDB.Models
{
    public class Neighbourhood
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public int MAH_ID { get; set; }
        public int ILCE_ID { get; set; }
        public string ADI { get; set; }
        public double LONGX { get; set; }
        public double LATY { get; set; }
        public int POSTAKODU { get; set; }
        public int NUFUS { get; set; }
        public int VRS { get; set; }
        public int UAVTKODU { get; set; }
        public BsonDocument GEO { get; set; }

    }
}