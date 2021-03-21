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

    }
    public class JsonMethods{
        public static List<object> JsonRead(string Path, object usedObject){
            string JsonTostring = File.ReadAllText(Path);
            List<object> list = JsonConvert.DeserializeObject<List<object>>(JsonTostring);
            return list;
        }
    }
}