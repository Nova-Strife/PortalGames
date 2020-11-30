using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace PortalGames.ViewModels
{
    public class FilterViewModel
    {
        public FilterViewModel(string name, decimal? startPrice, decimal? endPrice)
        {
            Name = name;
            StartPrice = startPrice;
            EndPrice = endPrice;
        }
        public string Name { get; private set; }
        public decimal? StartPrice { get; private set; }
        public decimal? EndPrice { get; private set; }
    }
}