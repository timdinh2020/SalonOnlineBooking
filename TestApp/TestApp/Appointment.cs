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

        public string MakeApppointment(string email_, string password_)
        {
            string result = string.Empty;

            // create a new mongo object
            mongodb db = new mongodb();

            // return the message
            return result;
        }

        public string CancelAppointment(string firstName_, string lastName_, string role_, string email_, string password_)
        {
            string result = string.Empty;

            mongodb db = new mongodb();

            // return the message
            return result;
        }

        public string ViewAppointments(string token, string firstName_, string lastName_, string email_, string new_pass, string password_)
        {
            string result = string.Empty;
            
            mongodb db = new mongodb();

            return result;
        }

        public string ModifyAppointment(string token, string password_, string new_pass)
        {
            string result = string.Empty;

            mongodb db = new mongodb();

            return result;
        }
    }
}
