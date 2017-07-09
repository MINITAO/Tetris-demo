namespace Tetris
{
    public enum GameState
    {
        ready,
        playing,
        over,
    }

    public class GameManager
    {
        private static GameState gameState;
        public static GameState GameState
        {
            get
            {
                return gameState;
            }
        }

        static GameManager()
        {
            gameState = GameState.ready;
        }

        public static void Start()
        {
            gameState = GameState.playing;
        }

        public static void Over()
        {
            gameState = GameState.over;
        }

    }

}
