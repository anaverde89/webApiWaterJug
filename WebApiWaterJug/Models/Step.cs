using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiWaterJug.Models
{
    public class Step
    {
        public int bucketX { get; set; }
        public int bucketY { get; set; }
        public string explanation { get; set; }
    }

    public class Response
    {
        public string status { get; set; }
        public Step[] steps { get; set; }
        public string message { get; set; }
    }
}