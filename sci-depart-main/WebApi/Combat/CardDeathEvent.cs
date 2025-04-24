using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class CardDeathEvent:MatchEvent
    {
        public override string EventType { get { return "CardDeath"; } }
        public int PlayerId { get; set; }
        public int CardId { get; set; }
        public int BattlefieldIndex { get; set; }

        public CardDeathEvent(Match match, MatchPlayerData player, PlayableCard playerCard, int index)
        {
            PlayerId = player.PlayerId;
            CardId = playerCard.Id;
            BattlefieldIndex = index;
            player.RemoveCardFromBattleField(playerCard);

        }
    }
}
