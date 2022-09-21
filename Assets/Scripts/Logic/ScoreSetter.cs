using Model;
using UnityEngine;

namespace Logic
{
    public class ScoreSetter
    {
        private PlayerScores _playerScores;

        void RegularScoreSet(int regularScore)
        {
            _playerScores = Resources.Load<PlayerScores>("Scores/PlayerScores");
            regularScore = _playerScores.RegularScore;
        }

        void StarScoreSet(int starScore)
        {
            _playerScores = Resources.Load<PlayerScores>("Scores/PlayerScores");
            starScore = _playerScores.StarScore;
        }
    }
}