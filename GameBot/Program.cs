using PortalGames;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace GameBot
{
    class Program
    {
        public static TelegramBotClient bot = new TelegramBotClient("1449472099:AAFlXg4Lai9GZciluTysajGfq_5Ud6qEa6k");
        static void Main()
        {
            bot.OnMessage += async (s, e) =>
            {
                try
                {
                    await bot.SendTextMessageAsync(e.Message.Chat.Id, GetAnswer(e.Message.Text));
                    Console.WriteLine(e.Message.Text);
                }
                catch
                {
                    await bot.SendTextMessageAsync(e.Message.Chat.Id, "Что то пошло не так! Внимательно прочти /help для использования");
                }
            };

            bot.StartReceiving();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Бот запущен...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("_____________");
            Console.Read();
        }

        static string GetAnswer(string message)
        {
            var cmds = message.Split(' ');
            var r = new Random();
            return cmds[0].ToLower() switch
            {
                "/ping" => "Pong!",
                "/help" => string.Join(Environment.NewLine,
                        "Основные команды:",
                        "/ping - Проверить работу бота",
                        "Погода 'NameCity' - Погода в определенном городе (NameCity - название города",
                        "/run 'path' - Запуск приложения на компьтере (path - полный путь до приложения)",
                        "/draw - Розыгрыш игры из вашей корзинки (в корзине должно быть не менее 5 игр)"),

                "/start" => string.Join(Environment.NewLine,
                                        "Основные команды:",
                                        "/ping - Проверить работу бота",
                                        "Погода 'NameCity' - Погода в определенном городе (NameCity - название города",
                                        "/run 'path' - Запуск приложения на компьтере (path - полный путь до приложения)",
                                        "/draw - Розыгрыш игры из вашей корзинки (в корзине должно быть не менее 5 игр)",
                                        "/help - Помощь"),

                "погода" => new Weather(cmds[1]).ToString(),

                "/run" =>
                $"Запущено приложение: {Process.Start(!cmds[1].Contains(".exe") ? cmds[1] + ".exe" : cmds[1]).ProcessName}",

                "/draw" => Repository.Cart.Count >= 5
                ? $"Название: {Repository.Cart[r.Next(0, Repository.Cart.Count)].Name}\n" +
                $"Ключ: {Repository.GenerateKey()}"
                : "В корзине должно быть не менее 5 игр!",

                _ => throw new NullReferenceException("Не удалось распознать команду!")
            };
        }
    }
}
