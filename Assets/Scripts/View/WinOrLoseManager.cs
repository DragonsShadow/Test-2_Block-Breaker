using Logic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace View
{
    public class WinOrLoseManager : MonoBehaviour
    {
        public static bool IsStarted;
        public static bool IsLose;
        public static bool IsWinLevel;
        public static bool IsFinishedGame;

        private PlayerScoreChangerAndDisplayer _playerScoreChangerAndDisplayer;

        public Text endOfGame;
        public GameObject endOfGameObject;
        public GameObject background;
        public GameObject retryButton;
        public GameObject returnToMainMenuButton;
        public GameObject nextLevelButton;
        public GameObject finishGameButton;

        private void Start()
        {
            _playerScoreChangerAndDisplayer = new PlayerScoreChangerAndDisplayer();
            _playerScoreChangerAndDisplayer.PlyerScoreLoadData();
        }
        
        private void Update()
        {
            if (IsLose)
            {
                endOfGame.text = "Freed From Mortal Ciol!";
                IsLose = false;
                endOfGameObject.SetActive(true);
                background.SetActive(true);
                retryButton.SetActive(true);
                returnToMainMenuButton.SetActive(true);
                GameManager.PauseGame();
                IsStarted = false;
                
            }

            if (IsWinLevel && !IsFinishedGame)
            {
                endOfGame.text = "You May Live Longer!";
                endOfGameObject.SetActive(true);
                background.SetActive(true);
                nextLevelButton.SetActive(true);
                returnToMainMenuButton.SetActive(true);
                GameManager.PauseGame();
                IsWinLevel = false;
                _playerScoreChangerAndDisplayer.PlayerStarAdd();
                IsStarted = false;
            }

            if (IsFinishedGame)
            {
                endOfGame.text = "Just Goooo";
                endOfGameObject.SetActive(true);
                background.SetActive(true);
                returnToMainMenuButton.SetActive(false);
                finishGameButton.SetActive(true);
                GameManager.PauseGame();
                IsWinLevel = false;
                IsStarted = false;
                IsStarted = false;
                IsFinishedGame = false;
            }
        }

        public static void GameWinDetect()
        {
            IsFinishedGame = true;
        }

        public static void LevelWinDetect()
        {
            IsWinLevel = true;
        }

        public void NextLevelAction()
        {
            GameManager.PauseGame();
            DisableAllAfterWinOrLoseUiItems();
        }

        public void RetryAction()
        {
            GameManager.PauseGame();
            GameManager.LevelNumber = 0;
            SceneManager.LoadScene("MainGame");
        }

        public void ReturnToMainMenuAction()
        {
            
            GameManager.PauseGame();
            SceneManager.LoadScene("MainMenu");
        }

        public void FinishGameAction()
        {
            _playerScoreChangerAndDisplayer.PlayerStarAdd();
            ReturnToMainMenuAction();
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag.Equals("Ground"))
            {
                IsLose = true;
            }
        }

        private void DisableAllAfterWinOrLoseUiItems()
        {
            background.SetActive(false);
            nextLevelButton.SetActive(false);
            returnToMainMenuButton.SetActive(false);
            retryButton.SetActive(false);
            endOfGameObject.SetActive(false);
        }
    }
}