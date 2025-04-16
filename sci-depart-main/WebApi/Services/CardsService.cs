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

            var playerCards = _dbContext.OwnedCards
                .Where(oc => oc.Player.Id == player.Id)
                .Select(oc => oc.Card)
                .Distinct()
                .Include(c => c.CardPowers)
                    .ThenInclude(cp => cp.Power)
                .ToList();

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
				return null;

			var card = await _dbContext.Cards
				.Include(c => c.CardPowers)
					.ThenInclude(cp => cp.Power)
				.FirstOrDefaultAsync(c => c.Id == id.Value);

			if (card == null)
				return null;

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
        public async Task<bool> GetPowersById(int cardId)
        {
            var powers = await _dbContext.CardPowers
                                        .Where(cp => cp.CardId == cardId)
                                        .Select(cp => cp.Power)
                                        .AnyAsync();

            return powers;
        }
        
		public async Task AddCardPower(CardPower cardPower)
		{
			_dbContext.CardPowers.Add(cardPower);
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteCardPower(CardPower cardPower)
		{
			_dbContext.CardPowers.Remove(cardPower);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<bool> CardHasPower(int cardId, int powerId)
		{
			return await _dbContext.CardPowers
				.AnyAsync(cp => cp.CardId == cardId && cp.PowerId == powerId);
		}

	}
}

