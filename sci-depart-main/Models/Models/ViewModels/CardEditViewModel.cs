using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models.ViewModels
{
    public class CardEditViewModel
    {
        public Card Card { get; set; }
        public List<CardPower> CardPowers { get; set; }
        public List<Power> AllPowers { get; set; }

        public int SelectedPowerId { get; set; }
        public int? PowerValue { get; set; }
    }
}
