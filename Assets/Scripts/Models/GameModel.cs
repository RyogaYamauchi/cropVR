namespace Scripts.Models
{
    public class GameModel
    {
        public static GameModel Instance { get; } = new GameModel(); //シングルトン

        public int Score;
    }
}