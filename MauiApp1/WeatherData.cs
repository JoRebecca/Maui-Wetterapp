using System;
using System.Collections.Generic;
using System.Text;

namespace MauiApp1
{
    public class WeatherData
    {
        public string? CityName { get; set; }
        public double Temperature { get; set; } //Celsius
        public double FeelsLike { get; set; } //Celsius gefühlte Temp
        public double TempMax { get; set; } //Celsius höchste temp
        public double TempMin { get; set; } //Celsius niedrigste temp
        public string? Description { get; set; } // leicht bewölkt etc
        public int Humidity { get; set; }   // luftfeuchtigkeit in prozent
        public double WindSpeed{ get; set; } //Windgeschwindigkeit in meter pro Sekunde
        public string? IconCode { get; set; }
    }
}
