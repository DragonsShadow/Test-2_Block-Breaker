using Logic;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class GameUiManager : MonoBehaviour
    {
        public static int DeployedBlocks;
        private string _levelName;
        private int _levelNumber;
        private bool _isStarted = false;
        [SerializeField] private Transform player;
        [SerializeField] private Rigidbody2D ball;
        [SerializeField] private Text playerWinOrLoseMessage;
        [SerializeField] private GameObject playerWinOrLoseMessageObject;
        [SerializeField] private Grid grid;
        private Vector3 _tempTransformForSpawn = new Vector3(0, 0, 0);


        private void Start()
        {
            LevelGenerate();
            GameObjectsMover.GameReset(player.transform, ball);
        }

        private void Update()
        {
            if (!_isStarted)
            {
                _isStarted = GameObjectsMover.GameStart(ball);
            }

            if (Input.anyKey && _isStarted)
            {
                GameObjectsMover.PlayerMovement(player);
            }

            if (DeployedBlocks <= 0)
            {
                _isStarted = false;
                GameObjectsMover._isStarted = false;
                _levelNumber += 1;
                GameObjectsMover.GameReset(player.transform, ball);
                LevelGenerate();
                
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

        private void LevelGenerate()
        {
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