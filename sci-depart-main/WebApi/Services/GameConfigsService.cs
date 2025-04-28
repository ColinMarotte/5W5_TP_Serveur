using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Services
{
    public class GameConfigsService
    {
        private ApplicationDbContext _dbContext;

        public GameConfigsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<GameConfig>> GetGameConfigs()
        {
            return await _dbContext.GameConfigs.ToListAsync();
        }

        public async Task<GameConfig> GetGameConfig(int? id)
        {
            if (id == null)
            {
                throw new ArgumentException();
            }
            GameConfig? gameConfig = await _dbContext.GameConfigs.FindAsync(id);
            if (gameConfig == null)
            {
                throw new Exception();
            }
            return gameConfig;
        }

        public async Task<GameConfig?> CreateGameConfig(GameConfig gameConfig)
        {
            if (gameConfig == null)
            {
                throw new ArgumentNullException();
            }
            try
            {
                await _dbContext.GameConfigs.AddAsync(gameConfig);
                await _dbContext.SaveChangesAsync();
                return gameConfig;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<GameConfig?> EditGameConfig(int id, GameConfig gameConfig)
        {
            if (gameConfig == null)
            {
                throw new ArgumentNullException();

            }
            _dbContext.ChangeTracker.Clear();
            _dbContext.Entry(gameConfig).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if ((await GetGameConfig(id)) == null) return null;
                else throw;
            }

            return gameConfig;
        }

        public async Task<GameConfig?> DeleteGameConfig(GameConfig gameConfig)
        {
            if (gameConfig == null) return null;

            if (_dbContext.GameConfigs.Count() == 1) return null;
            _dbContext.Remove(gameConfig);
            await _dbContext.SaveChangesAsync();
            return gameConfig;
        }
    }
}
