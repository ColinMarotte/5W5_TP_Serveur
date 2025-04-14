using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Card> GetPlayersCards(string playerId)
        {
            Player player = _playersService.GetPlayerFromPlayerId(playerId);

            List<Card> playerCards = player.OwnedCards.Select(c => c.Card).ToList();

            return playerCards;
        }

        public async Task<IEnumerable<Card>> GetAllCards()
        {
            return await _dbContext.Cards.Include(c => c.CardPowers)
                                            .ThenInclude(cp => cp.Power)
                                            .ToListAsync();
        }

        public async Task<Card> GetCard(int? id)
        {
            if (id == null)
            {
                throw new ArgumentException();
            }
            Card? card = await _dbContext.Cards.FindAsync(id);
            if (card == null)
            {
                throw new Exception();
            }
            return card;
        }

        public async Task<Card?> CreateCard(Card card)
        {
            if (card == null)
            {
                throw new ArgumentNullException();
            }
            try
            {
                await _dbContext.Cards.AddAsync(card);
                await _dbContext.SaveChangesAsync();
                return card;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Card?> EditCard(int id, Card card)
        {
            if (card == null)
            {
                throw new ArgumentNullException();

            }
            _dbContext.ChangeTracker.Clear();
            _dbContext.Entry(card).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if ((await GetCard(id)) == null) return null;
                else throw;
            }

            return card;
        }

        public async Task<Card?> DeleteCard(Card card)
        {
            if (card == null) return null;

            _dbContext.Remove(card);
            await _dbContext.SaveChangesAsync();
            return card;
        }

        public async Task<List<Power>> GetAllPowers()
        {
            return await _dbContext.Powers.ToListAsync();
        }

        public async Task UpdateCardPowers(int cardId, List<CardPower> newPowers)
        {
            var oldPowers = _dbContext.CardPowers.Where(cp => cp.CardId == cardId);
            _dbContext.CardPowers.RemoveRange(oldPowers);

            foreach (var power in newPowers)
            {
                power.CardId = cardId;
                _dbContext.CardPowers.Add(power);
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}

