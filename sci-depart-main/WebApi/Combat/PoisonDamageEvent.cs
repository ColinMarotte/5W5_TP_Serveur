using Models.Models;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class PoisonDamageEvent : MatchEvent
    {
        public override string EventType { get { return "Poison damage"; } }
        public int PlayerId { get; set; }
        public int PlayableCardId { get; set; }
        public int Damage { get; set; }
        public int BattlefieldIndex { get; set; }

        public PoisonDamageEvent(Match match, MatchPlayerData playerData, int index, int damage)
        {
            PlayerId = playerData.PlayerId;
            BattlefieldIndex = index;
            Events = new List<MatchEvent>();

            if (index < playerData.BattleField.Count)
            {
                PlayableCard card = playerData.BattleField[index];
                PlayableCardId = card.Id;
                
                if (damage > 0)
                {
                    if (card.Health <= 0)
                    {
                        Events.Add(new CardDeathEvent(match, playerData, card, index));
                    }
                }
            }
        }
    }
}
