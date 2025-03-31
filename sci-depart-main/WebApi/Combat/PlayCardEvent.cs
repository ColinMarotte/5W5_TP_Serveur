using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;

namespace WebApi.Combat
{
    public class PlayCardEvent : MatchEvent
    {
        public override string EventType { get { return "PlayCard"; } }
        public int PlayerId { get; set; }
        public int PlayableCardId { get; set; }

        public PlayCardEvent(MatchPlayerData currentPlayerData, int playableCardId)
        {
            PlayableCard playableCard = currentPlayerData.Hand.Find(c => c.Id == playableCardId);
            PlayerId = currentPlayerData.PlayerId;
            PlayableCardId = playableCardId;
            Events = new List<MatchEvent>();


            if (playableCard == null)
            {
                throw new Exception();
            }
            if(currentPlayerData.Mana < playableCard.Card.Cost)
            {
                throw new Exception();
            }
            currentPlayerData.BattleField.Add(playableCard);
            currentPlayerData.Hand.Remove(playableCard);
            this.Events.Add(new GainManaEvent(currentPlayerData, -playableCard.Card.Cost));
        }
    }
}
