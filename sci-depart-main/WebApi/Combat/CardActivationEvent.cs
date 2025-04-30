using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class CardActivationEvent:MatchEvent
    {
        public override string EventType { get { return "CardActivation"; } }
        public int PlayerId { get; set; }
        public int PlayableCardId { get; set; }
        public int BattlefieldIndex { get; set; }

        public CardActivationEvent(Match match, MatchPlayerData attackingPlayer, MatchPlayerData defendingPlayer, int index)
        {
            PlayerId = attackingPlayer.PlayerId;
            BattlefieldIndex = index;
            attackingPlayer.BattleField = attackingPlayer.GetOrderedBattleField();
            defendingPlayer.BattleField = defendingPlayer.GetOrderedBattleField();
            PlayableCard playerCard = attackingPlayer.BattleField.ElementAt(index);
            PlayableCardId = playerCard.Id;
            PlayableCard? oppositePlayerCard = null;

            if (index < defendingPlayer.BattleField.Count())
            {
                oppositePlayerCard = defendingPlayer.BattleField.ElementAt(index);
            }

            Events = new List<MatchEvent>();
            if (playerCard.HasPower(Power.HEAL_ID))
            {
                Events.Add(new HealEvent(attackingPlayer, playerCard, index));
            }
            if (oppositePlayerCard != null && oppositePlayerCard.HasPower(Power.THORNS_ID))
            {
                int thornsDamage = oppositePlayerCard.GetPowerValue(Power.THORNS_ID);
                if(thornsDamage >= playerCard.Health)
                {
                    Events.Add(new ThornsEvent(match, attackingPlayer, defendingPlayer, index, thornsDamage));
                }
                else
                {
                    Events.Add(new ThornsEvent(match, attackingPlayer, defendingPlayer, index, thornsDamage));
                    Events.Add(new AttackEvent(match, attackingPlayer, defendingPlayer, index));
                }
            }
            else
            {
                Events.Add(new AttackEvent(match, attackingPlayer, defendingPlayer, index));
            }
        }
    }
}
