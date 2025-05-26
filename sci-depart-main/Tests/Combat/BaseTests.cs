using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;

namespace Tests.Services
{
    [TestClass]
    public class BaseTests
	{
        protected const int STARTING_PLAYER_HEALTH = 1;
        protected const int NB_MANA_PER_TURN = 3;

        protected MatchPlayerData _currentPlayerData, _opposingPlayerData;
        protected Match _match;
        protected Card _cardA, _cardB;
        protected Player _player1, _player2;
        protected PlayableCard _playableCardA, _playableCardB;
        private DbContextOptions<ApplicationDbContext> _options;
        
        private ApplicationDbContext _db;

        public BaseTests()
        {
            
        }
        [TestInitialize]
        protected void Init()
        {
            // En utilisant un nom différent à chaque fois, on n'a pas besoin de retirer les données
            string dbName = "BaseTest" + Guid.NewGuid().ToString();
            // TODO On initialise les options de la BD, on utilise une InMemoryDatabase
            DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
                // TODO il faut installer la dépendance Microsoft.EntityFrameworkCore.InMemory
                .UseInMemoryDatabase(databaseName: dbName)
                .UseLazyLoadingProxies(true) // Active le lazy loading
                .Options;

            // TODO avoir la durée de vie d'un context la plus petite possible
            _db = new ApplicationDbContext(options);


            Player currentPlayer = new Player()
            {
                UserId = "1"
            };
            _player1 = currentPlayer;
            _currentPlayerData = new MatchPlayerData(1)
            {
                Health = STARTING_PLAYER_HEALTH,
                Player = currentPlayer,
                Mana = 2
            };

            Player opposingPlayer = new Player()
            {
                UserId = "2"
            };
            _player2 = opposingPlayer;
            _opposingPlayerData = new MatchPlayerData(2)
            {
                Health = STARTING_PLAYER_HEALTH,
                Player = opposingPlayer,
                Mana = 0
            };

            // Le match n'est pas utilisé par ce test, on peut simplement en créer un sans initializer les données
            _match = new Match
            {
                UserAId = "UserAId",
                UserBId = "UserBId",
                PlayerDataA = _currentPlayerData,
                PlayerDataB = _opposingPlayerData
            };

            _cardA = new Card
            {
                Id = 42,
                Attack = 2,
                Health = 3,
                Cost = 1
            };

            _cardB = new Card
            {
                Id = 43,
                Attack = 1,
                Health = 5,
                Cost = 1
            };

            _playableCardA = new PlayableCard(_cardA)
            {
                Id = 1
            };
            _playableCardB = new PlayableCard(_cardB)
            {
                Id = 2
            };

            _db.Add(currentPlayer);
            _db.Add(opposingPlayer);

            _db.Add(_cardA);
            _db.Add(_cardB);
            _db.SaveChanges();
        }

        [TestCleanup]
        public void Dispose()
        {
            //TODO on efface les données de tests pour remettre la BD dans son état initial
            _db.Dispose();
        }


        protected void AssertBothCardsStillOnBattlefield()
        {
            Assert.AreEqual(1, _currentPlayerData.BattleField.Count);
            Assert.AreEqual(0, _currentPlayerData.Graveyard.Count);

            Assert.AreEqual(1, _opposingPlayerData.BattleField.Count);
            Assert.AreEqual(0, _opposingPlayerData.Graveyard.Count);
        }

        protected void AssertCurrentPlayerCardDied()
        {
            Assert.AreEqual(0, _currentPlayerData.BattleField.Count);
            Assert.AreEqual(1, _currentPlayerData.Graveyard.Count);

            Assert.AreEqual(1, _opposingPlayerData.BattleField.Count);
            Assert.AreEqual(0, _opposingPlayerData.Graveyard.Count);
        }

        protected void AssertOpposingPlayerCardDied()
        {
            Assert.AreEqual(1, _currentPlayerData.BattleField.Count);
            Assert.AreEqual(0, _currentPlayerData.Graveyard.Count);

            Assert.AreEqual(0, _opposingPlayerData.BattleField.Count);
            Assert.AreEqual(1, _opposingPlayerData.Graveyard.Count);
        }

        protected void AssertBothPlayersStillHaveFullHealth()
        {
            Assert.AreEqual(STARTING_PLAYER_HEALTH, _opposingPlayerData.Health);
            Assert.AreEqual(STARTING_PLAYER_HEALTH, _currentPlayerData.Health);
        }
    }
}

