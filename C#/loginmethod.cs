using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace methods
{
    public class LoginClass
    {
        public string Username {get;set;}
        public string Password {get;set;}
        public string Name {get;set;}
        public string Surname {get;set;}
        public string Email {get;set;}
        public string Phone {get;set;}
        public List<string> Watchlist {get;set;} 

    }

    public class Reservation
    {
        public string Username {get;set;}
        public string Email {get;set;}
        public string MovieName {get;set;}
        public string SeatNumber {get;set;}
        public double TotalCost {get;set;}
        public int ordernumber {get;set;}
        public string Timeslot {get;set;}

    }

    public class Seats{
        public string Title {get;set;}
        public string Genre {get;set;}
        public string Language {get;set;}
        public string PlayTime {get; set;}
        public string seats {get;set;}
        public string Timeslot {get;set;}
    }

}