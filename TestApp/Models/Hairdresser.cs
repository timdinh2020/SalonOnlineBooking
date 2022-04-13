using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class Hairdresser : Models.Account
    {
        public string Role = "hair-dresser";
        public DateTime[] AvailableDays { get; set; }
        public DateTime[] AvailableTimes { get; set; }

        public DateTime[] ViewAvailability(DateTime[] availableDays, DateTime[] availableTimes)
        {
            DateTime[] result = { DateTime.Now };

            return result;
        }
        public DateTime[] ModifyAvailability(DateTime[] availableDays, DateTime[] availableTimes)
        {
            DateTime[] result = { DateTime.Now };

            return result;
        }
        public string AddNewHairdresser(string username, DateTime[] availableDays, DateTime[] availableTimes)
        {
            string result = string.Empty;

            return result;
        }
        public string RemoveHairdresser(string username)
        {
            string result = string.Empty;

            return result;
        }
    }
}
