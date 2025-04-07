using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Super_Cartes_Infinies.Models
{
    public class Deck
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public bool Current { get; set; }
        public int PlayerId { get; set; }
        [JsonIgnore]
        public virtual Player Player { get; set; }
        public virtual List<DeckOwnedCard> DeckOwnedCards { get; set; } = new List<DeckOwnedCard>();
    }
}
