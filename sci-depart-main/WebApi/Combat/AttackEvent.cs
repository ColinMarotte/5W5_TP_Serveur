using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class AttackEvent : MatchEvent
    {
        public override string EventType { get { return "Attack"; } }
        public int PlayerId { get; set; }


        public AttackEvent(Match match, MatchPlayerData attackingPlayer, MatchPlayerData defendingPlayer, PlayableCard currentPlayerCard, PlayableCard? oppositePlayerCard)
        {
            PlayerId = attackingPlayer.PlayerId;

            Events = new List<MatchEvent>();
            if(oppositePlayerCard == null)
            {
                Events.Add(new PlayerDamageEvent(match, attackingPlayer, defendingPlayer, currentPlayerCard.Attack));
            }
            else
            {
                //AttackDamageEvent
            }
        }
    }
}
