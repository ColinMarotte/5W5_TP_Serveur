using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Cartes_Infinies.Models
{
    public class Power
    {
        public const int FIRST_STRIKE_ID = 1;
        public const int THORNS_ID = 2;
        public const int HEAL_ID = 3;

        public int Id { get; set; }

        // TODO: À compléter

        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        public string Icone { get; set; } = "";
    }
}
