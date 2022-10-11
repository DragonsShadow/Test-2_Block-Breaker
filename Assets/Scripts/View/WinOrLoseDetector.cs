
using UnityEngine;

namespace View
{
    public class WinOrLoseDetector : MonoBehaviour
    {
        private bool _isLose;
        private static bool _isWinLevel;
        private static bool _isFinishedGame;
        
        public Rigidbody2D ball;
        public GameObject background;

        public static void GameWinDetect()
        {
            _isFinishedGame = true;
        }
        public static void LevelWinDetect()
        {
            _isWinLevel = true;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("Ground"))
            {
                _isLose = true;
            }
        }

        private void Update()
        {
            if (_isLose)
            {
                background.SetActive(true);
                
            }
            if (_isWinLevel)
            {
                background.SetActive(true);
                
            }
            if (_isFinishedGame)
            {
                background.SetActive(true);
                
            }
        }
    }
}