using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace methods
{
    public class MovieClass
    {
        public string Title {get;set; }
        public string Description {get;set;}
        public string Genre {get;set;}
        public string Language {get;set;}

        public int BasePrice {get;set;}

        public string PlayTime {get; set;}

        

    }
    public class Review  {
        public string Title {get; set;}
        public string ReviewString {get; set;}
        public string Username {get; set;}
        
    }

}