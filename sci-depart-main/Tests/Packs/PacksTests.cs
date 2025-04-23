using Microsoft.EntityFrameworkCore;
using Models.Models.Enums;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Services;

namespace Tests.Packs
{
    [TestClass]
    public class PacksTests
    {
        public const string USERID = "ABCDEFG";

        private DbContextOptions<ApplicationDbContext> _options;
        public PacksTests()
        {
            // TODO On initialise les options de la BD, on utilise une InMemoryDatabase
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                // TODO il faut installer la dépendance Microsoft.EntityFrameworkCore.InMemory
                .UseInMemoryDatabase(databaseName: "SuperCartesInfinies")
                .UseLazyLoadingProxies(true) // Active le lazy loading
                .Options;
        }

        [TestInitialize]
        public void Init()
        {
            // TODO avoir la durée de vie d'un context la plus petite possible
            using ApplicationDbContext db = new ApplicationDbContext(_options);
            // TODO on ajoute des données de tests
            Card[] cards = new Card[] {
                new Card
                {
                    Id = 1,
                    Name = "Chat Dragon",
                    Attack = 3,
                    Health = 3,
                    Cost = 3,
                    ImageUrl = "https://i.pinimg.com/originals/a8/16/49/a81649bd4b0f032ce633161c5a076b87.jpg",
                    Rarity = Rarity.Rare,
                    Price = RarityInfo.GetPrice(Rarity.Rare)
                }, new Card
                {
                    Id = 2,
                    Name = "Chat Awesome",
                    Attack = 2,
                    Health = 5,
                    Cost = 3,
                    ImageUrl = "https://i0.wp.com/thediscerningcat.com/wp-content/uploads/2021/02/tabby-cat-wearing-sunglasses.jpg",
                    Rarity = Rarity.Common,
                    Price = RarityInfo.GetPrice(Rarity.Common)

                }, new Card
                {
                    Id = 3,
                    Name = "Chatton Laser",
                    Attack = 2,
                    Health = 1,
                    Cost = 1,
                    ImageUrl = "https://cdn.wallpapersafari.com/27/53/SZ8PO9.jpg",
                    Rarity = Rarity.Legendary,
                    Price = RarityInfo.GetPrice(Rarity.Legendary)

                }, new Card
                {
                    Id = 4,
                    Name = "Chat Spacial",
                    Attack = 8,
                    Health = 4,
                    Cost = 4,
                    ImageUrl = "https://wallpapers.com/images/hd/epic-cat-poster-baavft05ylgta4j8.jpg",
                    Rarity = Rarity.Legendary,
                    Price = RarityInfo.GetPrice(Rarity.Legendary)
                }, new Card
                {
                    Id = 5,
                    Name = "Chat Guerrier",
                    Attack = 7,
                    Health = 7,
                    Cost = 5,
                    ImageUrl = "https://i.etsystatic.com/6230905/r/il/32aa5a/3474618751/il_fullxfull.3474618751_mfvf.jpg",
                    Rarity = Rarity.Epic,
                    Price = RarityInfo.GetPrice(Rarity.Epic)
                }, new Card
                {
                    Id = 6,
                    Name = "Chat Laser",
                    Attack = 4,
                    Health = 2,
                    Cost = 2,
                    ImageUrl = "https://store.playstation.com/store/api/chihiro/00_09_000/container/AU/en/99/EP2402-CUSA05624_00-ETH0000000002875/0/image?_version=00_09_000&platform=chihiro&bg_color=000000&opacity=100&w=720&h=720",
                    Rarity = Rarity.Rare,
                    Price = RarityInfo.GetPrice(Rarity.Rare)
                }, new Card
                {
                    Id = 7,
                    Name = "Jedi Chat",
                    Attack = 6,
                    Health = 3,
                    Cost = 4,
                    ImageUrl = "https://images.squarespace-cdn.com/content/51b3dc8ee4b051b96ceb10de/1394662654865-JKOZ7ZFF39247VYDTGG9/hilarious-jedi-cats-fight-video-preview.jpg?content-type=image%2Fjpeg",
                    Rarity = Rarity.Epic,
                    Price = RarityInfo.GetPrice(Rarity.Epic)
                }, new Card
                {
                    Id = 8,
                    Name = "Blob Chat",
                    Attack = 1,
                    Health = 9,
                    Cost = 2,
                    ImageUrl = "https://i.pinimg.com/736x/48/ba/94/48ba9440c4f87e42af99774ec51f53a1.jpg",
                    Rarity = Rarity.Common,
                    Price = RarityInfo.GetPrice(Rarity.Common)
                }, new Card
                {
                    Id = 9,
                    Name = "Jedi Chatton",
                    Attack = 5,
                    Health = 1,
                    Cost = 2,
                    ImageUrl = "https://townsquare.media/site/142/files/2011/08/jedicats.jpg?w=980&q=75",
                    Rarity = Rarity.Rare,
                    Price = RarityInfo.GetPrice(Rarity.Rare)
                }, new Card
                {
                    Id = 10,
                    Name = "Chat Furtif",
                    Attack = 6,
                    Health = 1,
                    Cost = 2,
                    ImageUrl = "https://cdn.theatlantic.com/thumbor/fOZjgqHH0RmXA1A5ek-yDz697W4=/133x0:2091x1020/1200x625/media/img/mt/2015/12/RTRD62Q/original.jpg",
                    Rarity = Rarity.Common,
                    Price = RarityInfo.GetPrice(Rarity.Common)
                }, new Card
                {
                    Id = 11,
                    Name = "Grosse Minoune",
                    Attack = 6,
                    Health = 6,
                    Cost = 4,
                    ImageUrl = "https://i.imgur.com/07zax4t.jpeg",
                    Rarity = Rarity.Common,
                    Price = RarityInfo.GetPrice(Rarity.Common)
                }, new Card
                {
                    Id = 12,
                    Name = "Petite Minoune",
                    Attack = 2,
                    Health = 4,
                    Cost = 2,
                    ImageUrl = "https://i.imgur.com/QuDe5RH.jpeg",
                    Rarity = Rarity.Common,
                    Price = RarityInfo.GetPrice(Rarity.Common)
                }
            };

            db.AddRange(cards);
            db.Players.Add(new Player() { UserId = USERID,Balance=1000});
            db.SaveChanges();

        }
        [TestCleanup]
        public void Dispose()
        {
            //TODO on efface les données de tests pour remettre la BD dans son état initial
            using ApplicationDbContext db = new ApplicationDbContext(_options);
            db.Cards.RemoveRange(db.Cards);
            db.Players.RemoveRange(db.Players.Where(p => p.UserId == USERID));
            db.SaveChanges();
        }

        #region Bon nombre de cartes tests 
        [TestMethod]
        public async Task BonNombreDeCartesPackBasic()
        {
            using ApplicationDbContext db = new ApplicationDbContext(_options);

            PacksService packsService = new PacksService(db, new Super_Cartes_Infinies.Services.PlayersService(db, new Super_Cartes_Infinies.Services.StartingCardsService(db)));

            List<Card>? cards = await packsService.AcheterPaquet(0, USERID);
            Assert.AreEqual(3, cards!.Count);

            Player player = await db.Players.Where(p => p.UserId == USERID).FirstAsync();
            Assert.AreEqual(3, player.OwnedCards.Count);
        }

        [TestMethod]
        public async Task BonNombreDeCartesPackNormal()
        {
            using ApplicationDbContext db = new ApplicationDbContext(_options);

            PacksService packsService = new PacksService(db, new Super_Cartes_Infinies.Services.PlayersService(db, new Super_Cartes_Infinies.Services.StartingCardsService(db)));

            List<Card>? cards = await packsService.AcheterPaquet(1, USERID);
            Assert.AreEqual(4, cards!.Count);

            Player player = await db.Players.Where(p => p.UserId == USERID).FirstAsync();
            Assert.AreEqual(4, player.OwnedCards.Count);
        }

        [TestMethod]
        public async Task BonNombreDeCartesPackSuper()
        {
            using ApplicationDbContext db = new ApplicationDbContext(_options);

            PacksService packsService = new PacksService(db, new Super_Cartes_Infinies.Services.PlayersService(db, new Super_Cartes_Infinies.Services.StartingCardsService(db)));

            List<Card>? cards = await packsService.AcheterPaquet(2, USERID);
            Assert.AreEqual(5, cards!.Count);

            Player player = await db.Players.Where(p => p.UserId == USERID).FirstAsync();
            Assert.AreEqual(5, player.OwnedCards.Count);
        }
        #endregion

        #region Insufficient balance tests
        // Le service retourne null quand le solde est insuffisant
        [TestMethod]
        public async Task BasicPackInsufficientBalance()
        {
            using ApplicationDbContext db = new ApplicationDbContext(_options);

            PacksService packsService = new PacksService(db, new Super_Cartes_Infinies.Services.PlayersService(db, new Super_Cartes_Infinies.Services.StartingCardsService(db)));

            Player player = await db.Players.Where(p => p.UserId == USERID).FirstAsync();
            // Mettre le solde à 0
            player.Balance = 0;
            await db.SaveChangesAsync();

            List<Card>? cards = await packsService.AcheterPaquet(0, USERID);


            Assert.IsNull(cards);
        }

        [TestMethod]
        public async Task NormalPackInsufficientBalance()
        {
            using ApplicationDbContext db = new ApplicationDbContext(_options);

            PacksService packsService = new PacksService(db, new Super_Cartes_Infinies.Services.PlayersService(db, new Super_Cartes_Infinies.Services.StartingCardsService(db)));

            Player player = await db.Players.Where(p => p.UserId == USERID).FirstAsync();
            // Mettre le solde à 0
            player.Balance = 0;
            await db.SaveChangesAsync();

            List<Card>? cards = await packsService.AcheterPaquet(1, USERID);


            Assert.IsNull(cards);
        }

        [TestMethod]
        public async Task SuperPackInsufficientBalance()
        {
            using ApplicationDbContext db = new ApplicationDbContext(_options);

            PacksService packsService = new PacksService(db, new Super_Cartes_Infinies.Services.PlayersService(db, new Super_Cartes_Infinies.Services.StartingCardsService(db)));

            Player player = await db.Players.Where(p => p.UserId == USERID).FirstAsync();
            // Mettre le solde à 0
            player.Balance = 0;
            await db.SaveChangesAsync();

            List<Card>? cards = await packsService.AcheterPaquet(2, USERID);


            Assert.IsNull(cards);
        }
        #endregion

        #region Valider conditions du pack Super tests

        [TestMethod]
        public async Task AuMoinsUnEpicDansPackSuper()
        {
            using ApplicationDbContext db = new ApplicationDbContext(_options);

            PacksService packsService = new PacksService(db, new Super_Cartes_Infinies.Services.PlayersService(db, new Super_Cartes_Infinies.Services.StartingCardsService(db)));

            List<Card>? cards = await packsService.AcheterPaquet(2, USERID);

            Player player = await db.Players.Where(p => p.UserId == USERID).FirstAsync();

            bool hasEpicCard = false;
            int i = 0;
            while(i <  player.OwnedCards.Count && !hasEpicCard)
            {
                OwnedCard ownedCard = player.OwnedCards[i];
                if (ownedCard.Card.Rarity == Rarity.Epic)
                {
                    // Retourner quand au moins un carte est épique fait réussir le test
                    hasEpicCard = true;
                }
                i++;
            }

            Assert.IsTrue(hasEpicCard);
        }

        [TestMethod]
        public async Task AucuneCarteCommuneDansPaquetSuper()
        {
            using ApplicationDbContext db = new ApplicationDbContext(_options);

            PacksService packsService = new PacksService(db, new Super_Cartes_Infinies.Services.PlayersService(db, new Super_Cartes_Infinies.Services.StartingCardsService(db)));

            List<Card>? cards = await packsService.AcheterPaquet(2, USERID);

            Card? card = cards!.FirstOrDefault(x => x.Rarity == Rarity.Common);

            Assert.IsNull(card);
        }

        #endregion
    }
}
