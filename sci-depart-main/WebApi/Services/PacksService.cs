using Microsoft.EntityFrameworkCore;
using Models.Models;
using Models.Models.Enums;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApi.Services
{
    public class PacksService
    {
        private ApplicationDbContext _dbContext;
        private PlayersService _playersService;

        public PacksService(ApplicationDbContext context, PlayersService playersService)
        {
            _dbContext = context;
            _playersService = playersService;
        }

        public async Task<List<Card>> AcheterPaquet(int paquetIndex, string userId)
        {
            List<Rarity> rarities;

            switch (paquetIndex)
            {
                case 0:
                    var basicProbabilities = new List<Probability>() { new Probability() { Rarity = Rarity.Common, Value = 30, BaseQty = 0 } };
                    rarities = GenerateRarities(3, Rarity.Common, basicProbabilities);
                    break;
                case 1:
                    List<Probability> normalProbabilities = new List<Probability>()
                    {
                        new Probability(){ Rarity = Rarity.Rare, Value = 30, BaseQty = 1},
                        new Probability(){ Rarity = Rarity.Epic, Value = 10, BaseQty = 0},
                        new Probability(){ Rarity = Rarity.Legendary, Value = 2, BaseQty = 0}
                    };
                    rarities = GenerateRarities(4, Rarity.Common, normalProbabilities);
                    break;
                case 2:
                    List<Probability> superProbabilities = new List<Probability>()
                    {
                        new Probability(){ Rarity = Rarity.Epic, Value = 25, BaseQty = 11},
                        new Probability(){ Rarity = Rarity.Legendary, Value = 10, BaseQty = 0}
                    };
                    rarities = GenerateRarities(5, Rarity.Rare, superProbabilities);
                    break;
                default:
                    throw new Exception("L'index du paquet n'est pas valide");
            }

            List<Card> newCards = new List<Card>();

            Random rand = new Random();
            foreach (Rarity rarity in rarities)
            {
                
                int skipper = rand.Next(0, await _dbContext.Cards.Where(c=>c.Rarity == rarity).CountAsync());

                newCards.Add(_dbContext.Cards.Skip(skipper).First());
            }

            List<OwnedCard> newOwnedCards = new List<OwnedCard>();
            foreach(Card card in newCards)
            {
                newOwnedCards.Add(new OwnedCard() { Card = card, Id = 0});
            }

            var player = await _dbContext.Players.FindAsync(userId);
            foreach (OwnedCard ownedCard in newOwnedCards)
            {
                player.OwnedCards.Add(ownedCard);
            }
            await _dbContext.SaveChangesAsync();

            return newCards;
        }

        private List<Rarity> GenerateRarities(int nbCards, Rarity defaultRarity, List<Probability> probabilities)
        {
            List<Rarity>  rarities = new List<Rarity>();

            foreach(Probability probability in probabilities)
            {
                for (int i = 0; i < probability.BaseQty; i++)
                {
                    rarities.Add(probability.Rarity);
                }
            }

            while(rarities.Count < nbCards)
            {
                Rarity? rarity = GetRandomRarity(probabilities);

                if(rarity != null)
                {
                    rarities.Add((Rarity)rarity);                    
                }
                else
                {
                    rarities.Add(defaultRarity);
                }
            }

            return rarities;
        }

        private Rarity? GetRandomRarity(List<Probability> probabilities)
        {
            Random random = new Random();
            int X = random.Next(0, 1);

            foreach (Probability probability in probabilities)
            {
                if (probability.Value < X)
                {
                    return probability.Rarity;
                }
                else X -= probability.Value;
            }

            return null; 
        }
    }
}
