using System;
using Logic;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class GameManager : MonoBehaviour
    {
        public static int DeployedBlocks;
        public static Touch Touch;

        public Text levelNumber;

        private static int _levelNumber;

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


        private void Awake()
        {
            SetScreenSize();
        }

        private void Start()
        {
            GenerateLevel();
            LevelObjectsMover.GameResetLocation(player.transform, ball);
        }

        private void Update()
        {
            var isInPreStart = !WinOrLoseManager.IsStarted && !WinOrLoseManager.IsFinishedGame && !_isPaused &&
                               !WinOrLoseManager.IsLose && !WinOrLoseManager.IsWinLevel;
            if (isInPreStart)
            {
                LevelObjectsMover.GameResetLocation(player.transform, ball);
                LevelObjectsMover.GameStartMove(ball);
            }

            var isContinuedAndAllowed = WinOrLoseManager.IsContinued && _levelNumber < LevelManageData.LevelNumber;
            if (isContinuedAndAllowed)
            {
                WinOrLoseManager.IsContinued = false;
                GenerateLevel();
                LevelObjectsMover.GameResetLocation(player.transform, ball);
            }
        }

        public static void DecreaseBlock()
        {
            DeployedBlocks -= 1;
            DetectWin();
        }

        private static void DetectWin()
        {
            var isFinishedMoment =
                DeployedBlocks <= 0 && !WinOrLoseManager.IsFinishedGame;
            if (isFinishedMoment)
            {
                WinOrLoseManager.DetectLevelWin();
                NextLevelInitialises();
            }
        }

        private static void NextLevelInitialises()
        {
            WinOrLoseManager.IsStarted = false;
            LevelNumber++;
            if (LevelNumber >= LevelManageData.LevelNumber)
            {
                WinOrLoseManager.DetectGameWin();
            }
        }

        public static void PauseGame()
        {
            _isPaused = GameBaseActioner.PauseGame(_isPaused);
        }

        private void GenerateLevel()
        {
            DeployedBlocks = 0;
            levelNumber.text = (LevelNumber + 1).ToString();
            _tempTransformForSpawn = grid.transform.localPosition;
            for (int i = 0; i < Level.BlockRows; i++)
            {
                for (int j = 0; j < Level.BlockColumns; j++)
                {
                    LevelGenerateDataSender.GenerateLevelData(LevelNumber);
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

            DetectWin();
        }

        private void SetScreenSize()
        {
            Screen.orientation = ScreenOrientation.Landscape;
            Screen.SetResolution(1920, 1080, true);
        }
    }
}