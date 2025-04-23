using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Combat
{
    public class FirstStrikeEvent:MatchEvent
    {
        public override string EventType { get { return "FirstStrike"; } }
        public int PlayerId { get; set; }
        public int PlayableCardId { get; set; }

        public FirstStrikeEvent(MatchPlayerData playerData, PlayableCard playableCard)
        {
            PlayableCardId = playableCard.Id;
            PlayerId = playerData.PlayerId;
        }
    }
}
