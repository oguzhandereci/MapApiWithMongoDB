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
        public string Id { get; set; }
        public string Adi { get; set; }
        public string Kategori { get; set; }
        public string UstKategori { get; set; }
        public int Il_Id { get; set; }
        public int Ilce_Id { get; set; }
        public int Mah_Id { get; set; }
        public int Basar_Id { get; set; }
        public int Ilcs_Id { get; set; }
        public int YolId { get; set; }
        public string YolAdi { get; set; }
        public int Vrs { get; set; }

        public Geo Geo { get; set; }


    }
}