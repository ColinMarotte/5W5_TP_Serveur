using Microsoft.EntityFrameworkCore;
using Models.Models.Enums;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;

namespace Tests.Services
{
    [TestClass]
    public class PowerTests : BaseTests
	{
        private DbContextOptions<ApplicationDbContext> _options;
        public PowerTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
         // TODO il faut installer la dépendance Microsoft.EntityFrameworkCore.InMemory
         .UseInMemoryDatabase(databaseName: "CardsService")
         .UseLazyLoadingProxies(true) // Active le lazy loading
         .Options;
        }

        [TestInitialize]
        public void Init()
        {
            base.Init();
            // TODO avoir la durée de vie d'un context la plus petite possible
            //using ApplicationDbContext db = new ApplicationDbContext(_options);
            //// TODO on ajoute des données de tests
            //Card[] cards = new Card[] {
            //  new Card
            //    {
            //        Id = 1,
            //        Name = "Chat Dragon",
            //        Attack = 3,
            //        Health = 3,
            //        Cost = 3,
            //        ImageUrl = "https://i.pinimg.com/originals/a8/16/49/a81649bd4b0f032ce633161c5a076b87.jpg",
            //        Rarity = Rarity.Rare,
            //        Price = RarityInfo.GetPrice(Rarity.Rare)
            //    }, new Card
            //    {
            //        Id = 2,
            //        Name = "Chat Awesome",
            //        Attack = 2,
            //        Health = 5,
            //        Cost = 3,
            //        ImageUrl = "https://i0.wp.com/thediscerningcat.com/wp-content/uploads/2021/02/tabby-cat-wearing-sunglasses.jpg",
            //        Rarity = Rarity.Common,
            //        Price = RarityInfo.GetPrice(Rarity.Common)

            //    }, new Card
            //    {
            //        Id = 3,
            //        Name = "Chatton Laser",
            //        Attack = 2,
            //        Health = 1,
            //        Cost = 1,
            //        ImageUrl = "https://cdn.wallpapersafari.com/27/53/SZ8PO9.jpg",
            //        Rarity = Rarity.Legendary,
            //        Price = RarityInfo.GetPrice(Rarity.Legendary)

            //    }, new Card
            //    {
            //        Id = 4,
            //        Name = "Chat Spacial",
            //        Attack = 8,
            //        Health = 4,
            //        Cost = 4,
            //        ImageUrl = "https://wallpapers.com/images/hd/epic-cat-poster-baavft05ylgta4j8.jpg",
            //        Rarity = Rarity.Legendary,
            //        Price = RarityInfo.GetPrice(Rarity.Legendary)
            //    }, new Card
            //    {
            //        Id = 5,
            //        Name = "Chat Guerrier",
            //        Attack = 7,
            //        Health = 7,
            //        Cost = 5,
            //        ImageUrl = "https://i.etsystatic.com/6230905/r/il/32aa5a/3474618751/il_fullxfull.3474618751_mfvf.jpg",
            //        Rarity = Rarity.Epic,
            //        Price = RarityInfo.GetPrice(Rarity.Epic)
            //    }, new Card
            //    {
            //        Id = 6,
            //        Name = "Chat Laser",
            //        Attack = 4,
            //        Health = 2,
            //        Cost = 2,
            //        ImageUrl = "https://store.playstation.com/store/api/chihiro/00_09_000/container/AU/en/99/EP2402-CUSA05624_00-ETH0000000002875/0/image?_version=00_09_000&platform=chihiro&bg_color=000000&opacity=100&w=720&h=720",
            //        Rarity = Rarity.Rare,
            //        Price = RarityInfo.GetPrice(Rarity.Rare)
            //    }, new Card
            //    {
            //        Id = 7,
            //        Name = "Jedi Chat",
            //        Attack = 6,
            //        Health = 3,
            //        Cost = 4,
            //        ImageUrl = "https://images.squarespace-cdn.com/content/51b3dc8ee4b051b96ceb10de/1394662654865-JKOZ7ZFF39247VYDTGG9/hilarious-jedi-cats-fight-video-preview.jpg?content-type=image%2Fjpeg",
            //        Rarity = Rarity.Epic,
            //        Price = RarityInfo.GetPrice(Rarity.Epic)
            //    }, new Card
            //    {
            //        Id = 8,
            //        Name = "Blob Chat",
            //        Attack = 1,
            //        Health = 9,
            //        Cost = 2,
            //        ImageUrl = "https://i.pinimg.com/736x/48/ba/94/48ba9440c4f87e42af99774ec51f53a1.jpg",
            //        Rarity = Rarity.Common,
            //        Price = RarityInfo.GetPrice(Rarity.Common)
            //    }, new Card
            //    {
            //        Id = 9,
            //        Name = "Jedi Chatton",
            //        Attack = 5,
            //        Health = 1,
            //        Cost = 2,
            //        ImageUrl = "https://townsquare.media/site/142/files/2011/08/jedicats.jpg?w=980&q=75",
            //        Rarity = Rarity.Rare,
            //        Price = RarityInfo.GetPrice(Rarity.Rare)
            //    }, new Card
            //    {
            //        Id = 10,
            //        Name = "Chat Furtif",
            //        Attack = 6,
            //        Health = 1,
            //        Cost = 2,
            //        ImageUrl = "https://cdn.theatlantic.com/thumbor/fOZjgqHH0RmXA1A5ek-yDz697W4=/133x0:2091x1020/1200x625/media/img/mt/2015/12/RTRD62Q/original.jpg",
            //        Rarity = Rarity.Common,
            //        Price = RarityInfo.GetPrice(Rarity.Common)
            //    }, new Card
            //    {
            //        Id = 11,
            //        Name = "Grosse Minoune",
            //        Attack = 6,
            //        Health = 6,
            //        Cost = 4,
            //        ImageUrl = "https://i.imgur.com/07zax4t.jpeg",
            //        Rarity = Rarity.Common,
            //        Price = RarityInfo.GetPrice(Rarity.Common)
            //    }, new Card
            //    {
            //        Id = 12,
            //        Name = "Petite Minoune",
            //        Attack = 2,
            //        Health = 4,
            //        Cost = 2,
            //        ImageUrl = "https://i.imgur.com/QuDe5RH.jpeg",
            //        Rarity = Rarity.Common,
            //        Price = RarityInfo.GetPrice(Rarity.Common)
            //    }
            //};
            //Power[] powers = new Power[]
            //{
            //    new Power
            //    {
            //        Id = 1,
            //        Name = "First Strike",
            //        Description = "Attaque l'adversaire.",
            //        Icone = "🏅"

            //    },
            //    new Power
            //    {
            //        Id = 2,
            //        Name = "Thorns",
            //        Description = "Inflige des dégâts au moment où la carte reçoit des dégâts.",
            //        Icone = "🌹"
            //    },
            //    new Power
            //    {
            //        Id = 3,
            //        Name = "Heal",
            //        Description = "Rend des points de vie à une carte.",
            //        Icone = "❤️"
            //    },
            //    new Power
            //    {
            //        Id = 4,
            //        Name = "Shield",
            //        Description = "Absorbe les dégâts.",
            //        Icone = "🛡️"
            //    }
            //};
            //CardPower[] cardPowers = new CardPower[]
            //{
            //    new CardPower
            //    {
            //        CardPowerId=1,
            //        CardId = 1,
            //        PowerId = 1,
            //        Value = 0
            //    },
            //    new CardPower
            //    {
            //        CardPowerId=2,
            //        CardId = 2,
            //        PowerId = 2,
            //        Value = 1
            //    },
            //    new CardPower
            //    {
            //        CardPowerId=3,
            //        CardId = 3,
            //        PowerId = 3,
            //        Value = 5
            //    },
            //    new CardPower
            //    {
            //        CardPowerId=4,
            //        CardId = 4,
            //        PowerId = 4,
            //        Value = 3
            //    },
            //    new CardPower
            //    {
            //        CardPowerId=5,
            //        CardId = 4,
            //        PowerId = 3,
            //        Value = 3
            //    },
            //    new CardPower
            //    {
            //        CardPowerId=6,
            //        CardId = 1,
            //        PowerId = 3,
            //        Value = 3
            //    }
            //};
            //Player[] players = new Player[]
            //{
            //    new Player
            //    {
            //        Id = 1,
            //        UserId =  "1",
            //        OwnedCards = new List<OwnedCard>
            //        {
            //            new OwnedCard
            //            {
            //                Card = cards[1]
            //            },
            //            new OwnedCard
            //            {
            //                Card = cards[2]
            //            },
            //            new OwnedCard
            //            {
            //                Card = cards[3]
            //            },
            //            new OwnedCard
            //            {
            //                Card = cards[4]
            //            },
            //            new OwnedCard
            //            {
            //                Card = cards[5]
            //            },
            //            new OwnedCard
            //            {
            //                Card = cards[6]
            //            },
            //            new OwnedCard
            //            {
            //                Card = cards[7]
            //            },
            //            new OwnedCard
            //            {
            //                Card = cards[8]
            //            },
            //            new OwnedCard
            //            {
            //                Card = cards[9]
            //            }
            //        }
            //    },
            //        new Player
            //        {
            //        Id = 2,
            //        UserId =  "2",
            //        OwnedCards = new List<OwnedCard>
            //        {
            //            new OwnedCard
            //            {
            //                Card = cards[1]
            //            },
            //            new OwnedCard
            //            {
            //                Card = cards[2]
            //            },
            //            new OwnedCard
            //            {
            //                Card = cards[3]
            //            },
            //            new OwnedCard
            //            {
            //                Card = cards[4]
            //            },
            //            new OwnedCard
            //            {
            //                Card = cards[5]
            //            },
            //            new OwnedCard
            //            {
            //                Card = cards[6]
            //            },
            //            new OwnedCard
            //            {
            //                Card = cards[7]
            //            },
            //            new OwnedCard
            //            {
            //                Card = cards[8]
            //            },
            //            new OwnedCard
            //            {
            //                Card = cards[9]
            //            }
            //        }
            //    }
            //};
            //Match match = new Match(players[0], players[1]);
            //db.AddRange(cards);
            //db.AddRange(powers);
            //db.AddRange(cardPowers);
            //db.AddRange(players);
            //db.AddRange(match);
            //db.SaveChanges();
        }
        [TestCleanup]
        public void Dispose()
        {
            //TODO on efface les données de tests pour remettre la BD dans son état initial
            using ApplicationDbContext db = new ApplicationDbContext(_options);
            db.Cards.RemoveRange(db.Cards);
            db.RemoveRange(db.Powers);
            db.RemoveRange(db.CardPowers);
            db.RemoveRange(db.Players);
            db.RemoveRange(db.Matches);
            db.SaveChanges();
        }
        [TestMethod]
        public void FirstStrikeAttacks()
        {
            Power firstStrikePower = new Power
            {
                Id = Power.FIRST_STRIKE_ID
            };

            CardPower cardPower = new CardPower
            {
                Power = firstStrikePower,
                PowerId = Power.FIRST_STRIKE_ID,
                Card = _cardA
            };

            _cardA.CardPowers = new List<CardPower> { cardPower };

            // On réduit le Health de la carte B pour que la carte meurt
            _playableCardB.Health = _playableCardA.Attack;

            _currentPlayerData.AddCardToBattleField(_playableCardA);
            _opposingPlayerData.AddCardToBattleField(_playableCardB);

            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            Assert.AreEqual(_currentPlayerData.PlayerId, playerTurnEvent.PlayerId);

            // La carte A n'a pas été blessé car elle a attaqué et tué son advesaire avant qu'il n'est eu
            // le temps de réagir
            Assert.AreEqual(_cardA.Health, _playableCardA.Health);
            Assert.AreEqual(0, _playableCardB.Health);
        }

        [TestMethod]
        public void FirstStrikeAttackWithoutKill()
        {
            Power firstStrikePower = new Power
            {
                Id = Power.FIRST_STRIKE_ID
            };

            CardPower cardPower = new CardPower
            {
                Power = firstStrikePower,
                PowerId = Power.FIRST_STRIKE_ID,

                Card = _cardA
            };

            _cardA.CardPowers = new List<CardPower> { cardPower };

            _currentPlayerData.AddCardToBattleField(_playableCardA);
            _opposingPlayerData.AddCardToBattleField(_playableCardB);

            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            Assert.AreEqual(_currentPlayerData.PlayerId, playerTurnEvent.PlayerId);

            // FirstStrike n'a aucun effet si l'attaquant ne tue pas le défenseur
            // Les deux cartes ont été blessées normalement
            Assert.AreEqual(_cardA.Health - _playableCardB.Attack, _playableCardA.Health);
            Assert.AreEqual(_cardB.Health - _playableCardA.Attack, _playableCardB.Health);
        }

        [TestMethod]
        public void FirstStrikeNeSertARienPourLaDefense()
        {
            Power firstStrikePower = new Power
            {
                Id = Power.FIRST_STRIKE_ID
            };

            CardPower cardPower = new CardPower
            {
                Power = firstStrikePower,
                PowerId = Power.FIRST_STRIKE_ID,
                Card = _cardB
            };

            _cardB.CardPowers = new List<CardPower> { cardPower };

            // On réduit le Health de la carte A pour que la carte meurt
            _playableCardA.Health = _playableCardB.Attack;

            _currentPlayerData.AddCardToBattleField(_playableCardA);
            _opposingPlayerData.AddCardToBattleField(_playableCardB);

            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            Assert.AreEqual(_currentPlayerData.PlayerId, playerTurnEvent.PlayerId);

            // FirstStrike n'a aucun effet si il est sur le défenseur
            Assert.AreEqual(0, _playableCardA.Health);
            Assert.AreEqual(_cardB.Health - _playableCardA.Attack, _playableCardB.Health);
        }

        [TestMethod]
        public void ThornsAttackSimple()
        {
            Power thornsPower = new Power
            {
                Id = Power.THORNS_ID
            };

            // On donne le pouvoir Thorn au défenseur
            CardPower cardPower = new CardPower
            {
                Power = thornsPower,
                PowerId = thornsPower.Id,
                Card = _cardB,
                Value = 1
            };
            _cardB.CardPowers = new List<CardPower> { cardPower };

            _currentPlayerData.AddCardToBattleField(_playableCardA);
            _opposingPlayerData.AddCardToBattleField(_playableCardB);

            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            Assert.AreEqual(_currentPlayerData.PlayerId, playerTurnEvent.PlayerId);

            Assert.AreEqual(_cardA.Health - _playableCardB.Attack - cardPower.Value, _playableCardA.Health);
            Assert.AreEqual(_cardB.Health - _playableCardA.Attack, _playableCardB.Health);

            AssertBothCardsStillOnBattlefield();
        }

        [TestMethod]
        public void ThornsAttackAvecDesDegatsSuffisantPourTuerAttaquant()
        {
            Power thornsPower = new Power
            {
                Id = Power.THORNS_ID
            };

            // On donne le pouvoir Thorn au défenseur
            CardPower cardPower = new CardPower
            {
                Power = thornsPower,
                Card = _cardB,
                PowerId = thornsPower.Id,

                // On veut être certain que l'attaquant meurt par Thorns pendant le test
                Value = _cardA.Health
            };
            _cardB.CardPowers = new List<CardPower> { cardPower };

            _currentPlayerData.AddCardToBattleField(_playableCardA);
            _opposingPlayerData.AddCardToBattleField(_playableCardB);

            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            Assert.AreEqual(_currentPlayerData.PlayerId, playerTurnEvent.PlayerId);

            Assert.AreEqual(1, _opposingPlayerData.Health);
            Assert.AreEqual(1, _currentPlayerData.Health);

            // Si l'attaquant meurt par les dégâts de Thorns, il n'a pas le temps de commencer à se battre et le défenseur ne reçoit aucun dégât
            Assert.AreEqual(_cardA.Health - cardPower.Value, _playableCardA.Health);
            Assert.AreEqual(_cardB.Health, _playableCardB.Health);

            // 
            AssertCurrentPlayerCardDied();
        }

        [TestMethod]
        public void ThornsSertARienPourUneAttaque()
        {
            Power thornsPower = new Power
            {
                Id = Power.THORNS_ID
            };

            // On donne le pouvoir Thorn a l'attaquant
            CardPower cardPower = new CardPower
            {
                Power = thornsPower,
                Card = _cardA,
                Value = 3
            };
            _cardA.CardPowers = new List<CardPower> { cardPower };

            _currentPlayerData.AddCardToBattleField(_playableCardA);
            _opposingPlayerData.AddCardToBattleField(_playableCardB);

            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);

            // Les deux cartes ont simplement perdu les points de vues habituelles
            Assert.AreEqual(_cardA.Health - _playableCardB.Attack, _playableCardA.Health);
            Assert.AreEqual(_cardB.Health - _playableCardA.Attack, _playableCardB.Health);
        }

        [TestMethod]
        public void Heal()
        {
            Power healPower = new Power
            {
                Id = Power.HEAL_ID
            };

            // On donne le pouvoir Heal à l'attaquant
            CardPower cardPower = new CardPower
            {
                Power = healPower,
                Card = _cardB,
                PowerId = healPower.Id,
                Value = 3
            };
            _cardA.CardPowers = new List<CardPower> { cardPower };

            var damagedPlayableCard = new PlayableCard(_cardB)
            {
                Id = 3
            };

            // On retire 2 PVs à l'attaquant et 4 PVs à l'autre carte de l'attaquant
            _playableCardA.Health -= 2;
            damagedPlayableCard.Health -= 4;

            _currentPlayerData.AddCardToBattleField(_playableCardA);
            _currentPlayerData.AddCardToBattleField(damagedPlayableCard);

            _opposingPlayerData.AddCardToBattleField(_playableCardB);

            var playerHealEvent = new HealEvent(_currentPlayerData, _playableCardA, _playableCardA.Index);
            Assert.AreEqual(_currentPlayerData.PlayerId, playerHealEvent.PlayerId);

            // _playableCardA devrait avoir retrouvé ses points de vie initiaux            
            Assert.AreEqual(_cardA.Health, _playableCardA.Health);
            // damagePlayableCard devrait avoir été guéri de 3 de ses 4 de dégâts
            Assert.AreEqual(_cardB.Health - 1, damagedPlayableCard.Health);

            var playerTurnEvent = new PlayerEndTurnEvent(_match, _currentPlayerData, _opposingPlayerData, NB_MANA_PER_TURN);
            Assert.AreEqual(_cardB.Health - _playableCardA.Attack, _playableCardB.Health);


            // Le damagedPlayableCard tue le joueur adverse car il n'y avait pas de carte pour le protéger
            Assert.AreEqual(0, _opposingPlayerData.Health);
            Assert.AreEqual(1, _currentPlayerData.Health);

            // Toutes les cartes sont encore en jeu
            Assert.AreEqual(2, _currentPlayerData.BattleField.Count);
            Assert.AreEqual(0, _currentPlayerData.Graveyard.Count);
            Assert.AreEqual(1, _opposingPlayerData.BattleField.Count);
            Assert.AreEqual(0, _opposingPlayerData.Graveyard.Count);
        }
        [TestMethod]
        public void HasPowerFalse()
        {
            PlayableCard playableCard = new PlayableCard(_cardA);

            Power power = new Power()
            {
                Id = Power.FIRST_STRIKE_ID
            };

            CardPower cardPower = new CardPower()
            {
                CardPowerId = 1,
                PowerId = power.Id,
                CardId = _cardA.Id
            };

            playableCard.Card.CardPowers = new List<CardPower> { cardPower };

            Assert.IsFalse(playableCard.HasPower(Power.HEAL_ID));
        }
        [TestMethod]
        public void HasPowerTrue()
        {
            PlayableCard playableCard = new PlayableCard(_cardA);

            Power power = new Power()
            {
                Id = Power.FIRST_STRIKE_ID
            };

            CardPower cardPower = new CardPower()
            {
                CardPowerId = 1,
                PowerId = power.Id,
                CardId = _cardA.Id
            };

            playableCard.Card.CardPowers = new List<CardPower> { cardPower };

            Assert.IsTrue(playableCard.HasPower(Power.FIRST_STRIKE_ID));
        }
        [TestMethod]
        public void GetPowerValueReturns0()
        {
            PlayableCard playableCard = new PlayableCard(_cardA);

            Power power = new Power()
            {
                Id = Power.FIRST_STRIKE_ID                
            };

            CardPower cardPower = new CardPower()
            {
                CardPowerId = 1,
                PowerId = power.Id,
                CardId = _cardA.Id,
                Value = 5
            };

            playableCard.Card.CardPowers = new List<CardPower> { cardPower };

            Assert.AreEqual(0, playableCard.GetPowerValue(Power.HEAL_ID));
        }

        [TestMethod]
        public void GetPowerValueReturnsValue()
        {
            PlayableCard playableCard = new PlayableCard(_cardA);

            Power power = new Power()
            {
                Id = Power.FIRST_STRIKE_ID
            };

            CardPower cardPower = new CardPower()
            {
                CardPowerId = 1,
                PowerId = power.Id,
                CardId = _cardA.Id,
                Value = 5
            };

            playableCard.Card.CardPowers = new List<CardPower> { cardPower };

            Assert.AreEqual(5, playableCard.GetPowerValue(Power.FIRST_STRIKE_ID));
        }

        #region Shield
        [TestMethod]
        public void ShieldEventDefendingCard()
        {
            //TODO Test classique d'une méthode de service
            //using ApplicationDbContext db = new ApplicationDbContext(_options);
            //StartingCardsService startingCardsService = new StartingCardsService(db);
            //PlayersService playersService = new PlayersService(db, startingCardsService);
            //WaitingUserService waitingUserService = new WaitingUserService();
            //CardsService cardsService = new CardsService(db, playersService);
            //MatchConfigurationService matchConfigurationService = new MatchConfigurationService(db);
            //MatchesService matchesService = new MatchesService(db,waitingUserService, playersService, cardsService, matchConfigurationService);
            ////db.Matches
            //Match match = db.Matches.Select(m => m.Id == 1);

            Power shieldPower = new Power
            {
                Id = Power.SHIELD_ID
            };

            // On donne le pouvoir Heal à l'attaquant
            CardPower cardPower = new CardPower
            {
                Power = shieldPower,
                Card = _cardB,
                PowerId = shieldPower.Id,
                Value = 1
            };
            _cardB.CardPowers = new List<CardPower> { cardPower };
            _currentPlayerData.AddCardToBattleField(_playableCardA);
            _opposingPlayerData.AddCardToBattleField(_playableCardB);
            var cardDamageEvent = new CardDamageEvent(_match, _opposingPlayerData, _currentPlayerData, _playableCardA.Attack, true, 0);
            Assert.IsTrue(_playableCardB.Health == 4);


        }
        [TestMethod]
        public void ShieldEventAttackingAndDefendingHasShield()
        {
            Power shieldPower = new Power
            {
                Id = Power.SHIELD_ID
            };

            // On donne le pouvoir Heal à l'attaquant
            CardPower cardPower1 = new CardPower
            {
                Power = shieldPower,
                Card = _cardA,
                PowerId = shieldPower.Id,
                Value = 1
            };           
            CardPower cardPower2 = new CardPower
            {
                Power = shieldPower,
                Card = _cardB,
                PowerId = shieldPower.Id,
                Value = 1
            };
            _cardA.CardPowers = new List<CardPower> { cardPower1 };
            _cardB.CardPowers = new List<CardPower> { cardPower2 };
            _currentPlayerData.AddCardToBattleField(_playableCardA);
            _opposingPlayerData.AddCardToBattleField(_playableCardB);
            var cardDamageEvent1 = new CardDamageEvent(_match, _currentPlayerData, _opposingPlayerData, _playableCardB.Attack, false, 0);
            var cardDamageEvent2 = new CardDamageEvent(_match, _opposingPlayerData, _currentPlayerData, _playableCardA.Attack, true, 0);
            Assert.IsTrue(_playableCardA.Health == 3);
            Assert.IsTrue(_playableCardB.Health == 4);


        }
        #endregion
    }
}

