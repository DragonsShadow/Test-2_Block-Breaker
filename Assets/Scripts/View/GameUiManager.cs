using Logic;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class GameUiManager : MonoBehaviour
    {
        public static GameUiManager GameUiManagerInstance;
        public int deployedBlocks;
        private string _levelName;
        private int _levelNumber;
        [SerializeField]private Transform player;
        [SerializeField] private Text playerWinOrLoseMessage;
        [SerializeField] private GameObject playerWinOrLoseMessageObject;
        [SerializeField] private Grid grid;
        private Vector3 _tempTransformForSpawn = new Vector3(0, 0, 0);

        private void Awake()
        {
            if (GameUiManagerInstance != null && GameUiManagerInstance != this)
            {
                Destroy(this);
            }
            else
            {
                GameUiManagerInstance = this;
            }
        }

        private void Start()
        {
            LevelGenerate();
        }

        private void Update()
        {
            if (Input.anyKey)
            {
                PlayerMover.PlayerMovement(player);
            }

            if (deployedBlocks <= 0)
            {
                _levelNumber++;
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
                        deployedBlocks++;
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