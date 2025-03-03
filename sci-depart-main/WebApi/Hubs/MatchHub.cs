using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;

namespace Super_Cartes_Infinies.Hubs;

//[Authorize]
public class MatchHub : Hub
{

    private MatchesService _matchService;

    public MatchHub(MatchesService matchesService)
    {
        _matchService = matchesService;
    }

    public async Task JoinMatch(string userId)
    {
        var matchData = await _matchService.JoinMatch(userId, Context.ConnectionId, null);

        if (matchData != null)
        {
            string matchGroup = matchData.Match.Id.ToString();

            await Groups.AddToGroupAsync(Context.ConnectionId, matchGroup);

            await Clients.Client(Context.ConnectionId).SendAsync("JoiningMatchData", matchData);

            if (matchData.OtherPlayerConnectionId != null)
            {
                await Clients.Client(matchData.OtherPlayerConnectionId).SendAsync("JoiningMatchData", matchData);
            }

            if (matchData.IsStarted)
            {
                var startMatchEvent = await _matchService.StartMatch(userId, matchData.Match);
                await Clients.Group(matchGroup).SendAsync("StartMatchEvent", startMatchEvent);
            }
        }
    }

    public async Task EndTurn(int matchId)
    {
        var userId = Context.UserIdentifier;

        if (userId == null)
        {
            throw new Exception("User identifier is missing.");
        }

        var endTurnEvent = await _matchService.EndTurn(userId, matchId);

        if (endTurnEvent != null)
        {
            await Clients.Group(matchId.ToString()).SendAsync("ApplyEvents", endTurnEvent);
        }
    }


    public async Task Surrender(string userId, int matchId)
    {
        SurrenderEvent surrenderEvent = await _matchService.Surrender(userId, matchId);

        if (surrenderEvent != null)
        {
            await Clients.Group(matchId.ToString()).SendAsync("SurrenderEvent",surrenderEvent);
        }
        

    }

}