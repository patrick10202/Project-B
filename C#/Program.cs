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


public class Reservering{

}
public class Screen{
    public static void HomeScreen(){
        Console.WriteLine("HomeScreen");
    }
    public static void MovieScreen(){
        Console.WriteLine("MovieScreen");
    }
}

public class Phrases{
    public static string inputPlease(){
        Console.WriteLine("Please input a number to see the following menus:");
        Console.WriteLine("1: HomeScreen\n2: movies\n3: reserve\n4: comming soon\n5:info");
        Console.WriteLine("to quit, enter 0");
        string UserInput = Console.ReadLine();
        return UserInput;
    }
}
class program{
    static void Main(){
        Console.WriteLine("Welcome to our cinema app");
        while (true) {
            string UserInput = Phrases.inputPlease();
            if (UserInput == "1"){
                Screen.HomeScreen();
            } else if (UserInput == "2"){
                Screen.MovieScreen();
                // login screen
                Console.WriteLine("you typed in 1");
            } else if (UserInput == "2"){
                // movies screen
                Console.WriteLine("you typed in 2");
            } else if (UserInput == "3"){
                // reserve screen
                Console.WriteLine("you typed in 3");
            } else if (UserInput == "4"){
                // coming soon screen
                Console.WriteLine("you typed in 4");
            } else if (UserInput == "5"){
                // info screen
                Console.WriteLine("you typed in 5");
            } else if (UserInput == "0"){
              break;
            }
            Console.WriteLine("press enter to continue");
            Console.ReadLine();

        }
        
        
    }
}*/
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
}
