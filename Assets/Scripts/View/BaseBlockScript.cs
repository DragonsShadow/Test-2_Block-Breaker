using UnityEngine;

namespace View
{
    public class BaseBlockScript : MonoBehaviour
    {
        private int _health = 1;

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
                Destroy(gameObject);
            }
        }
    }
}