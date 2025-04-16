using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Super_Cartes_Infinies.Models
{
    public class CardPower
    {
        [Key]
        public int CardPowerId { get; set; }

        [ForeignKey("Card")]
        public int CardId { get; set; }
        [JsonIgnore]
        public virtual Card Card { get; set; }

        [ForeignKey("Power")]
        public int PowerId { get; set; }
		
		public virtual Power Power { get; set; }

        public int Value { get; set; }
    }
}
