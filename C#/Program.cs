﻿using System;
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
    public static Tuple<bool, int> tryLogin(string usernameinput, string passwordinput){
        string logininfo = File.ReadAllText(@"login.json");
        List<LoginClass> Loginlist = JsonConvert.DeserializeObject<List<LoginClass>>(logininfo);
        int index = 0;
        foreach(var item in Loginlist){
            if (usernameinput == item.Username && passwordinput == item.Password){
                return Tuple.Create(true, index);
            }
            index++;
        }
        return Tuple.Create(false, index);
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
        Console.WriteLine("0: back\n1: Create account\n2: Login\n3: Admin Login");
        string logininfo = File.ReadAllText(@"login.json");
        List<LoginClass> Loginlist = JsonConvert.DeserializeObject<List<LoginClass>>(logininfo);
        string UserInput = Console.ReadLine();
        switch (UserInput){
            case "0":
                Console.Clear();
                HomeScreen();
                break;
            case "1":
                Console.Clear();
                Console.WriteLine("Please enter username: ");
                var NewUser = Console.ReadLine();
                Console.WriteLine("Please enter password: ");
                var NewPassword = Console.ReadLine();
                Console.WriteLine("Please enter name: ");
                var NewName = Console.ReadLine();
                Console.WriteLine("Please enter surname: ");
                var NewSurname = Console.ReadLine();
                Console.WriteLine("Please enter email: ");
                var NewEmail = Console.ReadLine();
                Console.WriteLine("Please enter phonenumber: ");
                var NewPhone = Console.ReadLine();
                LoginClass newAccount = new LoginClass(){
                    Username = NewUser,
                    Password = NewPassword,
                    Name = NewName,
                    Surname = NewSurname,
                    Email = NewEmail,
                    Phone = NewPhone
                };

                Loginlist.Add(newAccount);
                var serialisedLoginlist = JsonConvert.SerializeObject(Loginlist, Formatting.Indented);
                File.WriteAllText(@"login.Json",serialisedLoginlist);
                Console.Clear();
                Console.WriteLine("Account creation was succesful");
                LoginScreen();
                break;
            case "2":
                Console.Clear();
                Console.WriteLine("Please enter username: ");
                var usernameinput = Console.ReadLine();
                Console.WriteLine("Please enter password: ");
                var passwordinput = Console.ReadLine();
                if (login.tryLogin(usernameinput, passwordinput).Item1){
                    Console.Clear();
                    Console.WriteLine("logged in");
                    AccountSettings(login.tryLogin(usernameinput, passwordinput));
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
                    Console.Clear();
                    Console.WriteLine("Wrong password");
                    LoginScreen();
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
        Console.WriteLine("0: back\n1: filter on genre\n2: filter on Language\n3: filter on time");
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
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("0: Back\n1: Action\n2: Thriller\n3: Adventure\n4: Comedy\n5: Fantasy");
                Console.WriteLine("6: Horror\n7: Romance\n8: Drama");
                string answergenre = Console.ReadLine();
                //filter for genre
                if (answergenre == "1") {
                    foreach(var item in Movielist){
                        string ret = item.Genre;
                    if (ret == "Action")
                        Console.WriteLine($"Title: {item.Title}");
                    }
                }    
                if (answergenre == "2") {
                    foreach(var item in Movielist){
                        string ret = item.Genre;
                    if (ret == "Thriller")
                        Console.WriteLine($"Title: {item.Title}");
                    }   
                }
                if (answergenre == "3") {
                    foreach(var item in Movielist){
                        string ret = item.Genre;
                    if (ret == "Adventure")
                        Console.WriteLine($"Title: {item.Title}");
                    }   
                }
                if (answergenre == "4") {
                    foreach(var item in Movielist){
                        string ret = item.Genre;
                    if (ret == "Comedy")
                        Console.WriteLine($"Title: {item.Title}");
                    }
                }  
                if (answergenre == "5") {
                    foreach(var item in Movielist){
                        string ret = item.Genre;
                    if (ret == "Fantasy")
                        Console.WriteLine($"Title: {item.Title}");
                    }
                }  
                if (answergenre == "6") {
                    foreach(var item in Movielist){
                        string ret = item.Genre;
                    if (ret == "Horror")
                        Console.WriteLine($"Title: {item.Title}");
                    }
                }  
                if (answergenre == "7") {
                    foreach(var item in Movielist){
                        string ret = item.Genre;
                    if (ret == "Romance")
                        Console.WriteLine($"Title: {item.Title}");
                    }
                }  
                if (answergenre == "8") {
                    foreach(var item in Movielist){
                        string ret = item.Genre;
                    if (ret == "Drama")
                        Console.WriteLine($"Title: {item.Title}");
                    }
                }  
                break;
            
            case "2":
                Console.Clear();
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("0: Back\n1: Dutch\n2: English");
                string answerLanguage = Console.ReadLine();
                //filter for Language
                if (answerLanguage == "1") {
                    foreach(var item in Movielist){
                        string ret = item.Language;
                    if (ret == "Dutch")
                        Console.WriteLine($"Title: {item.Title}");    
                    }   
                }
                if (answerLanguage == "2") {
                    foreach(var item in Movielist){
                        string ret = item.Language;
                    if (ret == "English")
                        Console.WriteLine($"Title: {item.Title}");     
                    }   
                }
                break;
            
            case "3":
                Console.Clear();
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("0: Back\n1: 1 hour\n2: 1.5 hours\n3: 2 hours\n4: 2.5 hours\n5: 3 hours");
                string answerPlayTime = Console.ReadLine();
                //filter for PlayTime
                if (answerPlayTime == "1") {
                    foreach(var item in Movielist){
                        string ret = item.PlayTime;
                    if (ret == "1 hour")
                        Console.WriteLine($"Title: {item.Title}");     
                    }   
                }
                if (answerPlayTime == "2") {
                    foreach(var item in Movielist){
                        string ret = item.PlayTime;
                    if (ret == "1.5 hours")
                        Console.WriteLine($"Title: {item.Title}");    
                    }   
                }
                if (answerPlayTime == "3") {
                    foreach(var item in Movielist){
                        string ret = item.PlayTime;
                    if (ret == "2 hours")
                        Console.WriteLine($"Title: {item.Title}");     
                    }   
                }
                if (answerPlayTime == "4") {
                    foreach(var item in Movielist){
                        string ret = item.PlayTime;
                    if (ret == "2.5 hours")
                        Console.WriteLine($"Title: {item.Title}");    
                    }   
                }
                if (answerPlayTime == "5") {
                    foreach(var item in Movielist){
                        string ret = item.PlayTime;
                    if (ret == "3 hours")
                        Console.WriteLine($"Title: {item.Title}");    
                    } 
                }      
                break;
                
                default:
            Console.Clear();
            Console.WriteLine("Please enter a valid number.");
                MovieScreen();
                break;
            }
    }
    static void Drinks(){
        Console.Clear();
        Console.WriteLine("These are the drinks we sell at the restaurant");
        Console.WriteLine("1. Coca cola               2,50 euros ");
        Console.WriteLine("2. Fanta                   2,50 euros ");
        Console.WriteLine("3. Sprite                  2,50 euros ");
        Console.WriteLine("4. Fernandes               2,50 euros ");
        Console.WriteLine("5 Heineken 500 ml          4,50 euros ");
        Console.WriteLine("6. Redbull                 3,50 euros ");
        Console.WriteLine("7. Spa blue                2,50 euros ");
        Console.WriteLine("8. Tenesis                 2,50 euros ");
        Console.WriteLine("9. Milkshake strawberry    2,50 euros ");
        //Console.WriteLine("Price in total ");
        Console.WriteLine("0 = back");
        string userName = Console.ReadLine();
        if (userName == "0"){
            HomeScreen();
        }
    }
    static void Food(){
        Console.WriteLine("These are the drinks we sell at the restaurant");
        Console.WriteLine("1. Coca cola               2,50 euros ");
        Console.WriteLine("2. Fanta                   2,50 euros ");
        Console.WriteLine("3. Sprite                  2,50 euros ");
        Console.WriteLine("4. Fernandes               2,50 euros ");
        Console.WriteLine("5  Heineken 500 ml         4,50 euros ");
        Console.WriteLine("6. Redbull                 3,50 euros ");
        Console.WriteLine("7. Spa blue                2,50 euros ");
        Console.WriteLine("8. Tenesis                 2,50 euros ");
        Console.WriteLine("9. Milkshake strawberry    2,50 euros ");
        //Console.WriteLine("Price in total ");
        Console.WriteLine("0 = back");
        string userName = Console.ReadLine();
        if (userName == "0"){
            HomeScreen();
        }
    }
    
    static void FoodAndDrinks(){
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("food & Drinks");
        Console.WriteLine("0: back\n1: Food\n2: Drinks");
        string UserInput = Console.ReadLine();
        if  (UserInput == "0"){
                Console.Clear();
                HomeScreen();
        }
        if  (UserInput == "1"){
                Console.Clear();
                Food();
        }
        if  (UserInput == "2"){
                Console.Clear();
                Drinks();
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
    static void Seats(){
        Console.Clear();
        Console.WriteLine("Check Seats prices");
        Console.WriteLine("Normal Seats         9,50 euro");
        Console.WriteLine("Love Seats           10,50 euro");
        Console.WriteLine("Premium Seats        13,50 euro");
        Console.WriteLine("0 = back to Main menu");
        string Usernameseats = Console.ReadLine();
        if (Usernameseats == "0"){
            HomeScreen();}
    }
    static void InfoScreen(){
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Cinema info");
        Console.WriteLine("0: back\n1: Seats");
        string UserInput = Console.ReadLine();
        switch (UserInput){
            case "0":
                Console.Clear();
                HomeScreen();
                break;

            case "1":
                Console.Clear();
                Seats();
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
    static void AccountSettings(Tuple<bool, int> accindex){
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Account Settings");
        Console.WriteLine("0: back\n1: edit username\n2: edit password\n3: edit name\n4: edit surname\n5: edit email\n6: edit phone number\n7 delete account");
        string logininfo = File.ReadAllText(@"login.json");
        List<LoginClass> Loginlist = JsonConvert.DeserializeObject<List<LoginClass>>(logininfo);
        string UserInput = Console.ReadLine();
        switch (UserInput){
            case "0":
                Console.Clear();
                LoginScreen();
                break;
            case "1":
                Console.Clear();
                LoginScreen();
                break;
            case "2":
                Console.Clear();
                LoginScreen();
                break;
            case "3":
                Console.Clear();
                LoginScreen();
                break;
            case "4":
                Console.Clear();
                LoginScreen();
                break;
            case "5":
                Console.Clear();
                LoginScreen();
                break;
            case "6":
                Console.Clear();
                LoginScreen();
                break;
            case "7":
                Console.Clear();
                Console.WriteLine("Are you sure you want to delete your account? Y/N");
                string answer = Console.ReadLine();
                if (answer == "Y" || answer == "y"){
                    Loginlist.RemoveAt(accindex.Item2);
                    Console.WriteLine("Your account has been deleted");
                } else {
                    Console.WriteLine("Aborted");
                }
                var serialisedLoginlist = JsonConvert.SerializeObject(Loginlist, Formatting.Indented);
                File.WriteAllText(@"login.Json",serialisedLoginlist);
                LoginScreen();
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
                Console.WriteLine("Enter price (integer value)");
                var NewPrice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Playtime (in minutes)");
                var NewPlayTime = Console.ReadLine();

                MovieClass newMovie = new MovieClass(){
                    Title = NewTitle,
                    Description = NewDescription,
                    Genre = NewGenre,
                    Language = NewLanguage,
                    BasePrice = NewPrice,
                    PlayTime = NewPlayTime
                };

                Movielist.Add(newMovie);
                var serialisedMovielist = JsonConvert.SerializeObject(Movielist, Formatting.Indented);
                File.WriteAllText(@"movies.Json",serialisedMovielist);
                AdminMovies();

                break;

            case "2":
                Console.Clear();
                Console.WriteLine("Select movie to edit");
                int Choce = 1;
                Console.WriteLine("0: Cancel");
                foreach (var item in Movielist){
                    Console.WriteLine($"{Choce}: {item.Title}");
                    Choce++;
                }
                string SelecteMovie = Console.ReadLine();
                int selecteIndex = 0;
                try {
                    selecteIndex = Convert.ToInt32(SelecteMovie);
                } catch {
                    Console.WriteLine("Please enter a valid number");
                }
                if (selecteIndex != 0){
                    bool indexInList = true;
                    try {
                        var test = Movielist[selecteIndex - 1];
                    } catch {
                        indexInList = false;
                    }
                    if (indexInList){
                        Console.WriteLine("Select item to Edit\n0: Cancel ");
                        Console.WriteLine($"1: Title: {Movielist[selecteIndex - 1].Title}");
                        Console.WriteLine($"2: Description: {Movielist[selecteIndex - 1].Description}");
                        Console.WriteLine($"3: Genre: {Movielist[selecteIndex - 1].Genre}");
                        Console.WriteLine($"4: Language: {Movielist[selecteIndex - 1].Language}");
                        Console.WriteLine($"5: BasePrice: {Movielist[selecteIndex - 1].BasePrice}");
                        Console.WriteLine($"6: Playtime: {Movielist[selecteIndex - 1].PlayTime}");
                        UserInput = Console.ReadLine();
                        if (UserInput == "1"){
                            Console.WriteLine("Edit Title:");
                            Movielist[selecteIndex - 1].Title = Console.ReadLine();
                        } else if (UserInput == "2"){
                            Console.WriteLine("Edit Description:");
                            Movielist[selecteIndex - 1].Description = Console.ReadLine();
                        }else if (UserInput == "3"){
                            Console.WriteLine("Edit Genre:");
                            Movielist[selecteIndex - 1].Genre = Console.ReadLine();
                        }else if (UserInput == "4"){
                            Console.WriteLine("Edit Language:");
                            Movielist[selecteIndex - 1].Language = Console.ReadLine();
                        }else if (UserInput == "5"){
                            Console.WriteLine("Edit Price (integer value):");
                            Movielist[selecteIndex - 1].BasePrice = Convert.ToInt32(Console.ReadLine());
                        }else if (UserInput == "6"){
                            Console.WriteLine("Edit PlayTime (in minutes)");
                            Movielist[selecteIndex - 1].PlayTime = Console.ReadLine();
                        }else {
                            Console.WriteLine("Nothing was edited");
                        }
                        
                    } else {
                        Console.WriteLine("Please enter a valid number");
                    }
                } else {
                    Console.WriteLine("Cancelled");
                }
                serialisedMovielist = JsonConvert.SerializeObject(Movielist, Formatting.Indented);
                File.WriteAllText(@"movies.Json",serialisedMovielist);
                AdminMovies();
                break;

            case "3":
                Console.Clear();
                Console.WriteLine("Select movie to delete");
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
        Console.WriteLine("1: Login\n2: movies\n3: Food & Drinks\n4: comming soon\n5: info\n");
        
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