using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MapApiWithMongoDB.Models
{
    public class Poi
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string ADI { get; set; }
        public string KATEGORI { get; set; }
        public string USTKATEGORI { get; set; }
        public int IL_ID { get; set; }
        public int ILCE_ID { get; set; }
        public int MAH_ID { get; set; }
        public int BASAR_ID { get; set; }
        public int ILCS_ID { get; set; }
        public int YOLID { get; set; }
        public string YOLADI { get; set; }
        public int VRS { get; set; }

        public Geo GEO { get; set; }


    }
}