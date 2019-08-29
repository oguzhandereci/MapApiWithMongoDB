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
        public string Id { get; set; }
        public int MahId { get; set; }
        public int IlceId{ get; set; }
        public string MahAdi { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int PostCode { get; set; }
        public int Nufus { get; set; }
        public int Vrs { get; set; }
        public int UavtKodu { get; set; }
        public Geo Geo { get; set; }

    }
}