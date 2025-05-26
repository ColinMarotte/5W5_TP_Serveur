using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class GainPoisonEffectEvent : MatchEvent
    {
        public override string EventType { get { return "Gain poison"; } }
        public int PlayerId { get; set; }
        public int PlayableCardId { get; set; }
        public int PoisonValue { get; set; }
        public int BattlefieldIndex { get; set; }

        public GainPoisonEffectEvent(Match match, MatchPlayerData attackerData, MatchPlayerData defenderData, int index, int value)
        {
            PlayerId = attackerData.PlayerId;
            BattlefieldIndex = index;
            PoisonValue = value;
            Events = new List<MatchEvent>();

            if (index < defenderData.BattleField.Count)
            {
                PlayableCard target = defenderData.BattleField[index];
                PlayableCardId = target.Id;
                Events.Add(new PoisonDamageEvent(match, defenderData, index, value));
            }
        }
    }
}
