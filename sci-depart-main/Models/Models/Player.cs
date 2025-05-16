using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Models.Interfaces;
using Models.Models;

namespace Super_Cartes_Infinies.Models
{
	public class Player : IModel
    {
		public Player()
		{
		}

		public int Id { get; set; }
		public string Name { get; set; } = "";
		public int Balance { get; set; } = 1000;
		public required string UserId { get; set; }
		[JsonIgnore]
		public virtual IdentityUser User { get; set; }
        public virtual List<OwnedCard> OwnedCards { get; set; } = new List<OwnedCard>();
		public virtual List<Deck> Decks { get; set; } = new List<Deck>();
		public int ELO { get; set; } = 1000;
    }
}

