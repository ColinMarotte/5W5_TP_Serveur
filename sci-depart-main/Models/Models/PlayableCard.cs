using Models.Interfaces;
using Models.Models;

namespace Super_Cartes_Infinies.Models
{
	public class PlayableCard : IModel
    {
		public PlayableCard()
		{
		}

        public PlayableCard(Card c)
        {
			Card = c;
            Health = c.Health;
            Attack = c.Attack;
        }

        public int Id { get; set; }
		public virtual Card Card { get; set; }
		public int Health { get; set; }
        public int Attack { get; set; }

        public bool HasPower(int powerId)
        {
            // Retourne true si la carte possède ce pouvoir.
            foreach(CardPower cardPower in Card.CardPowers)
            {
                if(cardPower.PowerId == powerId)
                {
                    return true;
                }
            }
            return false;
        }
        public int GetPowerValue(int powerId)
        {
            // Retourne les valeur du pouvoir pour cette carte.
            // Simplement retourner 0 si la carte ne possède pas ce pouvoir.
            if (HasPower(powerId))
            {
                CardPower? cardPower = Card.CardPowers.Where(cp => cp.PowerId == powerId).SingleOrDefault();
                return cardPower!.Value;
            }
            else
            {
                return 0;
            }
        }
    }
}

