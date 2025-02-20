using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Services
{
	public class CardsService
    {
        private ApplicationDbContext _dbContext;

        public CardsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Card> GetPlayersCards(string userId)
        {
            // Stub: Pour l'intant, le stub retourne simplement les 8 premières cartes
            // L'implémentation réelle devra utiliser un service et retourner les cartes qu'un joueur possède
            // L'implémentation est la responsabilité de la personne en charge de la partie [Enregistrement et connexion]
            return _dbContext.Cards.Take(8).ToList();
        }

        public async Task<IEnumerable<Card>> GetAllCards()
        {
            return await _dbContext.Cards.ToListAsync();
        }

        public async Task<Card> GetCard(int? id)
        {
            if(id == null)
            {
                throw new ArgumentException();
            }
            Card card = await _dbContext.Cards.FindAsync(id);
            if(card == null)
            {
                throw new Exception();
            }
            return card;
        }
    }
}

