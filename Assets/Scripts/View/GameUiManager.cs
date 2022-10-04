using Logic;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class GameUiManager : MonoBehaviour
    {
        private string _levelName;
        [SerializeField] private Text playerWinOrLoseMessage;
        [SerializeField] private GameObject playerWinOrLoseMessageObject;
        [SerializeField] private Grid _grid;
        private Vector3 _tempTransformForSpawn = new Vector3(0, 0, 0);

        private void Start()
        {
            LevelAssemble();
        }

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
            Invoke("WinOrLoseTextShowEnd", 1f);
        }

        private void WinOrLoseTextShowEnd()
        {
            playerWinOrLoseMessageObject.SetActive(false);
        }

        private void LevelAssemble()
        {
            _tempTransformForSpawn = _grid.transform.localPosition;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    LevelManager.LevelAssembleDataSend();
                    if (LevelManager.TempCreatingBlock != null)
                    {
                        Instantiate(LevelManager.TempCreatingBlock, _tempTransformForSpawn,
                            new Quaternion(0, 0, 0, 0));
                    }

                    _tempTransformForSpawn += new Vector3(1, 0, 0);
                }

                _tempTransformForSpawn = new Vector3(_grid.transform.localPosition.x, _tempTransformForSpawn.y,
                    _tempTransformForSpawn.z);
                _tempTransformForSpawn += new Vector3(0, -1, 0);
            }
        }
    }
}