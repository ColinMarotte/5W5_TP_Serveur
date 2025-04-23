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

        public CardDamageEvent(Match match, MatchPlayerData attackingPlayer, MatchPlayerData defendingPlayer, PlayableCard playerCard, int value)
        {
            Value = value;
            PlayerId = attackingPlayer.PlayerId;
            CardId = playerCard.Id;
            BattlefieldIndex = playerCard.Index;
            int damage = value - playerCard.Health;
            playerCard.Health -= value;
            if(playerCard.Health <= 0)
            {
                Events = new List<MatchEvent>();
                Events.Add(new CardDeathEvent(match, defendingPlayer, playerCard));
                Events.Add(new PlayerDamageEvent(match, defendingPlayer, attackingPlayer, damage));
            }
        }
    }
}
