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

        public async Task<List<Card>?> AcheterPaquet(int paquetIndex, string userId)
        {
            List<Rarity> rarities;
            int coutDuPaquet;

            switch (paquetIndex)
            {
                case 0:
                    var basicPackProbabilities = new List<Probability>() { new Probability() { Rarity = Rarity.Common, Value = 30, BaseQty = 0 } };
                    rarities = GenerateRarities(3, Rarity.Common, basicPackProbabilities);
                    coutDuPaquet = 40;
                    break;
                case 1:
                    List<Probability> normalPackProbabilities = new List<Probability>()
                    {
                        new Probability(){ Rarity = Rarity.Rare, Value = 30, BaseQty = 1},
                        new Probability(){ Rarity = Rarity.Epic, Value = 10, BaseQty = 0},
                        new Probability(){ Rarity = Rarity.Legendary, Value = 2, BaseQty = 0}
                    };
                    rarities = GenerateRarities(4, Rarity.Common, normalPackProbabilities);
                    coutDuPaquet = 75;
                    break;
                case 2:
                    List<Probability> superPackProbabilities = new List<Probability>()
                    {
                        new Probability(){ Rarity = Rarity.Epic, Value = 25, BaseQty = 1},
                        new Probability(){ Rarity = Rarity.Legendary, Value = 10, BaseQty = 0}
                    };
                    rarities = GenerateRarities(5, Rarity.Rare, superPackProbabilities);
                    coutDuPaquet = 100;
                    break;
                default:
                    throw new Exception("L'index du paquet n'est pas valide");
            }

            var player = await _dbContext.Players.Where(p=>p.UserId == userId).FirstAsync();
            if(player.Balance < coutDuPaquet)
            {
                return null;
            }

            player.Balance -= coutDuPaquet;

            List<Card> newCards = new List<Card>();

            Random rand = new Random();
            foreach (Rarity rarity in rarities)
            {
                
                int skipper = rand.Next(0, await _dbContext.Cards.Where(c=>c.Rarity == rarity).CountAsync());

                newCards.Add(_dbContext.Cards.Where(c => c.Rarity == rarity).Skip(skipper).First());
            }

            List<OwnedCard> newOwnedCards = new List<OwnedCard>();
            foreach(Card card in newCards)
            {
                newOwnedCards.Add(new OwnedCard() { Card = card, Id = 0});
            }

            
            foreach (OwnedCard ownedCard in newOwnedCards)
            {
                player.OwnedCards.Add(ownedCard);
            }
            
            await _dbContext.SaveChangesAsync();

            return newCards;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nbCards">Nombre de cartes à générer</param>
        /// <param name="defaultRarity">Rareté minimum</param>
        /// <param name="probabilities">Probabilités de piger chaque probabilité</param>
        /// <returns></returns>
        private List<Rarity> GenerateRarities(int nbCards, Rarity defaultRarity, List<Probability> probabilities)
        {
            List<Rarity> rarities = new List<Rarity>();

            // Ajouter les raretés garanties, s'il y en a
            foreach(Probability probability in probabilities)
            {
                for (int i = 0; i < probability.BaseQty; i++)
                {
                    rarities.Add(probability.Rarity);
                }
            }

            // Ajouter des raretés randoms
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
            int valeurPigée = random.Next(0, 100);

            foreach (Probability probability in probabilities)
            {
                if (probability.Value > valeurPigée)
                {
                    return probability.Rarity;
                }
                else valeurPigée -= probability.Value;
            }

            return null; 
        }
    }
}
