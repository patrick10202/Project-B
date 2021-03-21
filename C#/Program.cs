using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using methods;
using System.IO;

/*var projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
var FILEPATH = Path.Combine(projectFolder, @"test.json");
var jsonString = File.ReadAllText(FILEPATH);
 
var object = JsonConvert.DeserializeObject<Persoon>(jsonString);
public class Persoon{
    public string voornaam;
    public string achternaam;
    public string gender;
    public string adres;
    public int nummer;
}

*/
public class Reservering{

}
public class Screen{
    public static void HomeScreen(){
        Console.WriteLine("======================================================================");
        Console.WriteLine("Home");
        string UserInput = Phrases.inputPlease();
        if (UserInput == "1"){
                LoginScreen();
            } else if (UserInput == "2"){
                MovieScreen();
            } else if (UserInput == "3"){
                ReserveScreen();
            } else if (UserInput == "4"){
                ComingSoonScreen();
            } else if (UserInput == "5"){
                InfoScreen();
            } else if (UserInput == "0"){
              Console.WriteLine("quit");
            }
    static void LoginScreen(){
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Login");
    }
    static void MovieScreen(){
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Movies");
    }
    static void ReserveScreen(){
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("reservations");
    }
    static void ComingSoonScreen(){
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Come watch these movies soon");
    }
    static void InfoScreen(){
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Cinema info");
        // info over app en cinema
    }
}

public class Phrases{
    public static string inputPlease(){
        Console.WriteLine("Please input a number to see the following menus:\n");
        Console.WriteLine("1: Login\n2: movies\n3: reserve\n4: comming soon\n5: info\n");
        
        Console.WriteLine("to quit, enter 0");
        string UserInput = Console.ReadLine();
        return UserInput;
    }
}
class program{
    static void Main(){
        Console.WriteLine("Welcome to our cinema app");
        while (true) {
            Screen.HomeScreen();
            Console.WriteLine("");
            Console.WriteLine("press enter to continue");
            Console.ReadLine();

        }
    }
}
}
/*
namespace MovieProgram
{
    class Program
    {
        public static void Main(string[] args)
        {
            MovieClass movie = new MovieClass()
            {
                Title = "Balaji: A tale of kings",
                Description = "Balaji punjab is on a quest to defeat his evil brother and become king of the promised land",
                Genre = "action",
                Language = "english"
            };
            string movieObject =  JsonConvert.SerializeObject(movie);
            File.WriteAllText(@"movies.json",movieObject);
            Console.WriteLine("succesfully created");
            string movieInfo = File.ReadAllText(@"movies.json");
            Console.WriteLine(movieInfo);
        }
    }
}*/

