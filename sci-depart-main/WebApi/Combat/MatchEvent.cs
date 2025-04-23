using System.Text.Json.Serialization;
using Super_Cartes_Infinies.Combat;

namespace Super_Cartes_Infinies.Combat
{
    [JsonDerivedType(typeof(DrawCardEvent))]
    [JsonDerivedType(typeof(EndMatchEvent))]
    [JsonDerivedType(typeof(GainManaEvent))]
    [JsonDerivedType(typeof(PlayerEndTurnEvent))]
    [JsonDerivedType(typeof(PlayerStartTurnEvent))]
    [JsonDerivedType(typeof(StartMatchEvent))]
    [JsonDerivedType(typeof(SurrenderEvent))]
    [JsonDerivedType(typeof(PlayCardEvent))]
    [JsonDerivedType(typeof(CombatEvent))]
    [JsonDerivedType(typeof(AttackEvent))]
    [JsonDerivedType(typeof(PlayerDamageEvent))]
    [JsonDerivedType(typeof(PlayerDeathEvent))]
    [JsonDerivedType(typeof(HealEvent))]
    [JsonDerivedType(typeof(CardHealEvent))]
    public abstract class MatchEvent
    {
        public abstract string EventType { get; }

        public MatchEvent()
        {
        }

        public List<MatchEvent>? Events { get; set; }
    }
}
