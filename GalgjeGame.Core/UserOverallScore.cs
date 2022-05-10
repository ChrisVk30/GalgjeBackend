namespace GalgjeGame.Core
{
    public class UserOverallScore
    {
        public string UserName { get; set; }
        public int WordsGuessed { get; set; }
        public int TimesPlayed { get; set; }
        public double Ratio { get; set; }
        public List<UserGameScore> userGameScores { get; set; }
    }
}
