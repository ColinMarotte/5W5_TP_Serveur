using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Cartes_Infinies.Models
{
    public class CardPower
    {
        public int Id { get; set; }
        public int CardId { get; set; }

        [ForeignKey("CardId")]
        public virtual Card Card { get; set; }
        public int PowerId { get; set; }

        [ForeignKey("PowerId")]
        public virtual Power Power { get; set; }
        public int Value { get; set; }
    }
}
