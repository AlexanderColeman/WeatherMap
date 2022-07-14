using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMap
{
    public class WeatherMapApp
    {
        public void WeatherGetter()
        {
            var client = new HttpClient();

            while (true)
            {

                try
                {
                    Console.WriteLine("Please enter you API key");
                    var key = Console.ReadLine();

                    Console.WriteLine("\nPlease enter the city to see its forecast");
                    var city = Console.ReadLine();

                    var weatherURL = $"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid={key}&units=imperial";
                    var response = client.GetStringAsync(weatherURL).Result;


                    JObject formattedResponse = JObject.Parse(response);

                    var temp = formattedResponse["list"][0]["main"]["temp"];
                    Console.WriteLine($"\nThe current temperature in {city} is {temp}.");

                    Console.WriteLine("\nIf you would like to quit enter q otherwise press enter to see another weather forcast");
                    var continueOrQuit = Console.ReadLine();

                    if (continueOrQuit.ToLower().Equals('q'))
                    {
                        break;
                    }

                }
                catch (System.AggregateException ex)
                {
                    Console.WriteLine("\n\ncity or API key were invalid please try again");
                }

            }
        }

    }
}

