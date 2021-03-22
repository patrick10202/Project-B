using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using methods;
using System.IO;
using System.Collections.Generic;

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
        switch (UserInput){
            case "1":
                Console.Clear();
                LoginScreen();
                break;
            case "2":
                Console.Clear();
                MovieScreen();
                break;
            case "3":
                Console.Clear();
                ReserveScreen();
                break;
            case "4":
                Console.Clear();
                ComingSoonScreen();
                break;
            case "5":
                Console.Clear();
                InfoScreen();
                break;
            case "0":
                Console.Clear();
                Console.WriteLine("quit");
                break;
            default:
                Console.Clear();
                Console.WriteLine("Please enter a valid number.");
                HomeScreen();
                break;
            }
        }
    static void LoginScreen(){
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Login");
        Console.WriteLine("0: back");
        string UserInput = Console.ReadLine();
        switch (UserInput){
            case "0":
                Console.Clear();
                HomeScreen();
                break;
            default:
            Console.Clear();
            Console.WriteLine("Please enter a valid number.");
                LoginScreen();
                break;
            }
    }
    static void MovieScreen(){
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Movies");
        Console.WriteLine("0: back\n1: filter on genre");
        string movieInfo = File.ReadAllText(@"movies.json");
        List<MovieClass> Movielist = JsonConvert.DeserializeObject<List<MovieClass>>(movieInfo);
        string UserInput = Console.ReadLine();
        switch (UserInput){
            case "0":
                Console.Clear();
                HomeScreen();
                break;
            case "1":
                Console.Clear();
                foreach(var item in Movielist){
                string ret = item.Genre;
                if (ret == "Action")
                    Console.WriteLine($"Title: {item.Title} Genre: {item.Genre}");
                }
                break;
            default:
            Console.Clear();
            Console.WriteLine("Please enter a valid number.");
                MovieScreen();
                break;
            }
    }
    static void ReserveScreen(){
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("reservations");
        Console.WriteLine("0: back");
        string UserInput = Console.ReadLine();
        switch (UserInput){
            case "0":
                Console.Clear();
                HomeScreen();
                break;
            default:
            Console.Clear();
            Console.WriteLine("Please enter a valid number.");
                ReserveScreen();
                break;
            }
    }
    static void ComingSoonScreen(){
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Come watch these movies soon");
        Console.WriteLine("0: back");
        string UserInput = Console.ReadLine();
        switch (UserInput){
            case "0":
                Console.Clear();
                HomeScreen();
                break;
            default:
            Console.Clear();
            Console.WriteLine("Please enter a valid number.");
                ComingSoonScreen();
                break;
            }
    }
    static void InfoScreen(){
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Cinema info");
        Console.WriteLine("0: back");
        string UserInput = Console.ReadLine();
        switch (UserInput){
            case "0":
                Console.Clear();
                HomeScreen();
                break;
            default:
            Console.Clear();
            Console.WriteLine("Please enter a valid number.");
                InfoScreen();
                break;
            }
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
        Console.Clear();
        Console.WriteLine("Welcome to our cinema app");
        Screen.HomeScreen();
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