using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Services
{
    public class DecksService
    {
        private ApplicationDbContext _dbContext;
        private PlayersService _playersService;

        public DecksService(ApplicationDbContext context, PlayersService playersService)
        {
            _dbContext = context;
            _playersService = playersService;
        }

        public async Task<Deck> CreateDeck(string name, string playerId)
        {
            Deck newDeck = new Deck()
            {
                Id = 0,
                Name = name,
                Current = false,
                PlayerId = int.Parse(playerId),
                Player = _playersService.GetPlayerFromPlayerId(playerId)
            };

            _dbContext.Add(newDeck);
            await _dbContext.SaveChangesAsync();

            return newDeck;
        }

        public async Task<Deck> CreateStartingDeck(string playerId)
        {
            Player player = _playersService.GetPlayerFromPlayerId(playerId);

            Deck newDeck = new Deck()
            {
                Id = 0,
                Name = "Départ",
                Current = true,
                PlayerId = int.Parse(playerId),
                Player = player
            };

            foreach (OwnedCard ownedCard in player.OwnedCards)
            {
                DeckOwnedCard newDeckOwnedCard = new DeckOwnedCard()
                {
                    Id = 0,
                    DeckId = newDeck.Id,
                    Deck = newDeck,
                    OwnedCardId = ownedCard.Id,
                    OwnedCard = ownedCard
                };

                newDeck.DeckOwnedCards.Add(newDeckOwnedCard);
                ownedCard.DeckOwnedCards.Add(newDeckOwnedCard);
            }

            _dbContext.Add(newDeck);
            await _dbContext.SaveChangesAsync();

            return newDeck;
        }

        public async Task<Deck> AddCardsToDeck(int deckId, List<int> ownedCardsIds, int playerId)
        {
            Deck deck = GetDeckFromDeckId(deckId);
            List<OwnedCard> cards = new List<OwnedCard>();

            foreach (int id in ownedCardsIds)
            {
                OwnedCard card = _dbContext.OwnedCards.Where(o => o.Id == id).First();
                cards.Add(card);
            }

            if (deck.PlayerId != playerId)
            {
                throw new Exception("Ce deck n'appartient pas au joueur connecté!");
            }

            foreach (OwnedCard ownedCard in cards)
            {
                if (ownedCard.Player.Id != playerId)
                {
                    throw new Exception("Au moins une carte n'appartient pas au joueur connecté!");
                }

                DeckOwnedCard newDeckOwnedCard = new DeckOwnedCard()
                {
                    Id = 0,
                    DeckId = deckId,
                    Deck = deck,
                    OwnedCardId = ownedCard.Id,
                    OwnedCard = ownedCard
                };

                deck.DeckOwnedCards.Add(newDeckOwnedCard);
                ownedCard.DeckOwnedCards.Add(newDeckOwnedCard);
            }
            await _dbContext.SaveChangesAsync();
            return deck;
        }

        public async Task<Deck> RemoveCardFromDeck(int deckId, int deckOwnedCardId, int playerId)
        {
            Deck deck = GetDeckFromDeckId(deckId);
            DeckOwnedCard card = _dbContext.DeckOwnedCards.Where(d => d.Id == deckOwnedCardId).First();

            if (deck.PlayerId != playerId)
            {
                throw new Exception("Ce deck n'appartient pas au joueur connecté!");
            }

            deck.DeckOwnedCards.Remove(card);
            card.OwnedCard.DeckOwnedCards.Remove(card);
            _dbContext.DeckOwnedCards.Remove(card);

            await _dbContext.SaveChangesAsync();
            return deck;
        }

        public void DeleteDeck(int deckId, int playerId)
        {
            Deck deck = GetDeckFromDeckId(deckId);

            if (deck.PlayerId != playerId)
            {
                throw new Exception("Ce deck n'appartient pas au joueur connecté!");
            }
            if (deck.Current == true)
            {
                throw new Exception("Le deck courrant ne peut pas être effacé!");
            }

            List<DeckOwnedCard> deckOwnedCards = deck.DeckOwnedCards;
            int nbCartes = deckOwnedCards.Count;

            for (int i = nbCartes - 1; i >= 0; i--)
            {
                DeckOwnedCard deckOwnedCard = deckOwnedCards[i];
                deck.DeckOwnedCards.Remove(deckOwnedCard);
                deckOwnedCard.OwnedCard.DeckOwnedCards.Remove(deckOwnedCard);
                _dbContext.DeckOwnedCards.Remove(deckOwnedCard);
            }
            
            _dbContext.Decks.Remove(deck);
            _dbContext.SaveChanges();
        }

        public async Task<Deck> MakeDeckCurrent(int deckId, string playerId)
        {
            Deck currentDeck = GetCurrentDeck(playerId);
            Deck futureCurrentDeck = GetDeckFromDeckId(deckId);

            Player player = _playersService.GetPlayerFromPlayerId(playerId);

            player.Decks.Where(d => d.Current = true).First().Current = false;
            currentDeck.Current = false;

            player.Decks.Where(d => d.Id == deckId).First().Current = true;
            futureCurrentDeck.Current = true;
            await _dbContext.SaveChangesAsync();

            return futureCurrentDeck;
        }

        public Deck GetCurrentDeck(string playerId)
        {
            Player player = _playersService.GetPlayerFromPlayerId(playerId);
            
            Deck currentDeck = player.Decks.Where(d => d.Current == true).First();
            return currentDeck;
        }

        public List<Deck> GetPlayersDecks(string playerId)
        {
            Player player = _playersService.GetPlayerFromPlayerId(playerId);

            return player.Decks;
        }

        public Deck GetDeckFromDeckId(int deckId)
        {
            Deck deck = _dbContext.Decks.Single(d => d.Id == deckId);
            return deck;
        }

        public List<OwnedCard> GetCardsNotInDeck(int deckId)
        {
            Deck deck = GetDeckFromDeckId(deckId);
            Player player = deck.Player;

            List<OwnedCard> decksOwnedCards = deck.DeckOwnedCards.Select(d => d.OwnedCard).ToList();
            List<OwnedCard> playersOwnedCards = player.OwnedCards;
            List<OwnedCard> cardsNotInDeck = new List<OwnedCard>();

            foreach (OwnedCard pOwnedCard in playersOwnedCards)
            {
                if (!decksOwnedCards.Contains(pOwnedCard))
                {
                    cardsNotInDeck.Add(pOwnedCard);
                }
            }

            return cardsNotInDeck;
        }
    }
}
