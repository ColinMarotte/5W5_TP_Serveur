using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Models.Interfaces;
using Models.Models.Enums;

namespace Super_Cartes_Infinies.Models
{
    public class Card:IModel
	{
		public Card() { }

		public int Id { get; set; }
		[DisplayName("Nom")]
		public string Name { get; set; } = "";
        [DisplayName("Attaque")]
        public int Attack { get; set; }
        [DisplayName("Points de vie")]
        public int Health { get; set; }
        [DisplayName("Coût")]
        public int Cost { get; set; }
        [DisplayName("Image")]
        public string ImageUrl { get; set; } = "";
        [DisplayName("Rareté")]
        [EnumDataType(typeof(Rarity))]
        public Rarity Rarity { get; set; }
        [DisplayName("Prix")]
        public int Price { get; set; }
        [JsonIgnore]
		public virtual List<StartingCard> StartingCards { get; set; } = new List<StartingCard>();
        [JsonIgnore]
        public virtual List<OwnedCard> OwnedCards { get; set; } = new List<OwnedCard>();
        [ValidateNever]
        [DisplayName("Pouvoirs")]
		
		public virtual List<CardPower> CardPowers { get; set; } 
    }
}

