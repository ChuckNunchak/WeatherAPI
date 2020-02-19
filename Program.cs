using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=London&units=metric&appid=1ffdfdc6a19d489e6c66222c8b085ea9";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

            Console.WriteLine("Temperature in {0}: {1} °C", weatherResponse.Name, weatherResponse.Main.Temp);

            Console.ReadLine();
        }
    }
}
