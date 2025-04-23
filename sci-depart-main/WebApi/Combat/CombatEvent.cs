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
            IEnumerable<PlayableCard> currentPlayerBattleField = currentPlayerData.GetOrderedBattleField();
            IEnumerable<PlayableCard> oppositePlayerBattleField = oppositePlayerData.GetOrderedBattleField();
            PlayerId = currentPlayerData.PlayerId;
            if(currentPlayerBattleField.Count() <= 0)
            {
                return;
            }
            for (int i = currentPlayerBattleField.Count()-1; i >= 0; i--)
            {
                PlayableCard playerCard = currentPlayerBattleField.ElementAt(i);
                PlayableCard? oppositePlayerCard = null;
                if (i < oppositePlayerBattleField.Count())
                {
                    oppositePlayerCard = oppositePlayerBattleField.ElementAt(i);
                }


                    Events.Add(new AttackEvent(match, currentPlayerData, oppositePlayerData, playerCard, oppositePlayerCard, i));
                //if (oppositePlayerCard == null)
                //{
                //    //CardAttackEvent

                //}
                //else
                //{
                //    //attackEvent
                //    Events.Add(new AttackEvent(match, currentPlayerData, oppositePlayerData, playerCard, oppositePlayerCard));

                //}
            }
        }
    }
}
