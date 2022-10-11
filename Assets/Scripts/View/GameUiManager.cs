using Logic;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class GameUiManager : MonoBehaviour
    {
        public static int DeployedBlocks;

        public Text levelNumber;
        
        private int _levelNumber;
        public static bool IsStarted;

        private Vector3 _tempTransformForSpawn = new Vector3(0, 0, 0);

        [SerializeField] private Transform player;
        [SerializeField] private Rigidbody2D ball;
        [SerializeField] private Text playerWinOrLoseMessage;
        [SerializeField] private GameObject playerWinOrLoseMessageObject;
        [SerializeField] private Grid grid;

        private void Start()
        {
            LevelGenerate();
            LevelAndPhysicsGenerateDataManager.GameReset(player.transform, ball);
        }

        private void Update()
        {
            if (!IsStarted)
            {
                IsStarted = LevelAndPhysicsGenerateDataManager.GameStart(ball);
            }

            if (DeployedBlocks <= 0)
            {
                WinOrLoseDetector.LevelWinDetect();
                NextLevelInitialises();
                LevelGenerate();
                LevelAndPhysicsGenerateDataManager.GameReset(player.transform, ball);
            }
        }

        public static void PauseGame()
        {
            if (Time.timeScale >= 1)
            {
                Time.timeScale = 0;
            }
            else if (Time.timeScale == 0 )
            {
                Time.timeScale = 1;
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

        private void NextLevelInitialises()
        {
            IsStarted = false;
            LevelAndPhysicsGenerateDataManager._isStarted = false;
            _levelNumber += 1;
            if (_levelNumber >= LevelManageData.LevelNumber)
            {
                WinOrLoseDetector.GameWinDetect();
            }
        }

        private void LevelGenerate()
        {
            levelNumber.text = (_levelNumber + 1).ToString();
            _tempTransformForSpawn = grid.transform.localPosition;
            for (int i = 0; i < Level.BlockRows; i++)
            {
                for (int j = 0; j < Level.BlockColumns; j++)
                {
                    LevelManager.LevelAssembleDataSend(_levelNumber);
                    if (LevelManager.TempCreatingBlock != null)
                    {
                        Instantiate(LevelManager.TempCreatingBlock, _tempTransformForSpawn,
                            new Quaternion(0, 0, 0, 0));
                        DeployedBlocks++;
                    }

                    _tempTransformForSpawn += new Vector3(2, 0, 0);
                }
                _tempTransformForSpawn = new Vector3(grid.transform.localPosition.x, _tempTransformForSpawn.y,
                    _tempTransformForSpawn.z);
                _tempTransformForSpawn += new Vector3(0, -1, 0);
            }
        }
    }
}