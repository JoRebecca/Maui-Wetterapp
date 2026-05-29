using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace MauiApp1
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient; // sende HTTP ANfrage like a browser
        private readonly string _apiKey = "eaa79f6d5e91199baa37902bbc11c673";

        public WeatherService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<WeatherData?> GetWeatherAsync(string city) // warte auf Intrenet und vielleicht null(?)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather" +
                         $"?q={city}&appid={_apiKey}&units=metric&lang=de";

            HttpResponseMessage response = await _httpClient.GetAsync(url); // sende Anfrage und erwarte ANtwort

            if (!response.IsSuccessStatusCode) //prüfe funktionado HTTp 200
            {
               
                Console.WriteLine($"Fehler: {response.StatusCode}");
                return null;
            }

            string json = await response.Content.ReadAsStringAsync(); //gibt String zurück



            using JsonDocument doc = JsonDocument.Parse(json);//json text verabeitbar machen
            JsonElement root = doc.RootElement; //greif auf feld im json zu

            return new WeatherData
            {
                CityName = root.GetProperty("name").GetString()!, // hole mir die daten die ich brauche aus baumverzeichnis
                Temperature = root.GetProperty("main").GetProperty("temp").GetDouble(),
                FeelsLike = root.GetProperty("main").GetProperty("feels_like").GetDouble(),
                TempMax= root.GetProperty("main").GetProperty("temp_max").GetDouble(),
                TempMin = root.GetProperty("main").GetProperty("temp_min").GetDouble(),
                Description = root.GetProperty("weather")[0].GetProperty("description").GetString()!,// ! weil wegn string 
                Humidity = root.GetProperty("main").GetProperty("humidity").GetInt32(),
                WindSpeed = root.GetProperty("wind").GetProperty("speed").GetDouble(),
                IconCode = root.GetProperty("weather")[0].GetProperty("icon").GetString()!

            };
        }
    }
}


//openweather oder https://brightsky.dev/
