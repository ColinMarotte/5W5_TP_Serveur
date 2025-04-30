using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Services;

namespace Super_Cartes_Infinies.Hubs;

[Authorize]
public class MatchHub : Hub
{

    private MatchesService _matchService;

    public MatchHub(MatchesService matchesService)
    {
        _matchService = matchesService;
    }

    public async Task StopJoiningMatch()
    {
        var userId = Context.UserIdentifier ;
        var stoppedJoiningStatus = await _matchService.StopJoiningMatch(userId);
        await Clients.Caller.SendAsync("StoppedJoiningStatus", stoppedJoiningStatus);
        
    }

    public async Task JoinMatch()
    {
        var userId = Context.UserIdentifier!;

        var matchData = await _matchService.JoinMatch(userId, Context.ConnectionId, null);

        if (matchData != null)
        {
            string matchGroup = matchData.Match.Id.ToString();

            await Groups.AddToGroupAsync(Context.ConnectionId, matchGroup);
              
            await Clients.Client(Context.ConnectionId).SendAsync("JoiningMatchData", matchData);

            if (matchData.OtherPlayerConnectionId != null)
            {
                await Groups.AddToGroupAsync(matchData.OtherPlayerConnectionId, matchGroup);
                await Clients.Client(matchData.OtherPlayerConnectionId).SendAsync("JoiningMatchData", matchData);
            }

            if (!matchData.IsStarted)
            {
                StartMatchEvent startMatchEvent = await _matchService.StartMatch(userId, matchData.Match);
                await Clients.Group(matchGroup).SendAsync("StartMatchEvent", startMatchEvent);
            }
        }
    }

    public async Task EndTurn(int matchId)
    {
        var userId = Context.UserIdentifier!;

        var endTurnEvent = await _matchService.EndTurn(userId, matchId);

        if (endTurnEvent != null)
        {
            await Clients.Group(matchId.ToString()).SendAsync("EndTurnEvent", endTurnEvent);
        }
    }


    public async Task Surrender(int matchId)
    {
        var userId = Context.UserIdentifier!;

        SurrenderEvent surrenderEvent = await _matchService.Surrender(userId, matchId);

        if (surrenderEvent != null)
        {
            await Clients.Group(matchId.ToString()).SendAsync("SurrenderEvent",surrenderEvent);
        }
        

    }

    public async Task PlayCard(int matchId, int playableCardId)
    {
        var userId = Context.UserIdentifier!;

        PlayCardEvent playCardEvent = await _matchService.PlayCard(userId, matchId, playableCardId);

        if(playCardEvent != null)
        {
            await Clients.Group(matchId.ToString()).SendAsync("PlayCardEvent", playCardEvent);
        }
    }


}