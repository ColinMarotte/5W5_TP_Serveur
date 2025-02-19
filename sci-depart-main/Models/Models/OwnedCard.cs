using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class OwnedCard
    {
        public OwnedCard() { }
        public int Id { get; set; }
        public virtual Card Card { get; set; }
        public virtual Player Player { get; set; }
    }
}
