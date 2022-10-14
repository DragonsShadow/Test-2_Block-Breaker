
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace View
{
    public class WinOrLoseDetector : MonoBehaviour
    {
        private bool _isLose;
        private static bool _isWinLevel;
        public static bool IsFinishedGame;

        public Text endOfGame;
        public GameObject endOfGameObject;
        public GameObject background;
        public GameObject retryButton;
        public GameObject returnToMainMenuButton;
        public GameObject nextLevelButton;

        public static void GameWinDetect()
        {
            IsFinishedGame = true;
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
                retryButton.SetActive(true);
                returnToMainMenuButton.SetActive(true);
                GameUiManager.PauseGame();
                _isLose = false;
                GameUiManager.IsStarted = false;

            }
            if (_isWinLevel && !IsFinishedGame)
            {
                endOfGame.text = "You May Live Longer!";
                endOfGameObject.SetActive(true);
                background.SetActive(true);
                nextLevelButton.SetActive(true);
                returnToMainMenuButton.SetActive(true);
                GameUiManager.PauseGame();
                _isWinLevel = false;
            }
            if (IsFinishedGame)
            {
                endOfGame.text = "Just Goooo";
                endOfGameObject.SetActive(true);
                background.SetActive(true);
                returnToMainMenuButton.SetActive(true);
                nextLevelButton.SetActive(false);
                GameUiManager.PauseGame();
                _isWinLevel = false;
            }
        }

        public void NextLevelAction()
        {
            GameUiManager.PauseGame();
            background.SetActive(false);
            nextLevelButton.SetActive(false);
            returnToMainMenuButton.SetActive(false);
            retryButton.SetActive(false);
            endOfGameObject.SetActive(false);
        }

        public void RetryAction()
        {
            GameUiManager.PauseGame();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }

        public void ReturnToMainMenuAction()
        {
            IsFinishedGame = false;
            GameUiManager.PauseGame();
            SceneManager.LoadScene("MainMenu");
        }
    }
}