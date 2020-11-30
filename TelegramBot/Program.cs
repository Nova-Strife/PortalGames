using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBot
{
    class Program
    {
        public static TelegramBotClient bot = new TelegramBotClient("1449472099:AAFlXg4Lai9GZciluTysajGfq_5Ud6qEa6k");
        private static readonly List<Weather> weathers = new List<Weather>
        {
            new Weather("Москва",6),
            new Weather("Минск",6),
            new Weather("Киев",10),
            new Weather("Нур-Султан",-4),
            new Weather("Бишкек",4),
            new Weather("Амстердам",9),
            new Weather("Вашингтон",15),
            new Weather("Пекин",8),
            new Weather("Лондон",8),
            new Weather("Париж",9),
        };
        static void Main()
        {
            bot.OnMessage += async (s, e) => await bot.SendTextMessageAsync(
            e.Message.Chat.Id,
            GetAnswer(e.Message.Text));

            bot.StartReceiving();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Бот запущен...");
            Console.Read();
        }

        static string GetAnswer(string message)
        {
            var cmds = message.Split(' ');
            return message switch
            {
                var m when m == "/ping" || m == "ping" => "Pong",
                var m when m == "/hello" || m == "привет" => "Привет!",
                var m when m == "/bye" || m == "пока" => "Пока!",
                var m when m == "/yourfather" || m == "кто твой создатель?" => "Мой создатель - Вадим Губер",
                var m when m == "/yourname" || m == "как тебя зовут?" => "Меня зовут Game Bot",
                var m when cmds[0] == "/weather" || cmds[0] == "погода" =>
                cmds[1] == "все"
                ? string.Join(Environment.NewLine, weathers)
                : weathers.FirstOrDefault(e => e.City == cmds[1])?.ToString()
                ?? "Не удалось найти такой город!",
                var m when cmds[0] == "/run" =>
                $"Запущено приложение: {Process.Start(!cmds[1].Contains(".exe") ? cmds[1] + ".exe" : cmds[1]).ProcessName}",
                var m when cmds[0] == "/draw" => Repository.,
                _ => "Не удалось распознать команду!"
            };
        }
    }
}
