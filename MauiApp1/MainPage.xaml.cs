using System.Text.Json;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private readonly WeatherService _weatherService;

        public MainPage()
        {
            InitializeComponent();
            _weatherService = new WeatherService();
            LoadWeatherAsync("Leipzig");
        }

        private async Task LoadWeatherAsync(string city)
        {
            CityEntry.Text = string.Empty;
            try
            {
                WeatherData? weather = await _weatherService.GetWeatherAsync(city);

                if (weather == null)
                {
                    return;
                }

                CityLabel.Text = weather.CityName;
                TempLabel.Text = $"{weather.Temperature}°C";
                TempMaxLabel.Text = $"▲ {weather.TempMax}°C";
                TempMinLabel.Text = $"▼ {weather.TempMin}°C";
                FeelsLikeLabel.Text = $"{weather.FeelsLike}°C";
                HumidityLabel.Text = $"{weather.Humidity}%";
                WindLabel.Text = $"{weather.WindSpeed * 3.6:F0} km/h";
                WeatherIcon.Source = $"https://openweathermap.org/img/wn/{weather.IconCode}@2x.png";

                double fahrenheit = (weather.Temperature * 9 / 5) + 32;
                FahrenheitLabel.Text = $"{fahrenheit:F1}°F";
            }
            catch(Exception ex)
            {
                await DisplayAlertAsync("Exception", ex.Message, "OK");
            }
            


        }

        private async void OnSearchClicked(object sender, EventArgs e)
        {
            string city = CityEntry.Text;

            if (string.IsNullOrWhiteSpace(city))
            {
                return;
            }
            await LoadWeatherAsync(city);
            
        }

        private async void EnterEntry(object sender, EventArgs e)
        {
            string city = CityEntry.Text;
            await LoadWeatherAsync(city);
        }
    }
}
