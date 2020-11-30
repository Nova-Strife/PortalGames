using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PortalGames.Controllers;
using PortalGames.Models;
using PortalGames.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using PortalGames;
using System.Linq;

namespace PortalGames_Tests
{
    [TestFixture]
    public class Tests
    {
        public Context db;
        [SetUp]
        public void SetUp()
        {
        }
        [Test]
        public void Shift()
        {
            Assert.AreEqual(5, db.Games.ToArray()[0..5]);
        }
    }
}