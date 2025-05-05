using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Cartes_Infinies.Models
{
    public class GameConfig
    {
        public int Id { get; set; }
        [DisplayName("Nbr cartes à piger avant de commencer la partie")]
        public int NbCardsToDraw { get; set; }
        [DisplayName("Qti Mana reçu au début de chaque tour")]
        public int QtyManaPerTurn { get; set; }
        [DisplayName("Nombre maximum de decks")]
        public int NbDecksMax { get; set; }
        [DisplayName("Nombre maximum de cartes dans un deck")]
        public int NbCardsMaxInDeck { get; set; }
        [DisplayName("Argent reçu par le gagnant après un match")]
        public int ArgentRecuGagnant { get; set; }
        [DisplayName("Argent reçu par le perdant après un match")]
        public int ArgentRecuPerdant { get; set; }
        public int ELONouveauJoueur { get; set; }
        public int BalanceNouveauJoueur { get; set; }

    }
}
