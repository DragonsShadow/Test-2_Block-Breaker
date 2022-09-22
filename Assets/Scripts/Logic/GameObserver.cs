namespace Logic
{
    public class GameObserver
    {
        private static bool _hasResult;

        public static bool WinOrLoseNotify()
        {
            return _hasResult;
        }
    }
}