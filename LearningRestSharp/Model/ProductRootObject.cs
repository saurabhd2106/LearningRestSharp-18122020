using System;
using System.Collections.Generic;
using System.Text;

namespace LearningHttpClient.Model.JsonModel
{
   public class ProductRootObject
    {

        public int total { get; set; }
        public int limit { get; set; }
        public int skip { get; set; }
        public List<Datum> data { get; set; }
    }
}
