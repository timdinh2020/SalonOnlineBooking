using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TestApp
{
    public class Appointment
    {
        [BsonElement("_id")]
        public BsonObjectId Id { get; set; }

        [BsonElement("date")]
        public string date { get; set; }

        [BsonElement("time")]
        public string time { get; set; }

        [BsonElement("hairdresser")]
        public Account hairdresser { get; set; }

        [BsonElement("member")]
        public Account member { get; set; }

        [BsonElement("services")]
        public List<Service> services { get; set; }

        public string MakeAppointment(DateTime date_and_time, Account hairdresser_, Account member_, List<Service> services_)
        {
            string result = string.Empty;

            // create a new mongo object
            mongodb db = new mongodb();

            // get all of the given member's and hairdresser's outstanding appointments
            var memAppts = db.db_getApptsByEmail(member_.email);
            var hairAppts = db.db_getApptsByEmail(hairdresser_.email);

            // if the member has any outstanding appointments
            if(memAppts.Count() > 0)
            {
                // loop over each of the appointments
                for(int i = 0; i < memAppts.Count(); i++)
                {
                    // if the current appointment's date matches the given date
                    if(memAppts[i].date == date_and_time.ToShortDateString())
                    {
                        // if the current appointment's time matches the given time
                        if(memAppts[i].time == date_and_time.ToShortTimeString())
                        {
                            // report creation error message
                            result = "Appointment creation failed. You already have a scheduled appointment for this date and time.";

                            return result;
                        }
                    }
                }
            }

            // if the hairdresser has any outstanding appointments
            if (hairAppts.Count() > 0)
            {
                // loop over each of the appointments
                for (int i = 0; i < hairAppts.Count(); i++)
                {
                    // if the current appointment's date matches the given date
                    if (hairAppts[i].date == date_and_time.ToShortDateString())
                    {
                        // if the current appointment's time matches the given time
                        if (hairAppts[i].time == date_and_time.ToShortTimeString())
                        {
                            // report creation error message
                            result = "Appointment creation failed. This hairdresser already has a scheduled appointment for this date and time.";

                            return result;
                        }
                    }
                }
            }

            // create a new appointment object using the given information
            var appointment = new Appointment()
            {
                date = date_and_time.ToShortDateString(),
                time = date_and_time.ToShortTimeString(),
                hairdresser = hairdresser_,
                member = member_,
                services = services_
            };

            // add the new appointment to the database
            db.db_createAppt(appointment);

            // report successful creation message
            result = "Success";

            // return the message
            return result;
        }

        public string CancelAppointment(BsonObjectId Id_)
        {
            string result = string.Empty;

            mongodb db = new mongodb();

            var appt = db.db_getApptById(Id_);

            // if the appointment exists
            if (appt != null)
            {
                // delete the appointment from the db
                db.db_deleteApptById(appt.Id);

                // report successful cancellation message 
                result = "Success";
            }
            else // if the appointment does not exist
            {
                // report non-existing appointment error message
                result = "Appointment cancellation failed. No appointment exists with that Id.";
            }

            // return the message
            return result;
        }

        public List<Appointment> ViewAppointments(string email_)
        {
            List<Appointment> result = new List<Appointment>();
            
            mongodb db = new mongodb();

            // get all of the given account email's outstanding appointments
            var appts = db.db_getApptsByEmail(email_);

            // if there are any outstanding appointments
            if(appts.Count > 0)
            {
                // loop over the outstanding appointments
                for (int i = 0; i < appts.Count(); i++)
                {
                    // convert the current appointment's date and time into DateTime objects
                    DateTime apptDate = DateTime.Parse(appts[i].date);
                    DateTime apptTime = DateTime.Parse(appts[i].time);

                    // construct a complete DateTime object using the date info and time info
                    DateTime appt = new DateTime(apptDate.Year, apptDate.Month, apptDate.Day, apptTime.Hour, apptTime.Minute, apptTime.Second);

                    // compare the date and time of the current appointment to today's date and current time
                    var apptAge = DateTime.Compare(appt, DateTime.Now);

                    // if the current appointment's date and time is older than today's date and current time (appointment passed)
                    if(apptAge < 0)
                    {
                        // delete the current appointment from the db
                        db.db_deleteApptById(appts[i].Id);

                        // remove the current appointment from the list of outstanding appointments
                        appts.RemoveAt(i);
                    }
                }
            }

            // set the result to the updated list of outstanding appointments
            result = appts;

            return result;
        }

        public string ModifyAppointment(BsonObjectId Id_, DateTime date_and_time, List<Service> services_)
        {
            string result = string.Empty;
            bool noDate = false;
            bool hairSameTime = false;
            int index = -1;

            mongodb db = new mongodb();

            // get the outstanding appointment in the db
            var appt = db.db_getApptById(Id_);

            // if the appointment exists
            if(appt != null)
            {
                // get all of the member's and hairdresser's outstanding appointments
                var memAppts = db.db_getApptsByEmail(appt.member.email);
                var hairAppts = db.db_getApptsByEmail(appt.hairdresser.email);

                // loop over the member's appointments
                for (int i = 0; i < memAppts.Count(); i++)
                {
                    // if the given date and time is null (shouldn't be changed)
                    if (date_and_time == null)
                    {
                        // mark that there is no date to update
                        noDate = true;

                        // exit this loop
                        break;
                    }

                    // if the current appointment's date matches the given date
                    if (memAppts[i].date == date_and_time.ToShortDateString())
                    {
                        // if the current appointment's time matches the given time
                        if (memAppts[i].time == date_and_time.ToShortTimeString())
                        {
                            // store the index of the current member appointment
                            index = i;

                            break;
                        }
                    }
                }

                // if the member has an appointment that matches the given date and time
                if (index != -1)
                {
                    // report already scheduled appointment (date and time not updated)
                    result = "You already have a scheduled appointment for this date and time. ";
                }
                else if(!noDate) // if there is a date and time to update
                {
                    // loop over the hairdresser's appointments
                    for (int i = 0; i < hairAppts.Count(); i++)
                    {
                        // if the current appointment's date matches the given date
                        if (hairAppts[i].date == date_and_time.ToShortDateString())
                        {
                            // if the current appointment's time matches the given time
                            if (hairAppts[i].time == date_and_time.ToShortTimeString())
                            {
                                // mark that the hairdresser already has an appointment scheduled for the given date and time
                                hairSameTime = true;

                                break;
                            }
                        }
                    }

                    // if the hairdresser already has an appointment scheduled for the given date and time
                    if(hairSameTime)
                    {
                        // repory already scheduled appointment (date and time not updated)
                        result = "Your hairdresser already has a scheduled appointment for this date and time. ";
                    }
                    else // if the hairdresser doesn't have an appointment scheduled for the given date and time
                    {
                        // update the appointment's date to the new date
                        db.db_updateApptById(appt.Id, "date", date_and_time.ToShortDateString());

                        // update the appointment's time to the new time
                        db.db_updateApptById(appt.Id, "time", date_and_time.ToShortTimeString());

                        // report successful date and time update message
                        result = "Appointment date and time successfully updated. ";
                    }
                }

                // if the given list of services is not null (should be changed)
                if (services_ != null)
                {
                    // store the appointment's list of services
                    var currServs = appt.services;

                    // the number of matching services
                    var numMatches = 0;

                    // loop over each of the appointment's services
                    for(int i = 0; i < currServs.Count(); i++)
                    {
                        // loop over each of the given services
                        for (int j = 0; j < services_.Count(); j++)
                        {
                            // if the current appointment service's title matches the current given service's title
                            if (currServs[i].title == services_[j].title)
                            {
                                // increment the number of matching services
                                numMatches++;

                                break;
                            }
                        }
                    }

                    // if the number of matches is the same as the size of the appointment's list of services (the services are the same)
                    if (numMatches == currServs.Count())
                    {
                        // report matching services (services not updated)
                        result += "Old appointment services match the new services; services not updated.";
                    }
                    else // if the number of matches differ from the size of the appointment's list of services
                    {
                        // update the appointment's list of services to the new given service list
                        db.db_updateApptById(appt.Id, "services", services_);

                        // report successful service update message
                        result += "Appointment services successfully updated.";
                    }
                }
            }
            else // if the appointment does not exist
            {
                // report non-existing appointment error message
                result = "Appointment modification failed. No appointment exists with that Id.";
            }

            // trim the result string
            result = result.Trim();

            return result;
        }
    }
}
