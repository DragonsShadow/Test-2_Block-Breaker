using Model;
using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public class ScoreSetter
    {
        private static PlayerScores _playerScores;

        public void RegularScoreSet(Text regularScore)
        {
            _playerScores = Resources.Load<PlayerScores>("Scores/PlayerScores");
            regularScore.text = _playerScores.Score.ToString();
        }

        public void StarScoreSet(Text starScore)
        {
            _playerScores = Resources.Load<PlayerScores>("Scores/PlayerScores");
            starScore.text = _playerScores.Star.ToString();
        }
    }
}