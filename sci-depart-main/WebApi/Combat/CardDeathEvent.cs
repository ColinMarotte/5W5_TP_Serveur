using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class CardDeathEvent:MatchEvent
    {
        public override string EventType { get { return "CardDeath"; } }
        public int PlayerId { get; set; }
        public int CardId { get; set; }
        public int BattlefieldIndex { get; set; }

        public CardDeathEvent(Match match, MatchPlayerData player, PlayableCard playerCard)
        {
            PlayerId = player.PlayerId;
            CardId = playerCard.Id;
            BattlefieldIndex = playerCard.Index;
            //playerCard.Index = -1;
            player.BattleField.Remove(playerCard);
            player.Graveyard.Add(playerCard);
        }
    }
}
