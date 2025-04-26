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

        public CardDamageEvent(Match match, MatchPlayerData currentPlayer, MatchPlayerData defendingPlayer, int value, bool attackPlayer, int index)
        {
            PlayableCard playerCard = currentPlayer.BattleField.ElementAt(index);

            Value = value;
            PlayerId = currentPlayer.PlayerId;
            CardId = playerCard.Id;
            BattlefieldIndex = index;
            int damage = value - playerCard.Health;
            playerCard.Health -= value;
            Events = new List<MatchEvent>();
            if(playerCard.Health <= 0)
            {
                Events.Add(new CardDeathEvent(match, currentPlayer, playerCard, index));
                if (attackPlayer)
                {
                    Events.Add(new PlayerDamageEvent(match, currentPlayer, defendingPlayer, damage));
                }
            }
        }
    }
}
