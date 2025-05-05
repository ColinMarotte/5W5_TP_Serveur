using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Models.Models.Enums;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Data
{
    public class Seed
    {
        public Seed() { }

        public static Card[] SeedCards()
        {
            return new Card[] {
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
                },
                // Section Pouvoirs Supplémentaires - 3 nouvelles cartes (pour leur donner les nouveaux pouvoirs)
                new Card
                {
                    Id = 13,
                    Name = "Chat Magicien",
                    Attack = 8,
                    Health = 6,
                    Cost = 4,
                    ImageUrl = "https://palmaris.ca/cdn/shop/files/IMG_2982.jpg?v=1726299219",
                    Rarity = Rarity.Epic,
                    Price = RarityInfo.GetPrice(Rarity.Epic)
                },
                new Card
                {
                    Id = 14,
                    Name = "Barber Cat",
                    Attack = 5,
                    Health = 3,
                    Cost = 2,
                    ImageUrl = "https://numeralpaint.com/wp-content/uploads/2021/06/barber-cat-paint-by-numbers.jpg",
                    Rarity = Rarity.Rare,
                    Price = RarityInfo.GetPrice(Rarity.Rare)
                },
                new Card
                {
                    Id = 15,
                    Name = "Moewna Lisa",
                    Attack = 10,
                    Health = 7,
                    Cost = 5,
                    ImageUrl = "https://m.media-amazon.com/images/I/61hnicrIZ2L._AC_UF894,1000_QL80_.jpg",
                    Rarity = Rarity.Legendary,
                    Price = RarityInfo.GetPrice(Rarity.Legendary)
                },
                // TODO: Nouvelle card au choix
                //new Card
                //{
                    //Id = 16
                //}
                // Section Pouvoirs Supplémentaires - 2 sorts
                new Card
                {
                    Id = 17,
                    Name = "Earthquake",
                    IsASpell = true,
                    Attack = 2,
                    Health = 0,
                    Cost = 4,
                    ImageUrl = "https://thumb.ac-illust.com/8e/8ee838398cdb5a3a2d9a7a8b26ad7ae6_t.jpeg",
                    Rarity = Rarity.Rare,
                    Price = RarityInfo.GetPrice(Rarity.Rare)
                },
                new Card
                {
                    Id = 18,
                    Name = "Random Pain",
                    IsASpell = true,
                    Attack = 0,
                    Health = 0,
                    Cost = 3,
                    ImageUrl = "https://www.shutterstock.com/image-vector/cute-cat-injury-sick-bandage-600nw-2415004269.jpg",
                    Rarity = Rarity.Epic,
                    Price = RarityInfo.GetPrice(Rarity.Epic)
                }
            };
        }

        public static StartingCard[] SeedStartingCards()
        {
            return new StartingCard[] {
                new StartingCard
                {
                    Id = 1,
                    CardId = 1
                },new StartingCard
                {
                    Id = 2,
                    CardId = 2
                },new StartingCard
                {
                    Id = 3,
                    CardId = 3
                },new StartingCard
                {
                    Id = 4,
                    CardId = 4
                },new StartingCard
                {
                    Id = 5,
                    CardId = 4
                },new StartingCard
                {
                    Id = 6,
                    CardId = 5
                },new StartingCard
                {
                    Id = 7,
                    CardId = 5
                },new StartingCard               
                {
                    Id = 8,
                    CardId = 6
                },new StartingCard
                {
                    Id = 9,
                    CardId = 6
                },
                // Section Pouvoirs Supplémentaires - nouvelle starting card ayant un des nouveaux pouvoirs
                new StartingCard
                {
                    Id = 10,
                    CardId = 13
                },
                // Section Pouvoirs Supplémentaires - nouvelle starting card ayant un des nouveaux sorts
                new StartingCard
                {
                    Id = 11,
                    CardId = 18
                }
            };
        }

        public static GameConfig SeedGameConfig()
        {
            return new GameConfig
            {
                Id = 1,
                NbCardsToDraw = 4,
                QtyManaPerTurn = 3,
                NbDecksMax = 3,
                NbCardsMaxInDeck = 10,
                ArgentRecuGagnant=40,
                ArgentRecuPerdant=100
            };
        }

        public static IdentityUser[] SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();
            IdentityUser admin = new IdentityUser
            {
                Id = "11111111-1111-1111-1111-111111111111",
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                // La comparaison d'identity se fait avec les versions normalisés
                NormalizedEmail = "ADMIN@ADMIN.COM",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                // On encrypte le mot de passe
                PasswordHash = hasher.HashPassword(null, "Passw0rd!"),
                LockoutEnabled = true
            };

            return new IdentityUser[] { admin };
        }

        public static IdentityRole[] SeedRoles()
        {
            IdentityRole adminRole = new IdentityRole
            {
                Id = "11111111-1111-1111-1111-111111111112",
                Name = ApplicationDbContext.ADMIN_ROLE,
                NormalizedName = ApplicationDbContext.ADMIN_ROLE.ToUpper()
            };

            return new IdentityRole[] { adminRole };
        }

        public static IdentityUserRole<string>[] SeedUserRoles()
        {
            IdentityUserRole<string> userAdmin = new IdentityUserRole<string>
            {
                RoleId = "11111111-1111-1111-1111-111111111112",
                UserId = "11111111-1111-1111-1111-111111111111"
            };
            return new IdentityUserRole<string>[] { userAdmin };
        }

        public static IdentityUser[] SeedTestUsers()
        {
            return new IdentityUser[] {
                new IdentityUser()
                {
                    Id = "User1Id"
                },
                new IdentityUser
                {
                Id = "User2Id"
                }
            };
        }

        public static Player[] SeedTestPlayers()
        {
            return new Player[] {
                new Player
                {
                    Id = 1,
                    Name = "Test player 1",
                    UserId = "User1Id"

                },
                new Player
                {
                    Id = 2,
                    Name = "Test player 2",
                    UserId = "User2Id"
                },
                new Player
                {
                    Id = 3,
                    Name = "Admin",
                    UserId = "11111111-1111-1111-1111-111111111111"
                }

            };


        }

        public static Power[] SeedPowers()
        {
            return new Power[]
            {
                new Power
                {
                    Id = 1,
                    Name = "First Strike",
                    Description = "Attaque l'adversaire.",
                    Icone = "🏅"
                },
                new Power
                {
                    Id = 2,
                    Name = "Thorns",
                    Description = "Inflige des dégâts au moment où la carte reçoit des dégâts.",
                    Icone = "🌹"
                },
                new Power
                {
                    Id = 3,
                    Name = "Heal",
                    Description = "Rend des points de vie à une carte.",
                    Icone = "❤️"
                },
                new Power
                {
                    Id = 4,
                    Name = "Shield",
                    Description = "Absorbe les dégâts.",
                    Icone = "🛡️"
                },
                // Section Pouvoirs Supplémentaires - 3 nouveaux pouvoirs
                new Power
                {
                    Id = 5,
                    Name = "Chaos",
                    Description = "Cause des dégats à toutes les cartes",
                    Icone = "🌀"
                },
                new Power
                {
                    Id = 6,
                    Name = "Poison",
                    Description = "Cause des au fil du temps à l'adversaire",
                    Icone = "☠️"
                },
                new Power
                {
                    Id = 7,
                    Name = "Stunned",
                    Description = "Empêche une carte d'agir",
                    Icone = "😵‍"
                }
            };
        }

        public static IEnumerable<CardPower> SeedCardPowers()
        {
            return new List<CardPower>
            {
                new CardPower
                {
                    CardPowerId=1,
                    CardId = 1,
                    PowerId = 1,
                    Value = 0
                },
                new CardPower
                {
                    CardPowerId=2,
                    CardId = 2,
                    PowerId = 2,
                    Value = 1
                },
                new CardPower
                {
                    CardPowerId=3,
                    CardId = 3,
                    PowerId = 3,
                    Value = 5
                },
                new CardPower
                {
                    CardPowerId=4,
                    CardId = 4,
                    PowerId = 4,
                    Value = 3
                },
                new CardPower
                {
                    CardPowerId=5,
                    CardId = 4,
                    PowerId = 3,
                    Value = 3
                },
                new CardPower
                {
                    CardPowerId=6,
                    CardId = 1,
                    PowerId = 3,
                    Value = 3
                },
                // Section Pouvoirs Supplémentaires - 3 nouveaux pouvoirs assignés aux cartes
                new CardPower
                {
                    CardPowerId=7,
                    CardId = 13,
                    PowerId = 5,
                    Value = 0
                },
                new CardPower
                {
                    CardPowerId = 8,
                    CardId = 14,
                    PowerId = 6,
                    Value = 2
                },
                new CardPower
                {
                    CardPowerId = 9,
                    CardId = 15,
                    PowerId = 7,
                    Value = 3
                }
            };
        }

    }
}

