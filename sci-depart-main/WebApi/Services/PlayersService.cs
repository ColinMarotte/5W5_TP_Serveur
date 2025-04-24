using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Services
{
	public class PlayersService
    {
        private ApplicationDbContext _dbContext;
        private StartingCardsService _startingCardsService;

        public PlayersService(ApplicationDbContext context, StartingCardsService startingCardsService)
        {
            _dbContext = context;
            _startingCardsService = startingCardsService;
        }

        public async Task<Player> CreatePlayer(IdentityUser user)
        {
            Player p = new Player()
            {
                Id = 0,
                UserId = user.Id,
                Name = user.Email!,
                User = user
            };

            List<StartingCard> startingCards = await _startingCardsService.GetStartingCards();

            foreach(StartingCard c in startingCards)
            {
                OwnedCard newOwnedCard = new OwnedCard()
                {
                    Id = 0,
                    Card = c.Card,
                    Player = p
                };

                p.OwnedCards.Add(newOwnedCard);
                c.Card.OwnedCards.Add(newOwnedCard);
            }

            _dbContext.Add(p);
            _dbContext.SaveChanges();

            return p;
        }

        public virtual Player GetPlayerFromUserId(string userId)
        {
            return _dbContext.Players.Single(p => p.UserId == userId);
        }

        public virtual Player GetPlayerFromPlayerId(string playerId)
        {
            return _dbContext.Players.Single(p => p.Id.ToString() == playerId);
        }

        public Player GetPlayerFromUserName(string userName)
        {
            return _dbContext.Players.Single(p => p.User!.UserName == userName);
        }

        public int GetBalanceFromUserId(string userId)
        {
            return GetPlayerFromUserId(userId).Balance;
        }

        public int GetBalanceFromPlayerId(string playerId)
        {
            return GetPlayerFromPlayerId(playerId).Balance;
        }
    }
}

