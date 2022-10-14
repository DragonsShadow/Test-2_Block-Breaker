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

        private static int _levelNumber;
        public static bool IsStarted;
        private static bool _isPaused;

        private Vector3 _tempTransformForSpawn = new Vector3(0, 0, 0);

        [SerializeField] private Transform player;
        [SerializeField] private Rigidbody2D ball;
        [SerializeField] private Grid grid;

        public static int LevelNumber
        {
            get => _levelNumber;
            set => _levelNumber = value;
        }


        private void Start()
        {
            LevelGenerate();
            LevelObjectsMover.GameResetLocation(player.transform, ball);
        }

        private void Update()
        {
            if (!IsStarted && !WinOrLoseDetector.IsFinishedGame && !_isPaused && !WinOrLoseDetector.IsLose && !WinOrLoseDetector.IsWinLevel)
            {
                LevelObjectsMover.GameResetLocation(player.transform, ball);
                LevelObjectsMover.GameStartMove(ball);
            }

            if (DeployedBlocks <= 0 && !WinOrLoseDetector.IsFinishedGame && IsStarted)
            {
                WinOrLoseDetector.LevelWinDetect();
                NextLevelInitialises();
                LevelGenerate();
                LevelObjectsMover.GameResetLocation(player.transform, ball);
            }
        }

        public static void PauseGame()
        {
            _isPaused = !_isPaused;
            if (Time.timeScale >= 1)
            {
                Time.timeScale = 0;
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
        }

        private void NextLevelInitialises()
        {
            IsStarted = false;
            LevelNumber++;
            if (LevelNumber >= LevelManageData.LevelNumber)
            {
                WinOrLoseDetector.GameWinDetect();
            }
        }

        private void LevelGenerate()
        {
            DeployedBlocks = 0;
            if (_levelNumber < LevelManageData.LevelNumber)
            {
                levelNumber.text = (LevelNumber + 1).ToString();
                _tempTransformForSpawn = grid.transform.localPosition;
                for (int i = 0; i < Level.BlockRows; i++)
                {
                    for (int j = 0; j < Level.BlockColumns; j++)
                    {
                        LevelGenerateDataSender.LevelGenerateData(LevelNumber);
                        if (LevelGenerateDataSender.TempCreatingBlock != null)
                        {
                            Instantiate(LevelGenerateDataSender.TempCreatingBlock, _tempTransformForSpawn,
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
}