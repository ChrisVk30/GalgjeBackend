namespace GalgjeGame.Core.Entities
{
    public class Player
    {
        private string _userName;
        public long Id { get; set; }
        public string UserName
        {
            get { return _userName; }
            set { _userName = char.ToUpper(value[0]) + value.Substring(1).ToLower(); }
        }
        public List<Game> Games { get; set; }
    }
}