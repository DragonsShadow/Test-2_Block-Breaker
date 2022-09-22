using Logic;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class GameUiManager : MonoBehaviour
    {
        private string _levelName;
        [SerializeField] private Text playerWinOrLoseMessage;
        [SerializeField]private GameObject playerWinOrLoseMessageObject;
        private void Update()
        {
            if (Input.anyKey)
            {
                PlayerMover.PlayerMovement();
            }

            if (GameObserver.WinOrLoseNotify())
            {
                var gameNotifier = new GameNotifier();
                gameNotifier.LevelNameChange(_levelName);
                gameNotifier.WinOrLoseTextChange(playerWinOrLoseMessage);
                WinOrLoseTextShow();
            }
        }

        private void WinOrLoseTextShow()
        {
            playerWinOrLoseMessageObject.SetActive(true);
            Invoke("WinOrLoseTextShowEnd",1f);
        }

        private void WinOrLoseTextShowEnd()
        {
            playerWinOrLoseMessageObject.SetActive(false);
        }
    }
}