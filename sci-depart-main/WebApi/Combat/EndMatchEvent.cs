using Microsoft.Extensions.Logging;
using Super_Cartes_Infinies.Models;
using Super_Cartes_Infinies.Services;

namespace Super_Cartes_Infinies.Combat
{
    public class EndMatchEvent : MatchEvent
    {
        public override string EventType { get { return "EndMatch"; } }
        public int WinningPlayerId { get; set; }
        public int MoneyReceivedByWinner { get; set; }
        public int MoneyReceivedByLoser { get; set; }

        public EndMatchEvent(Match match, MatchPlayerData winningPlayerData, MatchPlayerData losingPlayerData)
        {
            // Pour l'instant, on n'arrête pas la simulation sur le serveur lorsqu'on atteint la fin de la partie.
            // Pour éviter qu'un joueur qui a gagné, mais qui meurt dans le même tour ne donne la victoire à l'autre, on vérifie si le match est déjà terminé!
            if (match.IsMatchCompleted)
                return;

            WinningPlayerId = winningPlayerData.PlayerId;

            MoneyReceivedByWinner = match.ArgentRecuGagnant;
            MoneyReceivedByLoser = match.ArgentRecuPerdant;
            winningPlayerData.Player.Balance += match.ArgentRecuGagnant;
            losingPlayerData.Player.Balance += match.ArgentRecuPerdant;

            match.IsMatchCompleted = true;

            string userId;
            if (match.PlayerDataA.PlayerId == winningPlayerData.PlayerId)
                userId = match.UserAId;
            else
                userId = match.UserBId;

            match.WinnerUserId = userId;
        }
    }
}
