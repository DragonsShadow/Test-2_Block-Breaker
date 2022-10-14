using Logic;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class GameManager : MonoBehaviour
    {
        public static int DeployedBlocks;

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


        private void Start()
        {
            LevelGenerate();
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

            var isFinishedMoment =
                DeployedBlocks <= 0 && !WinOrLoseManager.IsFinishedGame && WinOrLoseManager.IsStarted;
            if (isFinishedMoment)
            {
                WinOrLoseManager.LevelWinDetect();
                NextLevelInitialises();
            }

            if (WinOrLoseManager.IsContinued && _levelNumber < LevelManageData.LevelNumber)
            {
                WinOrLoseManager.IsContinued = false;
                LevelGenerate();
                LevelObjectsMover.GameResetLocation(player.transform, ball);
            }
        }

        private void NextLevelInitialises()
        {
            WinOrLoseManager.IsStarted = false;
            LevelNumber++;
            if (LevelNumber >= LevelManageData.LevelNumber)
            {
                WinOrLoseManager.GameWinDetect();
            }
        }

        public static void PauseGame()
        {
            _isPaused = GameBaseActioner.GamePause(_isPaused);
        }

        private void LevelGenerate()
        {
            DeployedBlocks = 0;
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