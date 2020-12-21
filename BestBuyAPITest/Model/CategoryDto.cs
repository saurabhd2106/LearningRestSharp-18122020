using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyAPITest.Model
{
    public class CategoryDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
