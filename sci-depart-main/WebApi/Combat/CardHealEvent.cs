using Microsoft.Identity.Client;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class CardHealEvent : MatchEvent
    {
        public override string EventType { get { return "CardHeal"; } }
        public int PlayerId { get; set; }
        public int PlayableCardId { get; set; }
        public int Value { get; set; }
        public int BattlefieldIndex { get; set; }

        public CardHealEvent(MatchPlayerData playerData, int value, int index)
        {
            PlayableCard playableCard = playerData.BattleField[index];
            this.PlayerId = playerData.PlayerId;
            PlayableCardId = playableCard.Id;
            Value = value;
            BattlefieldIndex = index;
            playableCard.Health += value;
        }
    }
}
