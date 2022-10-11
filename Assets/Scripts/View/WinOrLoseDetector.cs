
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace View
{
    public class WinOrLoseDetector : MonoBehaviour
    {
        private bool _isLose;
        private static bool _isWinLevel;
        private static bool _isFinishedGame;

        public Text endOfGame;
        public GameObject endOfGameObject;
        public GameObject background;
        public GameObject RetryButton;
        public GameObject ReturnToMainMenuButton;
        public GameObject NextLevelButton;

        public static void GameWinDetect()
        {
            _isFinishedGame = true;
        }
        public static void LevelWinDetect()
        {
            _isWinLevel = true;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag.Equals("Ground"))
            {
                _isLose = true;
            }
        }

        private void Update()
        {
            if (_isLose)
            {
                endOfGame.text = "Freed From Mortal Ciol!";
                endOfGameObject.SetActive(true);
                background.SetActive(true);
                RetryButton.SetActive(true);
                ReturnToMainMenuButton.SetActive(true);
                GameUiManager.PauseGame();
                _isLose = false;

            }
            if (_isWinLevel)
            {
                endOfGame.text = "You May Live Longer!";
                endOfGameObject.SetActive(true);
                background.SetActive(true);
                NextLevelButton.SetActive(true);
                ReturnToMainMenuButton.SetActive(true);
                GameUiManager.PauseGame();
                _isWinLevel = false;
            }
            if (_isFinishedGame)
            {
                endOfGame.text = "Just Goooo";
                endOfGameObject.SetActive(true);
                background.SetActive(true);
                ReturnToMainMenuButton.SetActive(true);
                GameUiManager.PauseGame();
                _isFinishedGame = false;
            }
        }

        public void NextLevelAction()
        {
            GameUiManager.PauseGame();
            background.SetActive(false);
            NextLevelButton.SetActive(false);
            ReturnToMainMenuButton.SetActive(false);
            RetryButton.SetActive(false);
            endOfGameObject.SetActive(false);
        }

        public void RetryAction()
        {
            SceneManager.LoadScene("MainGame");
        }

        public void ReturnToMainMenuAction()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}