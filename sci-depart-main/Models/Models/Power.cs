using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Super_Cartes_Infinies.Models
{
    public class Power
    {
        public const int FIRST_STRIKE_ID = 1;
        public const int THORNS_ID = 2;
        public const int HEAL_ID = 3;
        public const int SHIELD_ID = 4;
        public const int CHAOS_ID = 5;
        public const int POISON_ID = 6;
        public const int STUNNED_ID = 7;
        public const int EXPLOSIVE_ID = 8;

        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        public string Icone { get; set; } = "";

        [JsonIgnore]
        [ValidateNever]
        public virtual List<CardPower> CardPowers { get; set; } = new List<CardPower>();
    }
}
