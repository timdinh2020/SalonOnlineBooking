using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TestApp
{
    public class Service
    {
        [BsonElement("_id")]
        public BsonObjectId Id { get; set; }

        [BsonElement("title")]
        public string title { get; set; }

        [BsonElement("description")]
        public string description { get; set; }

        [BsonElement("s_price")]
        public double startingPrice { get; set; }

        [BsonElement("master_service")]
        public string masterService { get; set; }

        [BsonElement("sub_services")]
        public List<Service> subServices { get; set; }

        // constructor (makes a new service)
        public Service(string t_, string desc_, double sPrice_, string masterServ)
        {
            mongodb db = new mongodb();

            title = t_;
            description = desc_;
            startingPrice = sPrice_;
            subServices = new List<Service>();
            masterService = masterServ;

            // try to get an existing service in the db that has the same title
            var master = db.db_getServByTitle(title);

            // if there is no existing service with a matching title
            if (master == null)
            {
                // add this service to the db
                db.db_createServ(this);
            }
        }

        // adds a service to this service's subservice list
        public string AddNewService(Service service_)
        {
            string result = string.Empty;

            mongodb db = new mongodb();

            // get the existing service in the db that has this title
            var master = db.db_getServByTitle(title);

            // if the service exists
            if (master != null)
            {
                // if this service isn't the same as the given service AND this service is marked as the given service's master
                if (master.title != service_.title && master.title == service_.masterService)
                {
                    // loop over each sub service of this service
                    for (int i = 0; i < master.subServices.Count(); i++)
                    {
                        // if the current sub service's title matches the given service's title (the service has already been added)
                        if (master.subServices[i].title == service_.title)
                        {
                            // report a duplicate error message
                            result = "Duplicate sub service detected. Sub service addition failed.";
                            return result;
                        }
                    }

                    // add the given service to this service's list of sub services
                    subServices.Add(service_);

                    // update this service's db entry with the new sub services list
                    db.db_updateServById(master.Id, "sub_services", subServices);

                    // report successful addition message
                    result = "Success";
                }
                else if (master.title == service_.title) // if this service is the same as the given service
                {
                    // report service loop error message (a service cannot be its own master and sub service)
                    result = "Sub service addition failed. Cannot make this service a sub service of itself.";
                }
                else // if this service isn't marked as the given service's master
                {
                    // report master mismatch error message
                    result = "Sub service addition failed. The new service's master service must match this service's title.";
                }
            }
            else // if the service doesn't exist (this should be impossible but just in case)
            {
                // report unexpected error message
                result = "Unexpected error. Addition failed.";
            }

            return result;
        }

        public string RemoveService(string t_, bool modified)
        {
            string result = string.Empty;

            mongodb db = new mongodb();

            var master = db.db_getServByTitle(title);

            if (master != null)
            {
                int index = -1;

                // loop over this services sub services
                for (int i = 0; i < subServices.Count(); i++)
                {
                    // if the current sub service's title matches the given service title
                    if (subServices[i].title == t_)
                    {
                        // store the service's index
                        index = i;

                        // exit this loop
                        break;
                    }
                }

                // if a matching service was found
                if (index != -1)
                {
                    // remove the service at that index from this service's list of sub services
                    subServices.RemoveAt(index);

                    // update this service's db entry with the new sub services list
                    db.db_updateServById(master.Id, "sub_services", subServices);

                    // if the service was marked as not modified (don't delete the service entry during modification)
                    if (!modified)
                    {
                        // delete the service with the matching title from the db
                        db.db_deleteServByTitle(t_);
                    }

                    // report successful removal message
                    result = "Success";
                }
                else // if a matching service was not found
                {
                    // report non-existing service error message
                    result = "Service removal failed. That service does not exist.";
                }
            }
            else
            {
                // report unexpected error message
                result = "Unexpected error. Removal failed.";
            }

            return result;
        }

        public string ModifyService(string t_, string desc_, double sPrice_, string masterServ, List<Service> servs)
        {
            string result = string.Empty;

            mongodb db = new mongodb();

            // get the existing service in the db that has this title
            var thisServ = db.db_getServByTitle(title);

            // if the service exists in the db
            if (thisServ != null)
            {
                // store this service's original title and master service
                string origTitle = thisServ.title;
                string origMaster = thisServ.masterService;

                // if the user entered a title to update
                if (t_ != null && t_ != string.Empty)
                {
                    // set this service's title to the new title
                    title = t_;

                    // update this service's title column in the db
                    db.db_updateServById(thisServ.Id, "title", t_);
                }

                // if the user entered a description to update
                if (desc_ != null && desc_ != string.Empty)
                {
                    // set this service's description to the new description
                    description = desc_;

                    // update this service's description column in the db
                    db.db_updateServById(thisServ.Id, "description", desc_);
                }

                // if the user entered a starting price to update (anything negative is ignored)
                if (sPrice_ >= 0)
                {
                    // set this service's starting price to the new starting price
                    startingPrice = sPrice_;

                    // update this service's starting price column in the db
                    db.db_updateServById(thisServ.Id, "s_price", sPrice_);
                }

                // if the user entered a sub service list to update
                if (servs != null)
                {
                    // set this service's sub service list to the new sub service list
                    subServices = servs;

                    // update this service's sub service column in the db
                    db.db_updateServById(thisServ.Id, "sub_services", servs);
                }

                // if a user entered a new master service to update (isn't the same as the current master)
                if (masterServ != null && masterServ != string.Empty && masterServ != origMaster)
                {
                    // get this service's new master service
                    var newMaster = db.db_getServByTitle(masterServ);

                    // if the master service exists
                    if (newMaster != null)
                    {
                        // set this service's master service to the new master service
                        masterService = masterServ;

                        // update this service's master service column in the db
                        db.db_updateServById(thisServ.Id, "master_service", masterService);

                        // add this service to the new master service's sub service list
                        newMaster.AddNewService(this);

                        // if this service had an original master service (it should but just in case)
                        if (origMaster != null || origMaster != string.Empty)
                        {
                            // get this service's original master service
                            var oldMaster = db.db_getServByTitle(origMaster);

                            // if the original master service exists
                            if (oldMaster != null)
                            {
                                // remove this service (via its original title) from the original master service's sub service list (but not entirely)
                                oldMaster.RemoveService(origTitle, true);
                            }
                        }

                        // make a success message
                        result = "Success";
                    }
                    else // if the master service does not exist (can't add to a service that isn't real)
                    {
                        // report non-existing master service error message
                        result = "Modification failed. The given master service does not exist.";
                    }
                }
                else // if the user didn't enter a new master service to update (either nothing or the current one)
                {
                    // get this service's original master service
                    var oldMaster = db.db_getServByTitle(origMaster);

                    // if the master service exists
                    if (oldMaster != null)
                    {
                        // loop over each of the master service's sub services
                        for (int i = 0; i < oldMaster.subServices.Count(); i++)
                        {
                            // if the current sub service's title matches this service's original title (sub service instance must be updated)
                            if (oldMaster.subServices[i].title == origTitle)
                            {
                                // create a new copy of the master service's sub service list 
                                var newServices = oldMaster.subServices;

                                // update all details for this service in the current sub service in the new copy (make the instances match)
                                newServices[i].title = title;
                                newServices[i].description = description;
                                newServices[i].startingPrice = startingPrice;
                                newServices[i].subServices = subServices;
                                newServices[i].masterService = masterService;

                                // update the master service's sub service column in the db
                                db.db_updateServById(oldMaster.Id, "sub_services", newServices);

                                break;
                            }
                        }
                    }

                    // make a success message
                    result = "Success";
                }
            }
            else // if the service doesn't exist in the db
            {
                // report unexpected error message
                result = "Unexpected error. Modification failed.";
            }

            return result;
        }

        public List<Object> ViewServiceDetails()
        {
            List<Object> result = new List<Object>();

            // store this service's details in a list to return
            result.Add(title);
            result.Add(description);
            result.Add(startingPrice);
            result.Add(masterService);
            result.Add(subServices);

            return result;
        }

        public List<Service> ViewAvailableServices()
        {
            // return the list of this service's sub services
            return subServices;
        }
    }
}
