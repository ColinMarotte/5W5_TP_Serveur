using Microsoft.AspNetCore.Http.HttpResults;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class CombatEvent : MatchEvent
    {
        public override string EventType { get { return "Combat"; } }
        public int PlayerId { get; set; }

        public CombatEvent(Match match, MatchPlayerData currentPlayerData, MatchPlayerData oppositePlayerData)
        {
            Events = new List<MatchEvent>();
            currentPlayerData.BattleField = currentPlayerData.GetOrderedBattleField();
            oppositePlayerData.BattleField = oppositePlayerData.GetOrderedBattleField();
            PlayerId = currentPlayerData.PlayerId;

            for (int i = currentPlayerData.BattleField.Count()-1; i >= 0; i--)
            {
                Events.Add(new CardActivationEvent(match, currentPlayerData, oppositePlayerData, i));
            }
        }
    }
}
