using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class PlayerDeathEvent:MatchEvent
    {
        public override string EventType { get { return "PlayerDeath"; } }
        public int LosingPlayerId { get; set; }

        public PlayerDeathEvent(Match match, MatchPlayerData winningPlayerData, MatchPlayerData losingPlayerData)
        {
            LosingPlayerId = losingPlayerData.PlayerId;
            Events = new List<MatchEvent>();
            Events.Add(new EndMatchEvent(match, winningPlayerData, losingPlayerData));
        }
    }
}
