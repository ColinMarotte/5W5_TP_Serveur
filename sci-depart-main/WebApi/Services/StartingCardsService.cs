using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Services
{
	public class StartingCardsService
    {
        private ApplicationDbContext _dbContext;

        public StartingCardsService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<List<StartingCard>> GetStartingCards() {
            // Stub: Pour l'intant, le stub retourne simplement les 7 premières cartes
            // L'implémentation réelle devra retourner les cartes référées par les starting cards configuré par l'administarteur
            // L'implémentation est la responsabilité de la personne en charge de la partie [Administration MVC]
            return await _dbContext.StartingCards.ToListAsync();
        }

        public async Task<StartingCard> GetStartingCard(int? id)
        {
            if (id == null)
            {
                throw new ArgumentException();
            }
            StartingCard startingCard = await _dbContext.StartingCards.FindAsync(id);
            if (startingCard == null)
            {
                throw new Exception();
            }
            return startingCard;
        }

        public async Task<StartingCard?> DeleteStartingCard(StartingCard startingCard)
        {
            if (startingCard == null) return null;

            _dbContext.Remove(startingCard);
            await _dbContext.SaveChangesAsync();
            return startingCard;
        }
    }
}

