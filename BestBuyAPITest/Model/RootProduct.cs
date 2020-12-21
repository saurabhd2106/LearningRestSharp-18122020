using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyAPITest.Model
{
    public class RootProduct
    {
        public int total { get; set; }
        public int limit { get; set; }
        public int skip { get; set; }
        public List<DatumDto> data { get; set; }
    }
}
