using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Super_Cartes_Infinies.Data;
using Super_Cartes_Infinies.Hubs;
using Super_Cartes_Infinies.Models;

namespace Super_Cartes_Infinies.Services
{
    public class UserData
    {
        public int WaitingTime { get; set; } = 0;
        public string UserId { get; set; }
        public int ELO { get; set; }
        public string UserAConnectionId { get; set; }
    }
    public class PairOfPlayers
    {
        public string UserAId;
        public string UserBId;
        public string UserAConnectionId;

    }
    public class MatchmakingBackgroundService:BackgroundService
    {
        public const int DELAY = 1000;
        private IServiceScopeFactory _serviceScopeFactory;
        private IHubContext<MatchHub> _matchHub;
        private Dictionary<string, UserData> _data = new();
        private List<UserData> userDatas;
        public MatchmakingBackgroundService(IHubContext<MatchHub> matchHub, IServiceScopeFactory serviceScopeFactory) {
            _serviceScopeFactory = serviceScopeFactory;
            _matchHub = matchHub;
        }

        public async Task Queue(CancellationToken stoppingToken)
        {
            using (IServiceScope scope = _serviceScopeFactory.CreateScope())
            {
                ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                // On peut maintenant utiliser le dbContext normalement
                // On peut également faire un SaveChanges
                // Passer une COPIE de l'information sur les players (Car on va retirer les éléments de la liste, même si le player n'est pas mis dans une paire)

            }
        }

        public void AddUser(string userId, int elo, string connectionId)
        {
            //Player player = 
            _data[userId] = new UserData()
            {
                UserId = userId,
                ELO = elo,
                UserAConnectionId = connectionId
            };


        }
        public void RemoveUser(string userId)
        {
            _data.Remove(userId);
        }

        public void Increment(string userId)
        {
            UserData userData = _data[userId];
            userData.WaitingTime++;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(DELAY, stoppingToken);
                await Queue(stoppingToken);
            }
        }


        public void GeneratePairs(List<UserData> playersInfos)
        {

            List<PairOfPlayers> pairs = new List<PairOfPlayers>();

            // Tant qu'il y a des joueurs à mettre en pair
            while (playersInfos.Count > 0)
            {
                UserData playerInfo = playersInfos[0];
                playersInfos.RemoveAt(0);
                int smallestELODifference = int.MaxValue;
                int index = -1;
                for (int i = 0; i < playersInfos.Count; i++)
                {
                    UserData pi = playersInfos[i];
                    int difference = Math.Abs(pi.ELO - playerInfo.ELO);
                    if(difference < playerInfo.WaitingTime * DELAY)
                    {
                        smallestELODifference = difference;
                        index = i;
                    }
                }

                if(index >= 0)
                {
                    UserData playerInfo2 = playersInfos[index];
                    playersInfos.RemoveAt(index);
                    pairs.Add(new PairOfPlayers()
                    {
                        UserAId = playerInfo.UserId,
                        UserBId = playerInfo2.UserId,
                        UserAConnectionId = playerInfo.UserAConnectionId
                    });
                }

            }
        }
    }
}
