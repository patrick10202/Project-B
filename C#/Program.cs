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

public class login{
    public static bool tryLogin(string usernameinput, string passwordinput){
        string logininfo = File.ReadAllText(@"login.json");
        List<LoginClass> Loginlist = JsonConvert.DeserializeObject<List<LoginClass>>(logininfo);
        foreach(var item in Loginlist){
            if (usernameinput == item.Username && passwordinput == item.Password){
                return true;
            }
        }
        return false;
    }
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
                FoodAndDrinks();
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
        Console.WriteLine("0: back\n1: Create account\n2: Login\n3: Login Admin");
        string UserInput = Console.ReadLine();
        switch (UserInput){
            case "0":
                Console.Clear();
                HomeScreen();
                break;
            case "1":
                Console.Clear();
                LoginScreen();
                break;
            case "2":
                Console.Clear();
                Console.WriteLine("Please enter username: ");
                var usernameinput = Console.ReadLine();
                Console.WriteLine("Please enter password: ");
                var passwordinput = Console.ReadLine();
                if (login.tryLogin(usernameinput, passwordinput)){
                    Console.WriteLine("logged in");
                }
                else{
                    Console.WriteLine("wrong combination");
                }
                break;
            case "3":
                Console.Clear();
                Console.WriteLine("Please enter admin password");
                string AdminPass = Console.ReadLine();
                if (AdminPass == "Admin1"){
                    AdminHome();
                } else {
                    Console.WriteLine("Wrong password");
                }
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
    static void FoodAndDrinks(){
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("food & Drinks");
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
                FoodAndDrinks();
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
    static void AdminHome(){
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Admin Main Menu");
        Console.WriteLine("0: Admin logoff\n1: Movies");
        string UserInput = Console.ReadLine();
        switch (UserInput){
            case "0":
                Console.Clear();
                HomeScreen();
                break;
            
            case "1":
                Console.Clear();
                AdminMovies();
                break;
            default:
                Console.Clear();
                Console.WriteLine("Please enter a valid number.");
                AdminHome();
                break;
            }
    }
    static void AdminMovies(){
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Admin Movie Menu");
        Console.WriteLine("0: back\n1: Add movie\n2: Edit Movie\n3: Remove movie");
        string UserInput = Console.ReadLine();
        string movieInfo = File.ReadAllText(@"movies.json");
        List<MovieClass> Movielist = JsonConvert.DeserializeObject<List<MovieClass>>(movieInfo);
        switch (UserInput){
            case "0":
                Console.Clear();
                AdminHome();
                break;
            
            case "1":
                Console.Clear();

                Console.WriteLine("Enter new Title");
                var NewTitle = Console.ReadLine();
                Console.WriteLine("Enter Description");
                var NewDescription = Console.ReadLine();
                Console.WriteLine("Enter Genre"); 
                var NewGenre = Console.ReadLine();
                Console.WriteLine("Enter Language");
                var NewLanguage = Console.ReadLine();
                MovieClass newMovie = new MovieClass(){
                    Title = NewTitle,
                    Description = NewDescription,
                    Genre = NewGenre,
                    Language = NewLanguage
                };

                Movielist.Add(newMovie);
                var serialisedMovielist = JsonConvert.SerializeObject(Movielist, Formatting.Indented);
                File.WriteAllText(@"movies.Json",serialisedMovielist);
                AdminMovies();

                break;

            case "2":
                Console.Clear();
                AdminMovies();
                break;

            case "3":
                Console.Clear();
                Console.WriteLine("Select movie to delete, ");
                int Choice = 1;
                Console.WriteLine("0: Cancel");
                foreach (var item in Movielist){
                    Console.WriteLine($"{Choice}: {item.Title}");
                    Choice++;
                }
                string SelectedMovie = Console.ReadLine();
                if (Convert.ToInt32(SelectedMovie) != 0){
                    try {
                        Console.WriteLine($"Do you want to delete the movie '{Movielist[Convert.ToInt32(SelectedMovie) -1].Title}'? Y/N");
                        string answer = Console.ReadLine();
                        if (answer == "Y" || answer == "y"){
                            string DeletedTitle = Movielist[Convert.ToInt32(SelectedMovie) - 1].Title;
                            Movielist.RemoveAt(Convert.ToInt32(SelectedMovie)-1);
                            Console.WriteLine($"{DeletedTitle} was deleted");
                        } else {
                            Console.WriteLine("Nothing Deleted");
                        }
                    } catch {
                        Console.WriteLine("Please enter a valid movie");
                    }
                } else {
                    Console.WriteLine("Cancelled");
                }
                serialisedMovielist = JsonConvert.SerializeObject(Movielist, Formatting.Indented);
                File.WriteAllText(@"movies.Json",serialisedMovielist);
                AdminMovies();
                break;
            default:
                Console.Clear();
                Console.WriteLine("Please enter a valid number.");
                AdminMovies();
                break;
            }
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