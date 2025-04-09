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

            if(currentPlayerData.BattleField.Count <= 0)
            {
                return;
            }
            PlayerId = currentPlayerData.PlayerId;
            for (int i = 0; i < currentPlayerData.BattleField.Count; i++)
            {
                PlayableCard? playerCard = currentPlayerData.BattleField[i];
                PlayableCard? oppositePlayerCard = oppositePlayerData.BattleField[i];

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
