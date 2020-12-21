using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyAPITest.Model.SampleData
{
   

    public class EmployeeDetails
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public long employeeId { get; set; }
        public List<long> phoneNumber { get; set; }
        public List<Address> address { get; set; }
    }
}
