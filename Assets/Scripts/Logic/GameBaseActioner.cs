using UnityEngine;

namespace Logic
{
    public class GameBaseActioner
    {
        public static bool PauseGame(bool isPaused)
        {
            isPaused = !isPaused;
            if (Time.timeScale >= 1)
            {
                Time.timeScale = 0;
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }

            return isPaused;
        }
    }
}