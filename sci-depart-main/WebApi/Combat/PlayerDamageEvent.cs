using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class PlayerDamageEvent:MatchEvent
    {
        public override string EventType { get { return "PlayerDamage"; } }
        public int PlayerId { get; set; }
        public int Value { get; set; }

        public PlayerDamageEvent(Match match, MatchPlayerData attackingPlayer, MatchPlayerData defendingPlayer, int value)
        {
            PlayerId = defendingPlayer.PlayerId;
            Value = value;
            if(defendingPlayer.Health <= value)
            {
                Events = new List<MatchEvent>();
                //PlayerDeathEvent
                defendingPlayer.Health = 0;
                Events.Add(new PlayerDeathEvent(match, attackingPlayer, defendingPlayer));
            }
            else
            {
                defendingPlayer.Health -= value;
            }
        }
    }
}
