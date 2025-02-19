using System.ComponentModel;
using Models.Interfaces;
using Models.Models;

namespace Super_Cartes_Infinies.Models
{
    public class Card:IModel
	{
		public Card() { }

		public int Id { get; set; }
		public string Name { get; set; } = "";
		public int Attack { get; set; }
		public int Health { get; set; }
		public int Cost { get; set; }
        public string ImageUrl { get; set; } = "";
		public virtual List<StartingCard> StartingCards { get; set; } = new List<StartingCard>();
		public virtual List<OwnedCard> OwnedCards { get; set; } = new List<OwnedCard>();
    }
}

