using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class AttackEvent : MatchEvent
    {
        public override string EventType { get { return "Attack"; } }
        public int PlayerId { get; set; }


        public AttackEvent(Match match, MatchPlayerData currentPlayer, MatchPlayerData defendingPlayer, PlayableCard currentPlayerCard, PlayableCard? oppositePlayerCard)
        {
            PlayerId = currentPlayer.PlayerId;

            Events = new List<MatchEvent>();
            if(oppositePlayerCard == null)
            {
                Events.Add(new PlayerDamageEvent(match, currentPlayer, defendingPlayer, currentPlayerCard.Attack));
            }
            else
            {
                //AttackDamageEvent
                Events.Add(new CardDamageEvent(match, currentPlayer, defendingPlayer, oppositePlayerCard, currentPlayerCard.Attack,false));
                Events.Add(new CardDamageEvent(match, defendingPlayer, currentPlayer, currentPlayerCard, oppositePlayerCard.Attack,true));
            }
        }
    }
}
