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
        public int WinningPlayerELO { get; set; }
        public int WinningPlayerELOGain { get; set; }
        public int LosingPlayerELO { get; set; }
        public int LosingPlayerELOLost { get; set; }

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
            int winningPlayerOldELO = winningPlayerData.Player.ELO;
            int losingPlayerOldELO = losingPlayerData.Player.ELO;

            EloCalculator.CalculateELO(winningPlayerData, losingPlayerData, EloCalculator.GameOutcome.Win);

            WinningPlayerELOGain = winningPlayerData.Player.ELO - winningPlayerOldELO;
            LosingPlayerELOLost = losingPlayerData.Player.ELO - losingPlayerOldELO;
            WinningPlayerELO = winningPlayerData.Player.ELO;
            LosingPlayerELO = losingPlayerData.Player.ELO;
        }
    }
}
public class EloCalculator
{
    public enum GameOutcome
    {
        Win = 1,
        Loss = 0
    }

    public static void CalculateELO(MatchPlayerData winningPlayerData, MatchPlayerData losingPlayerData, GameOutcome p1Outcome)
    {
        int eloK = 32;

        double expectation = ExpectationToWin(winningPlayerData.Player.ELO, losingPlayerData.Player.ELO);
        int delta = (int)(eloK * ((int)p1Outcome - expectation));

        winningPlayerData.Player.ELO += delta;
        losingPlayerData.Player.ELO -= delta;
    }

    private static double ExpectationToWin(int p1Rating, int p2Rating)
    {
        return 1 / (1 + Math.Pow(10, (p2Rating - p1Rating) / 400.0));
    }
}
//public class EloCalculator
//{
//    public enum GameOutcome
//    {
//        Win = 1,
//        Loss = 0
//    }

//    public static void CalculateELO(ref int p1Rating,ref int p2Rating, GameOutcome p1Outcome)
//    {
//        int eloK = 32;

//        double expectation = ExpectationToWin(p1Rating, p2Rating);
//        int delta = (int)(eloK * ((int)p1Outcome - expectation));

//        p1Rating += delta;
//        p2Rating -= delta;
//    }

//    private static double ExpectationToWin(int p1Rating, int p2Rating)
//    {
//        return 1 / (1 + Math.Pow(10, (p2Rating - p1Rating) / 400.0));
//    }
//}
