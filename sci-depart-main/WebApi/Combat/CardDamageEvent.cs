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
            Events = new List<MatchEvent>();

            PlayableCard playerCard = currentPlayer.BattleField.ElementAt(index);
            if (playerCard.HasPower(Power.SHIELD_ID))
            {
                Events.Add(new ShieldEvent(match, defendingPlayer, index));
                int defense = playerCard.GetPowerValue(Power.SHIELD_ID);
                Value = value - defense;
            }
            
            if(value < 0)
            {
                Value = 0;
            }

            PlayerId = currentPlayer.PlayerId;
            CardId = playerCard.Id;
            BattlefieldIndex = index;
            int damage = Value - playerCard.Health;

            playerCard.Health -= Value;

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
