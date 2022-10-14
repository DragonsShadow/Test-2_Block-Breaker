using Model;
using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public class PlayerScoreChangerAndDisplayer
    {
        private static PlayerScores _playerScores = ScriptableObject.CreateInstance<PlayerScores>();

        public void PlyerScoreLoadData()
        {
            _playerScores = Resources.Load<PlayerScores>("PlayerScores/PlayerScores");
        }

        public void PlayerScoreAdd()
        {
            _playerScores.Score++;
        }

        public void PlayerStarAdd()
        {
            _playerScores.Star++;
        }

        public void PlayerScoresShow(Text score, Text star)
        {
            score.text = _playerScores.Score.ToString();
            star.text = _playerScores.Star.ToString();
        }
    }
}