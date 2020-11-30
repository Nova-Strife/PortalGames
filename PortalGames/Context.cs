using Microsoft.EntityFrameworkCore;
using PortalGames.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PortalGames
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<Game> Games { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CreditCard> Cards { get; set; }
    }
}
