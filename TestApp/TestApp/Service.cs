using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class Service
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string StartingPrice { get; set; }

        public Service[] Services { get; set; }

        public Service(string title, string desc, string sPrice)
        {
            Title = title;
            Description = desc;
            StartingPrice = sPrice;
            Services = new Service[Services.Length];
        }
    }
}
