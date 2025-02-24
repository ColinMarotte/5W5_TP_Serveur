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

        public Player CreatePlayer(IdentityUser user)
        {
            Player p = new Player()
            {
                Id = 0,
                UserId = user.Id,
                Name = user.Email!,
                User = user
            };

            // TODO: Utilisez le service StartingCardsService pour obtenir les cartes de départ
            List<Card> startingCards = _startingCardsService.GetStartingCards();

            // TODO: Ajoutez ces cartes au joueur en utilisant le modèle OwnedCard que vous allez devoir ajouter
            foreach(Card c in startingCards)
            {
                OwnedCard newOwnedCard = new OwnedCard()
                {
                    Id = 0,
                    Card = c,
                    Player = p
                };

                p.OwnedCards.Add(newOwnedCard);
                c.OwnedCards.Add(newOwnedCard);
            }

            _dbContext.Add(p);
            _dbContext.SaveChanges();

            return p;
        }

        public virtual Player GetPlayerFromUserId(string userId)
        {
            return _dbContext.Players.Single(p => p.UserId == userId);
        }

        public Player GetPlayerFromUserName(string userName)
        {
            return _dbContext.Players.Single(p => p.User!.UserName == userName);
        }
    }
}

