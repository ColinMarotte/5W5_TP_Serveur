using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Models
{
    public class PlayableCardStatus
    {
        public int Id { get; set; }

        public int PlayableCardId { get; set; }
        public virtual PlayableCard PlayableCard { get; set; } = new PlayableCard();

        public int StatusId { get; set; }

        [JsonIgnore]
        public virtual Status Status { get; set; } = new Status();

    }
}
