using System;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GameBot
{
    public class Weather
    {
        public string City { get; set; }
        public string Description { get; set; }
        public double Temperature { get; set; }
        public double TemperatureMin { get; set; }
        public double TemperatureMax { get; set; }
        public double Humidity { get; set; }
        public double WindSpeed { get; set; }

        public Weather(string cityName)
        {
            WebRequest request = WebRequest.Create(
            "https://api.openweathermap.org/data/2.5/weather?id=" + getCityId(cityName) + "&units=metric&APPID=fe67eef5eca07862135e95b634b02ae8");
            using StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream());
            var data = JObject.Parse(reader.ReadToEnd());
            City = data["name"].ToString();
            Temperature = double.Parse(data["main"]["temp"].ToString());
            Description = data["weather"].ToArray()[0]["description"].ToString();
            TemperatureMin = double.Parse(data["main"]["temp_min"].ToString());
            TemperatureMax = double.Parse(data["main"]["temp_max"].ToString());
            Humidity = double.Parse(data["main"]["humidity"].ToString()) / 100;
            WindSpeed = double.Parse(data["wind"]["speed"].ToString());

            static int getCityId(string city) =>
                city.ToLower() switch
                {
                    "астана" => 1526273,
                    "нур-султан" => 1526273,
                    "караганда" => 609655,
                    "москва" => 524901,
                    "петербург" => 493405,
                    "екатеринбург" => 1486209,
                    "париж" => 2988507,
                    "вашингтон" => 5815135,
                    "лондон" => 2643743,
                    "банкок" => 1609350,
                    "дубай" => 292223,
                    _ => throw new NullReferenceException("Город с таким названием не найден!"),
                };
        }
        public override string ToString() =>
            string.Join(Environment.NewLine,
            $"{City} {Temperature:#˚C} - {Description}",
            $"Влажность: {Humidity:#%}",
            $"Мин. температура: {TemperatureMin:#˚C}",
            $"Макс. температура: {TemperatureMax:#˚C}",
            $"Скорость ветра: {WindSpeed:# м/с}"
            );
    }
}