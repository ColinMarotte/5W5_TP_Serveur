using Models.Interfaces;

namespace Super_Cartes_Infinies.Models
{
	public class MatchPlayerData : IModel
    {
		const int STARTING_HEALTH = 20;

        public MatchPlayerData()
        {
        }

        // Utilisé par les tests
        public MatchPlayerData(int playerId)
		{
            PlayerId = playerId;
            Health = STARTING_HEALTH;
            CardsPile = new List<PlayableCard>();
            Hand = new List<PlayableCard>();
            BattleField = new List<PlayableCard>();
            Graveyard = new List<PlayableCard>();
        }

        public MatchPlayerData(Player p) : this(p.Id)
        {
            Deck playersCurrentDeck = p.Decks.Where(d => d.Current == true).First();
            List<Card> deckCardsList = playersCurrentDeck.DeckOwnedCards.Select(d => d.OwnedCard.Card).ToList();
        
            //Pour rendre l'ordre des cartes aléatoire
            var rand = new Random();

            CardsPile = deckCardsList.OrderBy(_ => rand.Next()).ToList();
        }

        public int Id { get; set; }
		public int Health { get; set; }
        public int Mana { get; set; }

        public virtual Player Player { get; set; }
        public int PlayerId { get; set; }

        // TODO: Il faut ordonner correctement toutes ces listes/stacks qui pourraient avoir un ordre différent quand on les obtient de la BD (mettre des indexes partout...)
        public virtual List<PlayableCard> CardsPile { get; set; }
        public virtual List<PlayableCard> Hand { get; set; }

        public virtual List<PlayableCard> BattleField { get; set; }
        public virtual List<PlayableCard> Graveyard { get; set; }

        // Assurez-vous d'utiliser cette méthode pour votre logique de combat!
        public List<PlayableCard> GetOrderedBattleField()
        {
            // Retourner les cartes dans l'ordre de l'Index
            return BattleField.OrderBy(p => p.Index).ToList();
        }

        public void AddCardToBattleField(PlayableCard playableCard)
        {
            // Ajouter la carte au BattleField et lui donner le bon index (En fonction du nombre de cartes déjà sur le BattleField)
            playableCard.Index = BattleField.Count;
            BattleField.Add(playableCard);
            BattleField = GetOrderedBattleField();
        }

        public void RemoveCardFromBattleField(PlayableCard playableCard)
        {
            // Retirer la carte du BattleField
            // Atention: Il faut mettre les autres cartes du BattleField à jour!
            BattleField = GetOrderedBattleField();

            for (int i = playableCard.Index+1; i < BattleField.Count(); i++)
            {
                BattleField.ElementAt(i).Index = i-1;
            }
            BattleField.RemoveAt(playableCard.Index);
            playableCard.Index = -1;
            Graveyard.Add(playableCard);
            BattleField = GetOrderedBattleField();

        }
    }
}

