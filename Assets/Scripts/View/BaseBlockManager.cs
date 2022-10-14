using Logic;
using UnityEngine;

namespace View
{
    public class BaseBlockManager : MonoBehaviour
    {
        private int _blockHealth = 1;
        private PlayerScoreChangerAndDisplayer _playerScoreChangerAndDisplayer;

        private void OnCollisionEnter2D(Collision2D block)
        {
            if (block.collider.tag.Equals("Ball"))
            {
                _blockHealth -= 1;
                GameUiManager.DeployedBlocks -= 1;
                DestroyCheck();
            }
        }

        void DestroyCheck()
        {
            if (_blockHealth <= 0)
            {
                AddToScore();
                Destroy(gameObject);
            }
        }

        void AddToScore()
        {
            _playerScoreChangerAndDisplayer = new PlayerScoreChangerAndDisplayer();
            _playerScoreChangerAndDisplayer.PlyerScoreLoadData();
            _playerScoreChangerAndDisplayer.PlayerScoreAdd();
        }
    }
}