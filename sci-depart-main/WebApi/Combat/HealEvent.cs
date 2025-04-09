using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class HealEvent : MatchEvent
    {
        public override string EventType { get { return "Heal"; } }
        public int PlayerId { get; set; }
        public int PlayableCardId { get; set; }
        public int Value { get; set; }
        public HealEvent(MatchPlayerData playerData, PlayableCard playableCard)
        {
            PlayableCardId = playableCard.Card.Id;
            PlayerId = playerData.PlayerId;
            Value = playableCard.GetPowerValue(Power.HEAL_ID);
            Events = new List<MatchEvent>();
            foreach (PlayableCard card in playerData.BattleField)
            {
                var healValue = 0;
                if(card.Health+Value > card.Card.Health && card.Health != card.Card.Health)
                {
                    healValue = card.Health + Value - card.Card.Health;
                }
                else
                {
                    healValue = Value;
                }

                Events.Add(new CardHealEvent(playerData, playableCard, healValue));
            }
        }
    }
}
