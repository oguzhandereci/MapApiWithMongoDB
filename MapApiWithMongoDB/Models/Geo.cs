﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MapApiWithMongoDB.Models
{
    public class Geo
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }
}