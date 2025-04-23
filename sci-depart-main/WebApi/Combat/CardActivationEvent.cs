using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class CardActivationEvent:MatchEvent
    {
        public override string EventType { get { return "CardActivation"; } }
        public int PlayerId { get; set; }
        public int PlayableCardId { get; set; }

        public CardActivationEvent(Match match, MatchPlayerData currentPlayer, MatchPlayerData defendingPlayer, PlayableCard currentPlayerCard, PlayableCard? oppositePlayerCard)
        {
            PlayerId = currentPlayer.PlayerId;
            PlayableCardId = currentPlayerCard.Id;
            Events = new List<MatchEvent>();
            if (currentPlayerCard.HasPower(Power.HEAL_ID))
            {
                Events.Add(new HealEvent(currentPlayer, currentPlayerCard));
            }
        }
    }
}
