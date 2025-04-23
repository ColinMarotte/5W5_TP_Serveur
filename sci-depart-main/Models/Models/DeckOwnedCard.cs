using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Super_Cartes_Infinies.Models
{
    public class DeckOwnedCard
    {
        public int Id { get; set; }
        public int DeckId { get; set; }
        [JsonIgnore]
        public virtual Deck Deck { get; set; }
        public int OwnedCardId { get; set; }
        public virtual OwnedCard OwnedCard { get; set; }
    }
}
