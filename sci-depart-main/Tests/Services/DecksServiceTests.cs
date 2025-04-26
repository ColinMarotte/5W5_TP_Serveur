using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Super_Cartes_Infinies.Services.Tests
{
    [TestClass]
    public class DecksServiceTests
    {
        private ApplicationDbContext _db;

        [TestInitialize]
        public void Init()
        {
            string dbName = "DecksService" + Guid.NewGuid().ToString();
            DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .UseLazyLoadingProxies(true)
                .Options;

            _db = new ApplicationDbContext(options);

            // Données de test:
            Card[] cards = new Card[] {
                new Card
                {
                    Id = 1,
                    Name = "Chat Dragon",
                    Attack = 5,
                    Health = 6,
                    Cost = 5,
                    ImageUrl = "https://i.pinimg.com/originals/a8/16/49/a81649bd4b0f032ce633161c5a076b87.jpg"
                }, new Card
                {
                    Id = 2,
                    Name = "Chat Awesome",
                    Attack = 2,
                     Health = 4,
                    Cost = 3,
                    ImageUrl = "https://i0.wp.com/thediscerningcat.com/wp-content/uploads/2021/02/tabby-cat-wearing-sunglasses.jpg"
                }, new Card
                {
                    Id = 3,
                    Name = "Chatton Laser",
                    Attack = 4,
                    Health = 2,
                    Cost = 3,
                    ImageUrl = "https://cdn.wallpapersafari.com/27/53/SZ8PO9.jpg"
                }, new Card
                {
                    Id = 4,
                    Name = "Chat Spacial",
                    Attack = 8,
                    Health = 4,
                    Cost = 4,
                    ImageUrl = "https://wallpapers.com/images/hd/epic-cat-poster-baavft05ylgta4j8.jpg"
                }
            };
            _db.AddRange(cards);

            Player[] players = new Player[] {
                new Player
                {
                    Id = 1,
                    Name = "Bob",
                    UserId = "1"
                },
                new Player
                {
                    Id = 2,
                    Name = "Joe",
                    UserId = "2"
                }
            };
            _db.AddRange(players);

            OwnedCard[] ownedCards = new OwnedCard[]
            {
                new OwnedCard
                {
                    Id = 1,
                    Card = cards[0],
                    Player = players[0]
                },
                new OwnedCard
                {
                    Id = 2,
                    Card = cards[1],
                    Player = players[0]
                },
                new OwnedCard
                {
                    Id = 3,
                    Card = cards[2],
                    Player = players[1]
                },
                new OwnedCard
                {
                    Id = 4,
                    Card = cards[3],
                    Player = players[1]
                }
            };
            _db.AddRange(ownedCards);

            _db.SaveChanges();
        }

        [TestCleanup]
        public void Dispose()
        {
            _db.Dispose();
        }

        [TestMethod]
        public void CreateDeckTest()
        {
            StartingCardsService startingCardsService = new StartingCardsService(_db);
            PlayersService playersService = new PlayersService(_db, startingCardsService);
            GameConfigsService gameConfigsService = new GameConfigsService(_db);
            DecksService service = new DecksService(_db, playersService, gameConfigsService);

            string deckName = "Super Deck de la m0rt qui tue!!";
            string playerId = _db.Players.Find(1).Id.ToString();

            service.CreateDeck(deckName, playerId);

            Assert.AreEqual("Super Deck de la m0rt qui tue!!", _db.Decks.First().Name);
            Assert.AreEqual(1, _db.Decks.First().PlayerId);
            Assert.AreEqual(false, _db.Decks.First().Current);
        }

        [TestMethod]
        public async Task DeleteDeckTest()
        {
            StartingCardsService startingCardsService = new StartingCardsService(_db);
            PlayersService playersService = new PlayersService(_db, startingCardsService);
            GameConfigsService gameConfigsService = new GameConfigsService(_db);
            DecksService service = new DecksService(_db, playersService, gameConfigsService);

            string deckName = "Super Deck de la m0rt qui tue!!";
            string playerId = _db.Players.Find(1).Id.ToString();
            Deck deck = await service.CreateDeck(deckName, playerId);

            service.DeleteDeck(deck.Id, int.Parse(playerId));
            Assert.IsNull(_db.Decks.Find(deck.Id));
        }

        [TestMethod]
        public async Task DeleteDeckBadPlayerTest()
        {
            StartingCardsService startingCardsService = new StartingCardsService(_db);
            PlayersService playersService = new PlayersService(_db, startingCardsService);
            GameConfigsService gameConfigsService = new GameConfigsService(_db);
            DecksService service = new DecksService(_db, playersService, gameConfigsService);

            string deckName = "Super Deck de la m0rt qui tue!!";
            string playerId = _db.Players.Find(1).Id.ToString();
            Deck deck = await service.CreateDeck(deckName, playerId);

            int playerIdPlayer2 = _db.Players.Find(2).Id;
            Exception e = Assert.ThrowsException<Exception>(() => service.DeleteDeck(deck.Id, playerIdPlayer2));
            Assert.AreEqual("Ce deck n'appartient pas au joueur connecté!", e.Message);
        }

        [TestMethod]
        public async Task AddCardToDeckTest()
        {
            StartingCardsService startingCardsService = new StartingCardsService(_db);
            PlayersService playersService = new PlayersService(_db, startingCardsService);
            GameConfigsService gameConfigsService = new GameConfigsService(_db);
            DecksService service = new DecksService(_db, playersService, gameConfigsService);

            string deckName = "Super Deck de la m0rt qui tue!!";
            string playerId1 = _db.Players.Find(1).Id.ToString();
            Deck deck = await service.CreateDeck(deckName, playerId1);

            List<int> ownedCardsPlayer1 = _db.OwnedCards.Where(o => o.Player.Id == 1).Select(o => o.Id).ToList();

            await service.AddCardsToDeck(deck.Id, ownedCardsPlayer1, int.Parse(playerId1));

            Assert.AreEqual("Chat Dragon", _db.Decks.Find(1).DeckOwnedCards[0].OwnedCard.Card.Name);
            Assert.AreEqual("Chat Awesome", _db.Decks.Find(1).DeckOwnedCards[1].OwnedCard.Card.Name);
            Assert.AreEqual(1, _db.Decks.Find(1).DeckOwnedCards[0].OwnedCard.Player.Id);
            Assert.AreEqual(1, _db.Decks.Find(1).DeckOwnedCards[1].OwnedCard.Player.Id);
        }

        [TestMethod]
        public async Task AddCardsBadPlayerToDeckTest()
        {
            StartingCardsService startingCardsService = new StartingCardsService(_db);
            PlayersService playersService = new PlayersService(_db, startingCardsService);
            GameConfigsService gameConfigsService = new GameConfigsService(_db);
            DecksService service = new DecksService(_db, playersService, gameConfigsService);

            string deckName = "Super Deck de la m0rt qui tue!!";
            string playerId1 = _db.Players.Find(1).Id.ToString();
            Deck deck = await service.CreateDeck(deckName, playerId1);

            //OwnedCards qui appartiennent au joueur 2
            List<int> ownedCardsPlayer2 = _db.OwnedCards.Where(o => o.Player.Id == 2).Select(o => o.Id).ToList();

            Exception e = await Assert.ThrowsExceptionAsync<Exception>(async () =>
            {
            await service.AddCardsToDeck(deck.Id, ownedCardsPlayer2, int.Parse(playerId1));
            });
            Assert.AreEqual("Au moins une carte n'appartient pas au joueur connecté!", e.Message);
        }

        [TestMethod]
        public async Task AddCardsToDeckBadPlayerTest()
        {
            StartingCardsService startingCardsService = new StartingCardsService(_db);
            PlayersService playersService = new PlayersService(_db, startingCardsService);
            GameConfigsService gameConfigsService = new GameConfigsService(_db);
            DecksService service = new DecksService(_db, playersService, gameConfigsService);

            string deckName = "Super Deck de la m0rt qui tue!!";
            string playerId1 = _db.Players.Find(1).Id.ToString();

            //Deck qui n'appartient pas au joueur 1
            Deck deck = await service.CreateDeck(deckName, "2");

            List<int> ownedCardsPlayer1 = _db.OwnedCards.Where(o => o.Player.Id == 1).Select(o => o.Id).ToList();

            Exception e = await Assert.ThrowsExceptionAsync<Exception>(async () =>
            {
                await service.AddCardsToDeck(deck.Id, ownedCardsPlayer1, int.Parse(playerId1));
            });
            Assert.AreEqual("Ce deck n'appartient pas au joueur connecté!", e.Message);
        }

        [TestMethod]
        public async Task RemoveCardFromDeckTest()
        {
            StartingCardsService startingCardsService = new StartingCardsService(_db);
            PlayersService playersService = new PlayersService(_db, startingCardsService);
            GameConfigsService gameConfigsService = new GameConfigsService(_db);
            DecksService service = new DecksService(_db, playersService, gameConfigsService);

            string deckName = "Super Deck de la m0rt qui tue!!";
            string playerId1 = _db.Players.Find(1).Id.ToString();

            Deck deck = await service.CreateDeck(deckName, playerId1);

            List<int> ownedCardsPlayer1 = _db.OwnedCards.Where(o => o.Player.Id == 1).Select(o => o.Id).ToList();
            await service.AddCardsToDeck(deck.Id, ownedCardsPlayer1, int.Parse(playerId1));

            Assert.AreEqual(2, deck.DeckOwnedCards.Count);

            DeckOwnedCard cardToRemove = deck.DeckOwnedCards[0];

            await service.RemoveCardFromDeck(deck.Id, cardToRemove.Id, int.Parse(playerId1));
            Assert.IsNull(_db.DeckOwnedCards.Find(cardToRemove.Id));
            Assert.AreEqual(1, deck.DeckOwnedCards.Count);
        }

        [TestMethod]
        public async Task RemoveCardFromDeckBadPlayerTest()
        {
            StartingCardsService startingCardsService = new StartingCardsService(_db);
            PlayersService playersService = new PlayersService(_db, startingCardsService);
            GameConfigsService gameConfigsService = new GameConfigsService(_db);
            DecksService service = new DecksService(_db, playersService, gameConfigsService);

            string deckName = "Super Deck de la m0rt qui tue!!";
            string playerId1 = _db.Players.Find(1).Id.ToString();

            Deck deck = await service.CreateDeck(deckName, playerId1);

            List<int> ownedCardsPlayer1 = _db.OwnedCards.Where(o => o.Player.Id == 1).Select(o => o.Id).ToList();
            await service.AddCardsToDeck(deck.Id, ownedCardsPlayer1, int.Parse(playerId1));

            DeckOwnedCard cardToRemove = deck.DeckOwnedCards[0];

            Exception e = await Assert.ThrowsExceptionAsync<Exception>(async () =>
            {
                //Le joueur 2 est connecté mais veut retirer une carte d'un deck qui ne lui appartient pas
                await service.RemoveCardFromDeck(deck.Id, cardToRemove.Id, 2);
            });
            Assert.AreEqual("Ce deck n'appartient pas au joueur connecté!", e.Message);
        }
    }
}