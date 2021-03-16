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
class program{
    static void Main(){
        Console.WriteLine("typ iets");
        string usrinput = Console.ReadLine();
        Screen.HomeScreen(usrinput);
    }
}