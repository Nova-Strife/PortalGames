using Microsoft.EntityFrameworkCore.Internal;
using PortalGames.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PortalGames
{
    public static class Repository
    {
        public static Cart Cart { get; set; } = new Cart();
        public static List<Game> MyGames { get; set; } = new List<Game>();
        public static decimal Sum { get; set; } = 10000.00m;
        public static Account Account { get; set; }

        private const string keys = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public static string GenerateKey()
        {
            var key = "";
            var r = new Random();
            for (var i = 0; i < 16; i++)
            {
                if (i == 4 || i == 8 || i == 12)
                    key += '-';
                key += keys[r.Next(0, keys.Length)];
            }
            return key;
        }
    }
}
