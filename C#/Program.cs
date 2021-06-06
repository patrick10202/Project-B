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
                Draaiendefilms();
                break;
            case "4":
                Console.Clear();
                FoodAndDrinks();
                break;
            case "5":
                Console.Clear();
                ComingSoonScreen();
                break;
            case "6":
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
        Console.WriteLine("0: back\n1: filter on genre\n2: filter on Language\n3: filter on time\n4: Reviews");
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
                int finalcount = 1;
                //filter for genre
                if (answergenre == "1") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in Movielist){
                        string ret = item.Genre;
                        if (ret == "Action"){
                            Console.WriteLine($"{counter} Title: {item.Title}");
                        }
                        counter++;
                    }
                    finalcount = counter;
                }    
                if (answergenre == "2") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in Movielist){
                        string ret = item.Genre;
                        if (ret == "Thriller"){
                            Console.WriteLine($"{counter} Title: {item.Title}");
                        }
                        counter++;
                    }   
                    finalcount = counter;
                }
                if (answergenre == "3") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in Movielist){
                        string ret = item.Genre;
                        if (ret == "Adventure")
                            Console.WriteLine($"{counter} Title: {item.Title}");
                        counter++;
                    }
                    finalcount = counter;
                }
                if (answergenre == "4") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in Movielist){
                        string ret = item.Genre;
                        if (ret == "Comedy")
                            Console.WriteLine($"{counter} Title: {item.Title}");
                        counter++;
                    }
                    finalcount = counter;
                }  
                if (answergenre == "5") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in Movielist){
                        string ret = item.Genre;
                        if (ret == "Fantasy")
                            Console.WriteLine($"{counter} Title: {item.Title}");
                        counter++;
                    }
                    finalcount = counter;
                }  
                if (answergenre == "6") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in Movielist){
                        string ret = item.Genre;
                        if (ret == "Horror")
                            Console.WriteLine($"{counter} Title: {item.Title}");
                        counter++;
                    }
                    finalcount = counter;
                }  
                if (answergenre == "7") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in Movielist){
                        string ret = item.Genre;
                        if (ret == "Romance")
                            Console.WriteLine($"{counter} Title: {item.Title}");
                        counter++;
                    }
                    finalcount = counter;
                }  
                if (answergenre == "8") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in Movielist){
                        string ret = item.Genre;
                        if (ret == "Drama")
                            Console.WriteLine($"{counter} Title: {item.Title}");
                        counter++;
                    }
                    finalcount = counter;
                }
                if (answergenre.Length != 1 || Convert.ToChar(answergenre) < '0' || Convert.ToChar(answergenre) > '8'){
                    Console.Clear();
                    Console.WriteLine("Please enter a valid number.");
                    MovieScreen();
                }
                Console.WriteLine("Type a number of a movie to view the info about that movie or press 0 to go back");
                UserInput = Console.ReadLine();
                if (UserInput == "0"){
                    Console.Clear();
                    MovieScreen();
                }
                else{
                    try{
                        int UsrInp = Convert.ToInt32(UserInput);
                        Console.Clear();
                        if (UsrInp >= 1 && UsrInp <= finalcount){
                            /*nieuw scherm aanmaken voor films die index UsrInp - 1 gebruikt.*/
                            MovieInfo(UsrInp - 1);
                        }
                    }
                    catch{
                        Console.WriteLine("Please input a valid number");
                    }
                }
                break;
            
            case "2":
                Console.Clear();
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("0: Back\n1: Dutch\n2: English");
                string answerLanguage = Console.ReadLine();
                int finalcount1 = 1;
                //filter for Language
                if (answerLanguage == "1") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in Movielist){
                        string ret = item.Language;
                        if (ret == "Dutch")
                            Console.WriteLine($"{counter} Title: {item.Title}");
                        counter++;
                    }   
                    finalcount1 = counter;
                }
                if (answerLanguage == "2") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in Movielist){
                        string ret = item.Language;
                        if (ret == "English")
                            Console.WriteLine($"{counter} Title: {item.Title}");
                        counter++;  
                    }  
                    finalcount1 = counter;
                }
                if (answerLanguage.Length != 1 || Convert.ToChar(answerLanguage) < '0' || Convert.ToChar(answerLanguage) > '8'){
                    Console.Clear();
                    Console.WriteLine("Please enter a valid number.");
                    MovieScreen();
                }
                Console.WriteLine("Type a number of a movie to view the info about that movie or press 0 to go back");
                UserInput = Console.ReadLine();
                if (UserInput == "0"){
                    Console.Clear();
                    MovieScreen();
                }
                else{
                    try{
                        int UsrInp = Convert.ToInt32(UserInput);
                        Console.Clear();
                        if (UsrInp >= 1 && UsrInp <= finalcount1){
                            /*nieuw scherm aanmaken voor films die index UsrInp - 1 gebruikt.*/
                            MovieInfo(UsrInp - 1);
                        }
                    }
                    catch{
                        Console.WriteLine("Please input a valid number");
                    }
                }
                break;
            
            case "3":
                Console.Clear();
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("0: Back\n1: 1 hour\n2: 1.5 hours\n3: 2 hours\n4: 2.5 hours\n5: 3 hours");
                string answerPlayTime = Console.ReadLine();
                int finalcount2 = 1;
                //filter for PlayTime
                if (answerPlayTime == "1") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in Movielist){
                        string ret = item.PlayTime;
                        if (ret == "1 hour")
                            Console.WriteLine($"{counter}Title: {item.Title}");
                        counter++;
                    }   
                    finalcount2 = counter;
                }
                if (answerPlayTime == "2") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in Movielist){
                        string ret = item.PlayTime;
                        if (ret == "1.5 hours")
                            Console.WriteLine($"{counter} Title: {item.Title}");
                        counter++;
                    }
                    finalcount2 = counter;
                }
                if (answerPlayTime == "3") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in Movielist){
                        string ret = item.PlayTime;
                        if (ret == "2 hours")
                            Console.WriteLine($"{counter} Title: {item.Title}");
                        counter++;
                    }
                    finalcount2 = counter;
                }
                if (answerPlayTime == "4") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in Movielist){
                        string ret = item.PlayTime;
                        if (ret == "2.5 hours")
                            Console.WriteLine($"{counter} Title: {item.Title}");
                        counter++;
                    }
                    finalcount2 = counter;
                }
                if (answerPlayTime == "5") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in Movielist){
                        string ret = item.PlayTime;
                        if (ret == "3 hours")
                            Console.WriteLine($"{counter} Title: {item.Title}");
                        counter++;
                    } 
                    finalcount2 = counter;
                }      
                if (answerPlayTime.Length != 1 || Convert.ToChar(answerPlayTime) < '0' || Convert.ToChar(answerPlayTime) > '8'){
                    Console.Clear();
                    Console.WriteLine("Please enter a valid number.");
                    MovieScreen();
                }
                Console.WriteLine("Type a number of a movie to view the info about that movie or press 0 to go back");
                UserInput = Console.ReadLine();
                if (UserInput == "0"){
                    Console.Clear();
                    MovieScreen();
                }
                else{
                    try{
                        int UsrInp = Convert.ToInt32(UserInput);
                        Console.Clear();
                        if (UsrInp >= 1 && UsrInp <= finalcount2){
                            /*nieuw scherm aanmaken voor films die index UsrInp - 1 gebruikt.*/
                            MovieInfo(UsrInp - 1);
                        }
                    }
                    catch{
                        Console.WriteLine("Please input a valid number");
                    }
                }
                break;

            case "4":
                Console.Clear();
                Console.WriteLine("----------------------------------------------------------------------");
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
                        Console.Clear();

                        ReviewScreen(Movielist[selecteIndex - 1].Title);
                    } else {
                        Console.WriteLine("Canceled");
                    }
                }
                Console.Clear();
                Console.WriteLine("Please enter a valid number.");
                MovieScreen();
                break;
                
            default:
                Console.Clear();
                Console.WriteLine("Please enter a valid number.");
                MovieScreen();
                break;
            }
    }

    static void MovieInfo(int movieindex){
        string movieInfo = File.ReadAllText(@"movies.json");
        List<MovieClass> Movielist = JsonConvert.DeserializeObject<List<MovieClass>>(movieInfo);
        Console.WriteLine($"Title: {Movielist[movieindex].Title}\nDescription: {Movielist[movieindex].Description}\nGenre: {Movielist[movieindex].Genre}\nLanguage: {Movielist[movieindex].Language}\nBasePrice: {Movielist[movieindex].BasePrice}\nPlayTime: {Movielist[movieindex].PlayTime}");
        Console.WriteLine("Press any key to go back to the movie screen.");
        Console.ReadLine();
        Console.Clear();
        MovieScreen();
    }
    
    static void Draaiendefilms(){
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Reserve available movies");
        Console.WriteLine("0: back\n1: filter on Genre\n2: filter on Language\n3: filter on time");
        string seatInfo = File.ReadAllText(@"seats.json");
        List<Seats> seatstring = JsonConvert.DeserializeObject<List<Seats>>(seatInfo);
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
                int finalcount = 1;
                //filter for genre
                if (answergenre == "1") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in seatstring){
                        string ret = item.Genre;
                        if (ret == "Action"){
                            Console.WriteLine($"{counter} Time: {item.Timeslot} Title: {item.Title}");
                        }
                        counter++;
                    }
                    finalcount = counter;
                }    
                if (answergenre == "2") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in seatstring){
                        string ret = item.Genre;
                        if (ret == "Thriller"){
                            Console.WriteLine($"{counter} Time: {item.Timeslot} Title: {item.Title}");
                        }
                        counter++;
                    }   
                    finalcount = counter;
                }
                if (answergenre == "3") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in seatstring){
                        string ret = item.Genre;
                        if (ret == "Adventure")
                            Console.WriteLine($"{counter} Time: {item.Timeslot} Title: {item.Title}");
                        counter++;
                    }
                    finalcount = counter;
                }
                if (answergenre == "4") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in seatstring){
                        string ret = item.Genre;
                        if (ret == "Comedy")
                            Console.WriteLine($"{counter} Time: {item.Timeslot} Title: {item.Title}");
                        counter++;
                    }
                    finalcount = counter;
                }  
                if (answergenre == "5") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in seatstring){
                        string ret = item.Genre;
                        if (ret == "Fantasy")
                            Console.WriteLine($"{counter} Time: {item.Timeslot} Title: {item.Title}");
                        counter++;
                    }
                    finalcount = counter;
                }  
                if (answergenre == "6") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in seatstring){
                        string ret = item.Genre;
                        if (ret == "Horror")
                            Console.WriteLine($"{counter} Time: {item.Timeslot} Title: {item.Title}");
                        counter++;
                    }
                    finalcount = counter;
                }  
                if (answergenre == "7") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in seatstring){
                        string ret = item.Genre;
                        if (ret == "Romance")
                            Console.WriteLine($"{counter} Time: {item.Timeslot} Title: {item.Title}");
                        counter++;
                    }
                    finalcount = counter;
                }  
                if (answergenre == "8") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in seatstring){
                        string ret = item.Genre;
                        if (ret == "Drama")
                            Console.WriteLine($"{counter} Time: {item.Timeslot} Title: {item.Title}");
                        counter++;
                    }
                    finalcount = counter;
                }
                if (answergenre.Length != 1 || Convert.ToChar(answergenre) < '0' || Convert.ToChar(answergenre) > '8'){
                    Console.Clear();
                    Console.WriteLine("Please enter a valid number.");
                    Draaiendefilms();
                }
                Console.WriteLine("Type a number of a movie to reserve that movie or press 0 to go back");
                UserInput = Console.ReadLine();
                if (UserInput == "0"){
                    Console.Clear();
                    Draaiendefilms();
                }
                else{
                    try{
                        int UsrInp = Convert.ToInt32(UserInput);
                        Console.Clear();
                        if (UsrInp >= 1 && UsrInp <= finalcount)
                        ReserveringenScherm(UsrInp - 1);
                    }
                    catch{
                        Console.Clear();
                        Console.WriteLine("Please enter a valid number.");
                        Draaiendefilms();
                    }
                }
                break;
            
            case "2":
                Console.Clear();
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("0: Back\n1: Dutch\n2: English");
                string answerLanguage = Console.ReadLine();
                int finalcount1 = 1;
                //filter for Language
                if (answerLanguage == "1") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in seatstring){
                        string ret = item.Language;
                        if (ret == "Dutch")
                            Console.WriteLine($"{counter} Time: {item.Timeslot} Title: {item.Title}");
                        counter++;
                    }   
                    finalcount1 = counter;
                }
                if (answerLanguage == "2") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in seatstring){
                        string ret = item.Language;
                        if (ret == "English")
                            Console.WriteLine($"{counter} Time: {item.Timeslot} Title: {item.Title}");
                        counter++;  
                    }  
                    finalcount1 = counter;
                }
                if (answerLanguage.Length != 1 || Convert.ToChar(answerLanguage) < '0' || Convert.ToChar(answerLanguage) > '2'){
                    Console.Clear();
                    Console.WriteLine("Please enter a valid number.");
                    Draaiendefilms();
                }
                Console.WriteLine("Type a number of a movie to reserve that movie or press 0 to go back");
                UserInput = Console.ReadLine();
                if (UserInput == "0"){
                    Console.Clear();
                    Draaiendefilms();
                }
                else{
                    try{
                        int UsrInp = Convert.ToInt32(UserInput);
                        Console.Clear();
                        if (UsrInp >= 1 && UsrInp <= finalcount1)
                        ReserveringenScherm(UsrInp - 1);
                    }
                    catch{
                        Console.Clear();
                        Console.WriteLine("Please enter a valid number.");
                        Draaiendefilms();
                    }
                }
                break;
            
            case "3":
                Console.Clear();
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("0: Back\n1: 1 hour\n2: 1.5 hours\n3: 2 hours\n4: 2.5 hours\n5: 3 hours");
                string answerPlayTime = Console.ReadLine();
                int finalcount2 = 1;
                //filter for PlayTime
                if (answerPlayTime == "1") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in seatstring){
                        string ret = item.PlayTime;
                        if (ret == "1 hour")
                            Console.WriteLine($"{counter} Time: {item.Timeslot} Title: {item.Title}");
                        counter++;
                    }   
                    finalcount2 = counter;
                }
                if (answerPlayTime == "2") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in seatstring){
                        string ret = item.PlayTime;
                        if (ret == "1.5 hours")
                            Console.WriteLine($"{counter} Time: {item.Timeslot} Title: {item.Title}");
                        counter++;
                    }
                    finalcount2 = counter;
                }
                if (answerPlayTime == "3") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in seatstring){
                        string ret = item.PlayTime;
                        if (ret == "2 hours")
                            Console.WriteLine($"{counter} Time: {item.Timeslot} Title: {item.Title}");
                        counter++;
                    }
                    finalcount2 = counter;
                }
                if (answerPlayTime == "4") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in seatstring){
                        string ret = item.PlayTime;
                        if (ret == "2.5 hours")
                            Console.WriteLine($"{counter} Time: {item.Timeslot} Title: {item.Title}");
                        counter++;
                    }
                    finalcount2 = counter;
                }
                if (answerPlayTime == "5") {
                    Console.Clear();
                    int counter = 1;
                    foreach(var item in seatstring){
                        string ret = item.PlayTime;
                        if (ret == "3 hours")
                            Console.WriteLine($"{counter} Time: {item.Timeslot} Title: {item.Title}");
                        counter++;
                    } 
                    finalcount2 = counter;
                }
                if (answerPlayTime.Length != 1 || Convert.ToChar(answerPlayTime) < '0' || Convert.ToChar(answerPlayTime) > '5'){
                    Console.Clear();
                    Console.WriteLine("Please enter a valid number.");
                    Draaiendefilms();
                }
                Console.WriteLine("Type a number of a movie to reserve that movie or press 0 to go back");
                UserInput = Console.ReadLine();
                if (UserInput == "0"){
                    Console.Clear();
                    Draaiendefilms();
                }
                else{
                    try{
                        int UsrInp = Convert.ToInt32(UserInput);
                        Console.Clear();
                        if (UsrInp >= 1 && UsrInp <= finalcount2)
                        ReserveringenScherm(UsrInp - 1);
                    }
                    catch{
                        Console.Clear();
                        Console.WriteLine("Please enter a valid number.");
                        Draaiendefilms();
                    }
                }   
                break;
                
            default:
                Console.Clear();
                Console.WriteLine("Please enter a valid number.");
                Draaiendefilms();
                break;
            }
    }

    static void ReserveringenScherm(int movieindex){
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Reservation screen");
        string movieInfo = File.ReadAllText(@"movies.json");
        List<MovieClass> Movielist = JsonConvert.DeserializeObject<List<MovieClass>>(movieInfo);
        string reservationjson = File.ReadAllText(@"reservations.json");
        List<Reservation> reservationdata = JsonConvert.DeserializeObject<List<Reservation>>(reservationjson);
        string logininfo = File.ReadAllText(@"login.json");
        List<LoginClass> Loginlist = JsonConvert.DeserializeObject<List<LoginClass>>(logininfo);
        string seatinfo = File.ReadAllText(@"seats.json");
        List<Seats> seatString = JsonConvert.DeserializeObject<List<Seats>>(seatinfo);
        
        double Cost = Movielist[movieindex].BasePrice;
        
        Console.WriteLine($"A seat for this movie costs {Cost} euros");
        Console.WriteLine("If you have an account press 1, else press 2");
        string Userinput = Console.ReadLine();
        if (Userinput == "1"){
            Console.WriteLine("Please enter username: ");
            var usernameinput = Console.ReadLine();
            Console.WriteLine("Please enter password: ");
            var passwordinput = Console.ReadLine();
            Tuple<bool, int> accindex = login.tryLogin(usernameinput, passwordinput);
            if (accindex.Item1 == true){
                Console.Clear();
                Console.WriteLine($"All seats with an U are available, a seat costs {Movielist[movieindex].BasePrice} Euros");
                Console.WriteLine(seatString[movieindex].seats);
                Console.WriteLine("Please choose your seat:");
                string userinput = "";
                int userinputasint = 0;
                bool isvalid = false;
                while (!isvalid){
                    userinput = Console.ReadLine();
                    try{
                        userinputasint = Convert.ToInt32(userinput);
                        
                        if (userinputasint >= 1 && userinputasint <= 30){
                            if (seatString[movieindex].seats.Contains(userinput)){
                                seatString[movieindex].seats = seatString[movieindex].seats.Replace(userinput, "Taken");
                                isvalid = true;
                            }
                            else{
                                Console.Clear();
                                Console.WriteLine("Please input a valid seat number.");
                            }
                            File.WriteAllText(@"seats.Json",JsonConvert.SerializeObject(seatString, Formatting.Indented));
                        }
                        else{
                            Console.Clear();
                            Console.WriteLine("Please input a valid seat number.");
                        }
                    }
                    catch{
                        Console.Clear();
                        Console.WriteLine("Please input a valid seat number.");
                    }
                    
                }
                if (Loginlist[accindex.Item2].Watchlist == null){
                    Loginlist[accindex.Item2].Watchlist = new List<string>();
                }
                Loginlist[accindex.Item2].Watchlist.Add(Movielist[movieindex].Title);
                File.WriteAllText(@"login.Json",JsonConvert.SerializeObject(Loginlist, Formatting.Indented));

                Reservation newReservation = new Reservation(){
                    Username = usernameinput,
                    MovieName = Movielist[movieindex].Title,
                    SeatNumber = userinput,
                    TotalCost = Movielist[movieindex].BasePrice,
                    Timeslot = seatString[movieindex].Timeslot,
                };
                if (reservationdata == null){
                    reservationdata = new List<Reservation>();
                }
                reservationdata.Add(newReservation);
                File.WriteAllText(@"reservations.Json",JsonConvert.SerializeObject(reservationdata, Formatting.Indented));

                Console.Clear();
                Console.WriteLine("reservation succesful");
                ReserveringenScherm(movieindex);
            }
            else{
                Console.Clear();
                Console.WriteLine("Username or Password incorrect");
                ReserveringenScherm(movieindex);
            }
        }
        else if (Userinput == "2"){
            Console.WriteLine("Please enter your email for the reservation:");
            string UserInput = Console.ReadLine();
            Random rd = new Random();
            int rand_num = rd.Next(0,1000);
            Console.WriteLine($"All seats with an U are available, a seat costs {Movielist[movieindex].BasePrice} Euros");
            Console.WriteLine(seatString[movieindex].seats);
            Console.WriteLine("Please choose your seat:");
            string userinput = "";
            int userinputasint = 0;
            bool isvalid = false;
            while (!isvalid){
                userinput = Console.ReadLine();
                try{
                    userinputasint = Convert.ToInt32(userinput);
                    
                    if (userinputasint >= 1 && userinputasint <= 30){
                        if (seatString[movieindex].seats.Contains(userinput)){
                            seatString[movieindex].seats = seatString[movieindex].seats.Replace(userinput, "Taken");
                            isvalid = true;
                        }
                        else{
                            Console.Clear();
                            Console.WriteLine("Please input a valid seat number.");
                        }
                        File.WriteAllText(@"seats.Json",JsonConvert.SerializeObject(seatString, Formatting.Indented));
                    }
                    else{
                        Console.Clear();
                        Console.WriteLine("Please input a valid seat number.");
                    }
                }
                catch{
                    Console.Clear();
                    Console.WriteLine("Please input a valid seat number.");
                }
                
            }
            Reservation newReservation = new Reservation(){
                    Email = UserInput,
                    MovieName = Movielist[movieindex].Title,
                    SeatNumber = userinput,
                    TotalCost = Movielist[movieindex].BasePrice,
                    ordernumber = rand_num,
                    Timeslot = seatString[movieindex].Timeslot,
                };
            if (reservationdata == null){
                reservationdata = new List<Reservation>();
            }
            reservationdata.Add(newReservation);
            var serialisedreservationlist = JsonConvert.SerializeObject(reservationdata, Formatting.Indented);
            File.WriteAllText(@"reservations.Json",serialisedreservationlist);

            Console.Clear();
            Console.WriteLine("reservation succesful");
            Console.WriteLine($"reservation code = {rand_num}");
            MovieScreen();
        }
        else{
            Console.Clear();
            Console.WriteLine("Please enter a valid number");
            ReserveringenScherm(movieindex);
        }
    }
    static void Drinks(){
        Console.Clear();
        Console.WriteLine("These are the drinks we sell at the restaurant");
        Console.WriteLine();
        Console.WriteLine("Coca cola               2,50 euros ");
        Console.WriteLine("Fanta                   2,50 euros ");
        Console.WriteLine("Sprite                  2,50 euros ");
        Console.WriteLine("Fernandes               2,50 euros ");
        Console.WriteLine("Heineken 500 ml         4,50 euros ");
        Console.WriteLine("Redbull                 3,50 euros ");
        Console.WriteLine("Spa blue                2,50 euros ");
        Console.WriteLine("Tenesis                 2,50 euros ");
        Console.WriteLine("Milkshake strawberry    2,50 euros ");
        Console.WriteLine();
        Console.WriteLine("Press enter to continue");
        Console.ReadLine();
        FoodAndDrinks();
    }
    static void Food(){
        Console.Clear();
        Console.WriteLine("These are the foods we sell at the restaurant");
        Console.WriteLine();
        Console.WriteLine("Popcorn Small            2,50 euros ");
        Console.WriteLine("Popcorn Medium           3,50 euros");
        Console.WriteLine("Popcorn Large            4,50 euros");
        Console.WriteLine("Tacos with cheese        4,50 euros");
        Console.WriteLine("Tacos with guacemole     4,50 euros");
        Console.WriteLine("Tacos with chili sauce   4,50 euros");
        Console.WriteLine("Chips                    2,50 euros");
        Console.WriteLine("Winegums                 2,50 euros");
        Console.WriteLine("m&m's                    4,50 euros");
        Console.WriteLine();

        Console.WriteLine("Press enter to continue");
        Console.ReadLine();
        FoodAndDrinks();
        
    }
    
    static void FoodAndDrinks(){
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("food & Drinks");
        Console.WriteLine("0: back\n1: Food\n2: Drinks");
        string UserInput = Console.ReadLine();
        switch  (UserInput){
            case "0":
                HomeScreen();
                break;
                
            case "1":
                Food();
                break;
        
            case "2":
                Drinks();
                break;
            
            default:
                FoodAndDrinks();
                break;
        
        }
    }

    static void ComingSoonScreen(){
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Come watch these movies soon");
        string comingsoonmovieInfo = File.ReadAllText(@"comingsoonmovies.json");
        List<MovieClass> Movielist = JsonConvert.DeserializeObject<List<MovieClass>>(comingsoonmovieInfo);
        foreach(var item in Movielist){
            Console.WriteLine($"Title: {item.Title}");
        }
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
    static void Info(){
        Console.Clear();
        Console.WriteLine("Phonenumber: 010 1234567");
        Console.WriteLine("Location: Coolsingel 2");
        Console.WriteLine("Mail: Cinema@gmail.com");
        Console.WriteLine("if there is a Problem just give us a call");
        Console.WriteLine("0 = back to Main menu");
        string Usernameseats = Console.ReadLine();
        if (Usernameseats == "0"){
            Console.Clear();
            HomeScreen();}
    }
    static void InfoScreen(){
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Cinema info");
        Console.WriteLine("0: back\n1: Information Cinema");
        string UserInput = Console.ReadLine();
        switch (UserInput){
            case "0":
                Console.Clear();
                HomeScreen();
                break;

            case "1":
                Console.Clear();
                Info();
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
        Console.WriteLine("0: Admin logoff\n1: Movies\n2: Reviews \n3: Total Revenue\n4: Add movie show \n5: show all Reservations");
        string reservationjson = File.ReadAllText(@"reservations.json");
        List<Reservation> reservationdata = JsonConvert.DeserializeObject<List<Reservation>>(reservationjson);
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

            case "2":
                Console.Clear();
                AdminReviews();
                break;
            
            case "3":
                Console.Clear();
                
                double subTotal = 0.0;
                int totalReservations = reservationdata.Count;
                foreach (var reservation in reservationdata){
                    subTotal += reservation.TotalCost;
                }
                
                double averageRevenue = Math.Round(subTotal / totalReservations, 2);

                Console.WriteLine($"Total Revenue: {subTotal} euro \nWith a total of {totalReservations} reservations, the average Reservation revenue is {averageRevenue} euro");
                Console.WriteLine("press Enter to continue");
                Console.WriteLine();
                Console.ReadLine();
                AdminHome();
                break;

            case "4":
                Console.Clear();
                Console.WriteLine("Add movie show: \nPlease choose a movie title to add");
                string movieInfo = File.ReadAllText(@"movies.json");
                List<MovieClass> Movielist = JsonConvert.DeserializeObject<List<MovieClass>>(movieInfo);
                
                string seatinfo = File.ReadAllText(@"seats.json");
                List<Seats> seatString = JsonConvert.DeserializeObject<List<Seats>>(seatinfo);

                int choice = 0;
                foreach (var movie in Movielist){
                    Console.WriteLine($"{choice++}: {movie.Title}");
                }
                bool isvalid = false;
                while (!isvalid){
                    string UserChoice = Console.ReadLine();
                    try {
                        choice = Convert.ToInt32(UserChoice);
                        isvalid = true;
                    } catch {
                        Console.WriteLine("Please enter valid number");
                    }
                }
                Console.WriteLine($"you have chosen {Movielist[choice].Title}");
                Console.WriteLine("currently, this movie has these timeslots available to customers:");
                foreach(var showing in seatString){
                    if (showing.Title == Movielist[choice].Title){
                        Console.WriteLine(showing.Timeslot);
                    }
                }
                Console.WriteLine("Please enter a Valid Timeslot value (e.g. 20:00 for 8 PM)");
                string chosenTimeSlot = Console.ReadLine();
                Seats newSeat = new Seats {
                    Title = Movielist[choice].Title,
                    Timeslot = chosenTimeSlot,
                    Genre = Movielist[choice].Genre,
                    Language = Movielist[choice].Language,
                    PlayTime = Movielist[choice].PlayTime,
                    seats = "01U 02U 03U 04U 05U 06U 07U 08U 09U 10U\n11U 12U 13U 14U 15U 16U 17U 18U 19U 20U\n21U 22U 23U 24U 25U 26U 27U 28U 29U 30U\n",
                };
                if (seatString == null){
                    seatString = new List<Seats>();
                }
                seatString.Add(newSeat);
                File.WriteAllText(@"seats.Json",JsonConvert.SerializeObject(seatString, Formatting.Indented));
                Console.WriteLine("Movie show added!");


                AdminHome();
                break;
            case "5":
                Console.Clear();

                foreach (var item in reservationdata){
                    if (item.Username == null){
                        Console.WriteLine($"Seat: {item.SeatNumber}, reservationNumber: {item.ordernumber}, for {item.MovieName}. at timeslot: {item.Timeslot}");
                    } else {
                        Console.WriteLine($"Seat: {item.SeatNumber}, reservation by user: {item.Username}, for {item.MovieName}. at timeslot: {item.Timeslot}");
                    }
                }
                Console.ReadLine();
                AdminHome();
                break;
            default:
                Console.Clear();
                Console.WriteLine("Please enter a valid number.");
                AdminHome();
                break;
            }
    }
    static void AdminReviews(){
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Please select a Review to delete");
        Console.WriteLine("0: Cancel");
        
        string Reviews = File.ReadAllText(@"reviews.json");
        List<Review> ReviewList = JsonConvert.DeserializeObject<List<Review>>(Reviews);
        int count = 1;
        foreach (var item in ReviewList){
            Console.WriteLine($"{count++}: movie: {item.Title}, User: {item.Username}, Review: {item.ReviewString}");
        }
        string UserInput = Console.ReadLine();
        int input = 0;
        try{
            input = Convert.ToInt32(UserInput);
        } catch{
            Console.WriteLine("Please enter a valid Number");
            input = 0;
        }
        int ListLen = ReviewList.Count;
        if (input > 0 && input <= ListLen){
            int choice = input - 1;
            Console.Clear();
            Console.WriteLine($"are you sure you want to delete this the review: {ReviewList[choice].ReviewString}? Y/N");
            string deleteOrnot = Console.ReadLine();
            if (deleteOrnot == "Y" || deleteOrnot == "y"){
                ReviewList.RemoveAt(choice);
                Console.WriteLine("Review Was removed");
            } else {
                Console.WriteLine("Review was not removed");
            }
            string serialisedReviewList = JsonConvert.SerializeObject(ReviewList, Formatting.Indented);
            File.WriteAllText(@"reviews.Json",serialisedReviewList);
            AdminReviews();
        } else if (input == 0){ 
            AdminHome();
        } else {
            Console.WriteLine("Please enter a valid number");
            AdminReviews();
        }
        
    }
    static void AccountSettings(Tuple<bool, int> accindex){
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Account Settings");
        Console.WriteLine("0: back\n1: edit username\n2: edit password\n3: edit name\n4: edit surname\n5: edit email\n6: edit phone number\n7: delete account\n8: view reservations\n9: view watchlist");
        string logininfo = File.ReadAllText(@"login.json");
        List<LoginClass> Loginlist = JsonConvert.DeserializeObject<List<LoginClass>>(logininfo);
        string reservationsinfo = File.ReadAllText(@"reservations.json");
        List<Reservation> reservationlist = JsonConvert.DeserializeObject<List<Reservation>>(reservationsinfo);
        string UserInput = Console.ReadLine();
        switch (UserInput){
            case "0":
                Console.Clear();
                LoginScreen();
                break;
            case "1":
                Console.Clear();
                Console.WriteLine("Enter new username: ");
                UserInput = Console.ReadLine();
                Loginlist[accindex.Item2].Username = UserInput;
                File.WriteAllText(@"login.Json",JsonConvert.SerializeObject(Loginlist, Formatting.Indented));
                Console.WriteLine("Username updated");
                AccountSettings(accindex);
                break;
            case "2":
                Console.Clear();
                Console.WriteLine("Enter new password: ");
                UserInput = Console.ReadLine();
                Loginlist[accindex.Item2].Password = UserInput;
                File.WriteAllText(@"login.Json",JsonConvert.SerializeObject(Loginlist, Formatting.Indented));
                Console.WriteLine("Password updated");
                AccountSettings(accindex);
                break;
            case "3":
                Console.Clear();
                Console.WriteLine("Enter new password: ");
                UserInput = Console.ReadLine();
                Loginlist[accindex.Item2].Name = UserInput;
                File.WriteAllText(@"login.Json",JsonConvert.SerializeObject(Loginlist, Formatting.Indented));
                Console.WriteLine("Name updated");
                AccountSettings(accindex);
                break;
            case "4":
                Console.Clear();
                Console.WriteLine("Enter new password: ");
                UserInput = Console.ReadLine();
                Loginlist[accindex.Item2].Surname = UserInput;
                File.WriteAllText(@"login.Json",JsonConvert.SerializeObject(Loginlist, Formatting.Indented));
                Console.WriteLine("Surname updated");
                AccountSettings(accindex);
                break;
            case "5":
                Console.Clear();
                Console.WriteLine("Enter new password: ");
                UserInput = Console.ReadLine();
                Loginlist[accindex.Item2].Email = UserInput;
                File.WriteAllText(@"login.Json",JsonConvert.SerializeObject(Loginlist, Formatting.Indented));
                Console.WriteLine("Email updated");
                AccountSettings(accindex);
                break;
            case "6":
                Console.Clear();
                Console.WriteLine("Enter new password: ");
                UserInput = Console.ReadLine();
                Loginlist[accindex.Item2].Phone = UserInput;
                File.WriteAllText(@"login.Json",JsonConvert.SerializeObject(Loginlist, Formatting.Indented));
                Console.WriteLine("Phone updated");
                AccountSettings(accindex);
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
                File.WriteAllText(@"login.Json",JsonConvert.SerializeObject(Loginlist, Formatting.Indented));
                LoginScreen();
                break;
            case "8":
                Console.Clear();
                bool reserved = false;
                int ordernummer = 0;
                List<string> nummerlist = new List<string>();
                foreach (Reservation reservation in reservationlist){
                    if (reservation.Username == Loginlist[accindex.Item2].Username){
                        Console.WriteLine($"Reservation number: {ordernummer} Movie: '{reservation.MovieName}' Seatnumber: {reservation.SeatNumber}");
                        reserved = true;
                        nummerlist.Add(ordernummer.ToString());
                    }
                    ordernummer++;
                }
                Console.WriteLine();
                if (reserved == false){
                    Console.WriteLine("You didn't make a reservation yet.");
                    AccountSettings(accindex);
                }
                else{
                    Console.WriteLine("1: Delete a reservation\n0: Back");
                    UserInput = Console.ReadLine();
                    if (UserInput == "0"){
                        Console.Clear();
                        AccountSettings(accindex);
                    }
                    else if (UserInput == "1"){
                        Console.WriteLine("Enter the reservation number of the movie you want to delete: ");
                        UserInput = Console.ReadLine();
                        bool resfound = false;
                        foreach (string s in nummerlist){
                            if (UserInput == s){
                                reservationlist.RemoveAt(Convert.ToInt32(s));
                                Console.WriteLine("Your reservation has been deleted");
                                File.WriteAllText(@"reservations.Json",JsonConvert.SerializeObject(reservationlist, Formatting.Indented));
                                resfound = true;
                            }
                        }
                        if (resfound){
                            Console.Clear();
                            AccountSettings(accindex);
                        }
                        else{
                            Console.Clear();
                            Console.WriteLine("Reservation not found please enter a valid number.");
                            AccountSettings(accindex);
                        }
                    }
                    else{
                        Console.Clear();
                        Console.WriteLine("Please enter a valid number.");
                        AccountSettings(accindex);
                    }
                }
                break;
            
            case "9":
                Console.Clear();
                if (Loginlist[accindex.Item2].Watchlist != null){
                    foreach (string item in Loginlist[accindex.Item2].Watchlist){
                        Console.WriteLine(item);
                    }
                } else {
                    Console.WriteLine("You have not watched any movie yet");
                }
                Console.WriteLine("\npress enter to continue");
                Console.ReadLine();
                AccountSettings(accindex);
                break;

            default:
                Console.Clear();
                Console.WriteLine("Please enter a valid number.");
                AccountSettings(accindex);
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
    static void ReviewScreen(string MovieName){
        string movieInfo = File.ReadAllText(@"movies.json");
        List<MovieClass> Movielist = JsonConvert.DeserializeObject<List<MovieClass>>(movieInfo);
        int MovieIndex = 0;
        for (int i = 0; i < Movielist.Count;i++){
            if (Movielist[i].Title == MovieName){
                MovieIndex = i;
                break;
            }
        }
        Console.WriteLine($"{MovieName} Reviews");
        Console.WriteLine("0: back \n1: Leave Review");
        Console.WriteLine();

        string Reviews = File.ReadAllText(@"reviews.json");
        List<Review> ReviewList = JsonConvert.DeserializeObject<List<Review>>(Reviews);
        foreach (var item in ReviewList){
            if(item.Title == MovieName){
                Console.WriteLine($"{item.Username}: {item.ReviewString}");
            }
        }

        string UserInput = Console.ReadLine();
        switch(UserInput){
            
            case "0":
                Console.Clear();
                MovieScreen();
                break;
            
            case "1":
                Console.Clear();
                AddReviewScreen(MovieName);
                break;

            default:
                Console.Clear();
                Console.WriteLine("Please enter a valid number.");
                ReviewScreen(MovieName);
                break;

        }
        



        //Console.WriteLine($"review {MovieName}");

    }
    static void AddReviewScreen(string MovieName){
        string movieInfo = File.ReadAllText(@"movies.json");
        List<MovieClass> Movielist = JsonConvert.DeserializeObject<List<MovieClass>>(movieInfo);
        int MovieIndex = 0;
        for (int i = 0; i < Movielist.Count;i++){
            if (Movielist[i].Title == MovieName){
                MovieIndex = i;
                break;
            }
        }
        string Reviews = File.ReadAllText(@"reviews.json");
        List<Review> ReviewList = JsonConvert.DeserializeObject<List<Review>>(Reviews);

        Review newReview = new Review();
        newReview.Title = MovieName;
        Console.WriteLine("Please Enter your Review");
        newReview.ReviewString = Console.ReadLine();
        Console.WriteLine("Please enter your name");
        newReview.Username = Console.ReadLine();

        if (ReviewList == null){
            ReviewList = new List<Review>();
        }
        ReviewList.Add(newReview);
        
        string serialisedReviewList = JsonConvert.SerializeObject(ReviewList, Formatting.Indented);
        File.WriteAllText(@"reviews.Json",serialisedReviewList);
        Console.WriteLine("Added!");
        Console.ReadLine();
        ReviewScreen(MovieName);


    }
}

public class Phrases{
    public static string inputPlease(){
        Console.WriteLine("Please input a number to see the following menus:\n");
        Console.WriteLine("1: Login\n2: view all movies\n3: reserve a movie\n4: Food & Drinks\n5: coming soon\n6: info\n");
        
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