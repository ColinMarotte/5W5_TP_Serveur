using Microsoft.AspNetCore.Http.HttpResults;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class CombatEvent : MatchEvent
    {
        public override string EventType { get; }
        public int PlayerId { get; set; }

        public CombatEvent(MatchPlayerData currentPlayerData, MatchPlayerData oppositePlayerData)
        {
            Events = new List<MatchEvent>();
            IEnumerable<PlayableCard> currentPlayerBattleField = currentPlayerData.GetOrderedBattleField();
            IEnumerable<PlayableCard> oppositePlayerBattleField = oppositePlayerData.GetOrderedBattleField();
            if(currentPlayerBattleField.Count() <= 0)
            {
                return;
            }
            PlayerId = currentPlayerData.PlayerId;
            for (int i = 0; i < currentPlayerBattleField.Count(); i++)
            {
                PlayableCard? playerCard = currentPlayerBattleField.ElementAt(i);
                PlayableCard? oppositePlayerCard = null;
                if (i < oppositePlayerBattleField.Count())
                {
                    oppositePlayerCard = oppositePlayerBattleField.ElementAt(i);
                }

                if (oppositePlayerCard == null)
                {
                    //CardAttackEvent
                }
                if (playerCard.HasPower(Power.HEAL_ID))
                {
                    //CardActivationEvent
                }
                if (playerCard.HasPower(Power.FIRST_STRIKE_ID))
                {
                    //CardActivationEvent
                }
                else
                {
                    //attackEvent
                }
            }
        }
    }
}
