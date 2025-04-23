using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class CardDamageEvent : MatchEvent
    {
        public override string EventType { get { return "CardDamage"; } }
        public int PlayerId { get; set; }
        public int CardId { get; set; }
        public int BattlefieldIndex { get; set; }
        public int Value { get; set; }

        public CardDamageEvent(Match match, MatchPlayerData currentPlayer, MatchPlayerData defendingPlayer, PlayableCard playerCard, int value, bool isCurrentPlayer)
        {
            Value = value;
            PlayerId = defendingPlayer.PlayerId;
            CardId = playerCard.Id;
            BattlefieldIndex = playerCard.Index;
            int damage = value - playerCard.Health;
            playerCard.Health -= value;
            bool isCurrentPlayerTurn = match.IsPlayerATurn;
                Events = new List<MatchEvent>();
            if(playerCard.Health <= 0)
            {
                Events.Add(new CardDeathEvent(match, defendingPlayer, playerCard));
            if (!isCurrentPlayer)
            {
                Events.Add(new PlayerDamageEvent(match, currentPlayer, defendingPlayer, damage));
            }
            }
        }
    }
}
