using System;
using System.Text.Json;
using System.Text.Json.Serialization;
/*class Program {
  public static void Main(){
      weatherForecast = JsonSerializer.Deserialize<test>(jsonString);
  }
}

class Scherm {

}*/

public class Screen{
    public static void HomeScreen(string ding){
        Console.WriteLine($"hallo, u typt: {ding}");
    }
}

public class Phrases{
    public static string inputPlease(){
        Console.WriteLine("Please input a number to see the following menus:");
        Console.WriteLine("1: login\n2: movies\n3: reserve\n4: coming soon\n5: info");
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
                // login screen
                Console.WriteLine("u typt 1");
            } else if (UserInput == "2"){
                // movies screen
                Console.WriteLine("u typt 2");
            } else if (UserInput == "3"){
                // reserve screen
                Console.WriteLine("u typt 3");
            } else if (UserInput == "4"){
                // coming soon screen
                Console.WriteLine("u typt 4");
            } else if (UserInput == "5"){
                // info screen
                Console.WriteLine("u typt 5");
            } else if (UserInput == "0"){
              break;
            }
            Console.WriteLine("press enter to continue");
            Console.ReadLine();

        }
        
        
    }
}