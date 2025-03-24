using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Services
{
	public class MatchConfigurationService
    {
        private ApplicationDbContext _dbContext;

        public MatchConfigurationService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public int GetNbCardsToDraw() {
            // L'implémentation est la responsabilité de la personne en charge de la partie [Administration MVC]
            GameConfig gameConfig = _dbContext.GameConfigs.First();
            return gameConfig.NbCardsToDraw;
        }

        public int GetNbManaPerTurn()
        {
            // L'implémentation est la responsabilité de la personne en charge de la partie [Administration MVC]
            GameConfig gameConfig = _dbContext.GameConfigs.First();
            return gameConfig.QtyManaPerTurn;
        }
    }
}

