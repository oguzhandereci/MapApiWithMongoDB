using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MapApiWithMongoDB.Models
{
    public class Geo
    {
        public string GeoType { get; set; }
        public List<double> Coordinates { get; set; }
    }
}