using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Cartes_Infinies.Models
{
    public class GameConfig
    {
        public int Id { get; set; }
        public int NbCardsToDraw { get; set; }
        public int QtyManaPerTurn { get; set; }
    }
}
