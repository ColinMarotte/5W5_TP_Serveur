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

        public async Task<Deck> CreateDeck(string name, string playerId, List<OwnedCard> cards)
        {
            Deck newDeck = new Deck()
            {
                Id = 0,
                Name = name,
                Current = false,
                PlayerId = int.Parse(playerId),
                Player = _playersService.GetPlayerFromPlayerId(playerId)
            };

            foreach(OwnedCard oc in cards)
            {
                DeckOwnedCard newDeckOwnedCard = new DeckOwnedCard()
                {
                    Id = 0,
                    DeckId = newDeck.Id,
                    Deck = newDeck,
                    OwnedCardId = oc.Id,
                    OwnedCard = oc
                };

                newDeck.DeckOwnedCards.Add(newDeckOwnedCard);
                oc.DeckOwnedCards.Add(newDeckOwnedCard);
            }

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
                Name = "Depart",
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

        public async Task<Deck> AddCardsToDeck(int deckId, List<OwnedCard> cards, int playerId)
        {
            Deck deck = GetDeckFromDeckId(deckId);

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
            // À TESTER (en checkant la BD) (est-ce que la deckOwnedCard s'est correctement ajoutée?)
            await _dbContext.SaveChangesAsync();
            return deck;
        }

        public async Task<Deck> RemoveCardFromDeck(int deckId, DeckOwnedCard card, int playerId)
        {
            Deck deck = GetDeckFromDeckId(deckId);

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

        public async void DeleteDeck(int deckId, int playerId)
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

            // À TESTER (en checkant la BD)
            // À AMELIORER (Non fonctionnel pour l'instant)
            _dbContext.DeckOwnedCards.Remove(deckOwnedCards[0]);
            _dbContext.Decks.Remove(deck);
            await _dbContext.SaveChangesAsync();
        }

        public Deck GetCurrentDeck(string playerId)
        {
            Player player = _playersService.GetPlayerFromPlayerId(playerId);

            Deck currentDeck = player.Decks.Where(d => d.Current = true).First();
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
    }
}
