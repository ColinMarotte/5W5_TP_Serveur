using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Models.Models.Dtos;
using Super_Cartes_Infinies.Combat;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;

namespace Super_Cartes_Infinies.Hubs;

[Authorize]
public class MatchHub : Hub
{

    private MatchesService _matchService;
    private PlayersService _playersService;

    public MatchHub(MatchesService matchesService, PlayersService playersService)
    {
        _matchService = matchesService;
        _playersService = playersService;
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

    public async Task SendMessage(int matchId, string message)
    {
        var userId = Context.UserIdentifier!;
        Player player = _playersService.GetPlayerFromUserId(userId);

        string messageWithName = "[" + player.Name + "]: " + message;
        await Clients.Group(matchId.ToString()).SendAsync("NewMessage", messageWithName);
    }

    public async Task GetCurrentMatches()
    {
        List<MatchInfoDTO> matchesInfos = await _matchService.GetCurrentMatches();
        await Clients.Caller.SendAsync("CurrentMatches", matchesInfos);
    }
}