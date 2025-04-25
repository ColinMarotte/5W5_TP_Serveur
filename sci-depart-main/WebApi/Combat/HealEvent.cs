using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class HealEvent : MatchEvent
    {
        public override string EventType { get { return "Heal"; } }
        public int PlayerId { get; set; }
        public int PlayableCardId { get; set; }
        public int Value { get; set; }
        public HealEvent(MatchPlayerData playerData, PlayableCard playableCard,int index)
        {
            PlayableCardId = playableCard.Card.Id;
            PlayerId = playerData.PlayerId;
            Value = playableCard.GetPowerValue(Power.HEAL_ID);
            Events = new List<MatchEvent>();
            for (int i = 0; i < playerData.BattleField.Count; i++)
            {
                PlayableCard card = playerData.BattleField[i];
                if(card.Health < card.Card.Health) { 
                    var healValue = Math.Min(Value, card.Card.Health- card.Health);
                    Events.Add(new CardHealEvent(playerData, healValue, i));
                }
                

            }
        }
    }
}
