using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{
    public class Weather
    {
        public Weather(string city, int temperatureC)
        {
            City = city;
            TemperatureC = temperatureC;
        }

        public string City { get; set; }
        public int TemperatureC { get; set; }
        public string TemperatureName => TemperatureC switch
        {
            var t when t <= -30 => "Мороз",
            var t when t >= -30 && t <= -10 => "Холодно",
            var t when (t >= -10 && t <= 0) || (t >= 0 && t <= 10) => "Прохладно",
            var t when t >= 10 && t <= 30 => "Тепло",
            var t when t >= 30 => "Жарко",
            _ => "Нет данных о погоде!"
        };

        public override string ToString()
        {
            return $"{City} {TemperatureC:#˚C}. {TemperatureName}";
        }
    }
}
