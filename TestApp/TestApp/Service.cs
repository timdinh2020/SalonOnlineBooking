using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class Service
    {
        public string title { get; set; }

        public string description { get; set; }

        public float startingPrice { get; set; }

        public List<Service> services { get; set; }

        // constructor
        public Service(string t_, string desc_, float sPrice_)
        {
            title = t_;
            description = desc_;
            startingPrice = sPrice_;
            services = new List<Service>();
        }

        public string AddNewService(Service service_)
        {
            string result = string.Empty;

            services.Add(service_);

            // add the service to the database as a new entry
            result = "The service has been successfully added.";

            return result;
        }

        public string RemoveService(Service service_)
        {
            string result = string.Empty;

            services.Remove(service_);

            // remove the service entry from the database
            result = "The service has been successfully removed.";

            return result;
        }

        public string ModifyService(string service_t, string t_, string desc_, float sPrice_)
        {
            string result = string.Empty;

            int index = -1;

            // loop over all the services
            for(int i = 0; i < services.Count; i++)
            {
                // if the current service's title matches the given title
                if(services[i].title == service_t)
                {
                    // store the index of the current service
                    index = i;
                }
            }

            // if the index of the service to update is valid (not -1)
            if(index != -1)
            {
                // find the service with the matching title in the db

                // if the user entered a new title
                if (t_ != null && t_ != string.Empty)
                {
                    services[index].title = t_;
                    // update the service's title column in the db
                }

                // if the user entered a new description
                if(desc_ != null && desc_ != string.Empty)
                {
                    services[index].description = desc_;
                    // update the service's description column in the db
                }

                // if the user entered a new starting price
                if (sPrice_ != -1)
                {
                    services[index].startingPrice = sPrice_;
                    // update the service's strating price column in the db
                }

                // make a success message
                result = "Service successfully updated!";
            }
            else // if the index of the service to update is invalid (-1)
            {
                // make a failure message
                result = "There is no service with that title. Try again.";
            }

            return result;
        }

        public List<Object> ViewServiceDetails(string t_)
        {
            List<Object> result = new List<Object>();

            int index = -1;

            // loop over all the services
            for (int i = 0; i < services.Count; i++)
            {
                // if the current service's title matches the given title
                if (services[i].title == t_)
                {
                    // store the index of the current service
                    index = i;
                }
            }

            // if the index of the service to update is valid (not -1)
            if (index != -1)
            {
                // store the service's details in a list to return
                result.Add(services[index].title);
                result.Add(services[index].description);
                result.Add(services[index].startingPrice);
            }

            // if the index of the service is invalid (meaning that service doesn't exist),
            //   an empty list is returned

            return result;
        }

        public List<Service> ViewAvailableServices()
        {
            // return the list of services
            return services;
        }
    }
}
