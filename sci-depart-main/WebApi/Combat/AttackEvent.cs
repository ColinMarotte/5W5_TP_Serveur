using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class AttackEvent : MatchEvent
    {
        public override string EventType { get { return "Attack"; } }
        public int PlayerId { get; set; }


        public AttackEvent(Match match, MatchPlayerData currentPlayer, MatchPlayerData defendingPlayer, PlayableCard currentPlayerCard, PlayableCard? oppositePlayerCard, int index)
        {
            PlayerId = currentPlayer.PlayerId;

            Events = new List<MatchEvent>();
            if (oppositePlayerCard == null)
            {
                Events.Add(new PlayerDamageEvent(match, currentPlayer, defendingPlayer, currentPlayerCard.Attack));
            }
            else
            {
                if (currentPlayerCard.HasPower(Power.FIRST_STRIKE_ID) && currentPlayerCard.Attack > oppositePlayerCard.Health)
                {
                    Events.Add(new FirstStrikeEvent(currentPlayer, currentPlayerCard));


                    Events.Add(new CardDamageEvent(match, defendingPlayer, currentPlayer, currentPlayerCard, oppositePlayerCard.Attack, true, index));

                }
                else
                {
                    Events.Add(new CardDamageEvent(match, defendingPlayer, currentPlayer, currentPlayerCard, oppositePlayerCard.Attack, true, index));
                    Events.Add(new CardDamageEvent(match, currentPlayer, defendingPlayer, oppositePlayerCard, currentPlayerCard.Attack, false, index));
                }
            }
            
        }
    }
}
