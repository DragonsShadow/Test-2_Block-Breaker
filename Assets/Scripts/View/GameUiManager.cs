using Logic;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class GameUiManager : MonoBehaviour
    {
        public static GameUiManager GameUiManagerInstance;
        private string _levelName;
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
            LevelAssemble();
        }

        private void Update()
        {
            if (Input.anyKey)
            {
                PlayerMover.PlayerMovement();
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
            _tempTransformForSpawn = grid.transform.localPosition;
            for (int i = 0; i < Level.BlockRows; i++)
            {
                for (int j = 0; j < Level.BlockColumns; j++)
                {
                    LevelManager.LevelAssembleDataSend();
                    if (LevelManager.TempCreatingBlock != null)
                    {
                        Instantiate(LevelManager.TempCreatingBlock, _tempTransformForSpawn,
                            new Quaternion(0, 0, 0, 0));
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