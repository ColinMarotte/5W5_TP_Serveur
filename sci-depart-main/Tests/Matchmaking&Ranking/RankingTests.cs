using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Services;

namespace Tests.MatchmakingEtClassement
{
    [TestClass]
    public class RankingTests
    {
        protected const int STARTING_PLAYER_HEALTH = 1;
        protected const int NB_MANA_PER_TURN = 3;

        protected MatchPlayerData _currentPlayerData, _opposingPlayerData;
        protected Player _player1, _player2;

        private MatchesService _matchesService;
        private ApplicationDbContext _db;
        private Match _match;


        // Étapes: 2 et 5
        [TestInitialize]
        public void Init()
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
            PlayersService playersService = new PlayersService(_db, new StartingCardsService(_db));

            _matchesService = new MatchesService(_db,
                new Super_Cartes_Infinies.Services.WaitingUserService(),
                playersService,
                new CardsService(_db, playersService),
                new MatchConfigurationService(_db),
                new GameConfigsService(_db)
            );

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

            _match = new Match
            {
                UserAId = _player1.UserId,
                UserBId = _player2.UserId,
                PlayerDataA = _currentPlayerData,
                PlayerDataB = _opposingPlayerData
            };

            _db.Add(_player1);
            _db.Add(_player2);
            _db.Add(_match);

            
            _db.SaveChanges();

        }

        // Étapes: 4 et 7
        [TestCleanup]
        public void Dispose()
        {
            _db.Dispose();
        }

        // Étape: 3
        [TestMethod]
        public void StartingELOTest()
        {

            Assert.AreEqual(1000, _player1.ELO);
            Assert.AreEqual(1000, _player2.ELO);
        }

        [TestMethod]
        public void MatchEndELOTest()
        {
            PlayersService playersService = new PlayersService(_db, new StartingCardsService(_db));
            MatchesService matchesService = new MatchesService(_db,
                new Super_Cartes_Infinies.Services.WaitingUserService(),
                playersService,
                new CardsService(_db, playersService),
                new MatchConfigurationService(_db),
                new GameConfigsService(_db)
            );
            _matchesService.Surrender(_player1.UserId, _match.Id);

            Assert.AreEqual(984, _player1.ELO);
            Assert.AreEqual(1016, _player2.ELO);

        }
    }
}
