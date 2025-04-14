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
    }
}
