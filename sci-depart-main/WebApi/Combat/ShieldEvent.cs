
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class ShieldEvent:MatchEvent
    {
        public override string EventType { get { return "Shield"; } }
        public int PlayerId { get; set; }
        public int PlayableCardId { get; set; }
        public int DefenseValue { get; set; }
        public int BattlefieldIndex { get; set; }

        public ShieldEvent(Match match, MatchPlayerData currentPlayer, int index)
        {
            PlayableCard playerCard = currentPlayer.BattleField.ElementAt(index);
            BattlefieldIndex = index;
            PlayerId = currentPlayer.PlayerId;
            PlayableCardId = playerCard.Id;
            DefenseValue = playerCard.GetPowerValue(Power.SHIELD_ID);
        }
    }
}
