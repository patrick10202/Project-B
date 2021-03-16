using System;
using System.Text.Json;
using System.Text.Json.Serialization;

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
            } else if (UserInput == "3"){
                Console.WriteLine("u typt 3");
            } else if (UserInput == "4"){
                Console.WriteLine("u typt 4");
            } else if (UserInput == "5"){
                Console.WriteLine("u typt 5");
            }
            Console.WriteLine("press enter to continue");
            Console.ReadLine();

        }
        
        
    }
}