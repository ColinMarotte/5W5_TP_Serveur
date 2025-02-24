using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Services
{
	public class CardsService
    {
        private ApplicationDbContext _dbContext;
        private PlayersService _playersService;

        public CardsService(ApplicationDbContext dbContext, PlayersService playersService)
        {
            _dbContext = dbContext;
            _playersService = playersService;
        }

        public IEnumerable<Card> GetPlayersCards(string userId)
        {
            Player player = _playersService.GetPlayerFromUserId(userId);

            List<Card> playerCards = player.OwnedCards.Select(c => c.Card).ToList();

            return playerCards;
        }

        public IEnumerable<Card> GetAllCards()
        {
            return _dbContext.Cards;
        }
    }
}

