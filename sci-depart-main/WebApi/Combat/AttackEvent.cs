using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class AttackEvent : MatchEvent
    {
        public override string EventType { get { return "Attack"; } }
        public int PlayerId { get; set; }


        public AttackEvent(Match match, MatchPlayerData attackingPlayer, MatchPlayerData defendingPlayer, int index)
        {
            PlayerId = attackingPlayer.PlayerId;
            PlayableCard playerCard = attackingPlayer.BattleField.ElementAt(index);
            PlayableCard? oppositePlayerCard = null;

            if (index < defendingPlayer.BattleField.Count())
            {
                oppositePlayerCard = defendingPlayer.BattleField.ElementAt(index);
            }
            Events = new List<MatchEvent>();
            if (oppositePlayerCard == null)
            {
                Events.Add(new PlayerDamageEvent(match, defendingPlayer, attackingPlayer, playerCard.Attack));
            }
            else
            {
                if (playerCard.HasPower(Power.FIRST_STRIKE_ID) && playerCard.Attack >= oppositePlayerCard.Health)
                {
                    Events.Add(new FirstStrikeEvent(attackingPlayer, playerCard));


                    Events.Add(new CardDamageEvent(match, defendingPlayer, attackingPlayer, playerCard.Attack, true, index));

                }
                if (oppositePlayerCard.HasPower(Power.SHIELD_ID))
                {
                    Events.Add(new ShieldEvent(match, defendingPlayer, index));
                    int defense = oppositePlayerCard.GetPowerValue(Power.SHIELD_ID);
                    Events.Add(new CardDamageEvent(match, defendingPlayer, attackingPlayer, playerCard.Attack-defense, true, index));
                    Events.Add(new CardDamageEvent(match, attackingPlayer, defendingPlayer, oppositePlayerCard.Attack, false, index));

                }
                else
                {
                    Events.Add(new CardDamageEvent(match, defendingPlayer, attackingPlayer, playerCard.Attack, true, index));
                    Events.Add(new CardDamageEvent(match, attackingPlayer, defendingPlayer, oppositePlayerCard.Attack, false, index));
                }
            }
            
        }
    }
}
