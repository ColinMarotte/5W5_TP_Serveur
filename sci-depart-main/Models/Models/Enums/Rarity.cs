using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models.Enums
{
    public enum Rarity{ Common, Rare, Epic, Legendary }
    public static class RarityInfo
    {
        private static readonly Dictionary<Rarity, int> _prices = new Dictionary<Rarity, int>
    {
        { Rarity.Common, 10 },
        { Rarity.Rare, 50 },
        { Rarity.Epic, 100 },
        { Rarity.Legendary, 200 }
    };

        public static int GetPrice(Rarity rarity) => _prices[rarity];
    }

}
