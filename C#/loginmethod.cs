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

    }

}