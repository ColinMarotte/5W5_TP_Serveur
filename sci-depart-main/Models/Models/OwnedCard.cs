using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Super_Cartes_Infinies.Models
{
    public class OwnedCard
    {
        public OwnedCard() { }
        public int Id { get; set; }
        public int CardId { get; set; } 
        public virtual Card Card { get; set; }
        public int PlayerId { get; set; }  
        [JsonIgnore]
        public virtual Player Player { get; set; }
        [JsonIgnore]
        public virtual List<DeckOwnedCard> DeckOwnedCards { get; set; } = new List<DeckOwnedCard>();
    }
}
