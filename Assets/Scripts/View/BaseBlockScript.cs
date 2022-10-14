using Logic;
using UnityEngine;

namespace View
{
    public class BaseBlockScript : MonoBehaviour
    {
        private int _health = 1;
        private PlayerScoreChangerAndDisplayer _playerScoreChangerAndDisplayer;

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.tag.Equals("Ball"))
            {
                _health -= 1;
                GameUiManager.DeployedBlocks -= 1;
                DestroyCheck();
            }
        }

        void DestroyCheck()
        {
            if (_health <= 0)
            {
                AddToScore();
                Destroy(gameObject);
            }
        }

        void AddToScore()
        {
            _playerScoreChangerAndDisplayer = new PlayerScoreChangerAndDisplayer();
            _playerScoreChangerAndDisplayer.PlyerScoreDetect();
            _playerScoreChangerAndDisplayer.PlayerScoreAdd();
        }
    }
}