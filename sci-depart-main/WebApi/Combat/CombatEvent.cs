using Microsoft.AspNetCore.Http.HttpResults;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
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
            for (int i = 0; i < currentPlayerBattleField.Count(); i++)
            {
                PlayableCard playerCard = currentPlayerBattleField.ElementAt(i);
                PlayableCard? oppositePlayerCard = null;
                if (i < oppositePlayerBattleField.Count())
                {
                    oppositePlayerCard = oppositePlayerBattleField.ElementAt(i);
                }
                if (playerCard.HasPower(Power.HEAL_ID))
                {
                    //CardActivationEvent
                }

                if (oppositePlayerCard == null)
                {
                    //CardAttackEvent
                    Events.Add(new AttackEvent(match, currentPlayerData, oppositePlayerData, playerCard, null));

                }
                else if (playerCard.HasPower(Power.FIRST_STRIKE_ID))
                {
                    //CardActivationEvent
                }
                else
                {
                    //attackEvent
                    Events.Add(new AttackEvent(match, currentPlayerData, oppositePlayerData, playerCard, oppositePlayerCard));

                }
            }
        }
    }
}
