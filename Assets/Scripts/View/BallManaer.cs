using UnityEngine;

namespace View
{
    public class BallManaer : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            AudioManager.PlayNormalColide();
        }
    }
}