using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class ThornsEvent:MatchEvent
    {
        public override string EventType { get { return "Thorns"; } }
        public int PlayerId { get; set; }
        public int PlayableCardId { get; set; }
        public int Value { get; set; }
        public ThornsEvent(Match match, MatchPlayerData currentPlayer, MatchPlayerData oppositePlayerData, int index, int damage)
        {
            PlayableCard playerCard = currentPlayer.BattleField.ElementAt(index);

            PlayerId = currentPlayer.PlayerId;
            PlayableCardId = playerCard.Id;
            Events = new List<MatchEvent>();
            Events.Add(new CardDamageEvent(match, currentPlayer, oppositePlayerData, damage, false, index));
        }
    }
}
