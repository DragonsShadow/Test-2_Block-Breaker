using Model;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public class PlayerScoreChangerAndDisplayer
    {
        private PlayerScores _playerScores;

        public void PlyerScoreLoadData()
        {
            _playerScores = Resources.Load<PlayerScores>("PlayerScores/PlayerScores");
        }

        public void PlayerScoreAdd()
        {
            _playerScores.Score++;
            EditorUtility.SetDirty(_playerScores);
        }

        public void PlayerStarAdd()
        {
            _playerScores.Star++;
            EditorUtility.SetDirty(_playerScores);
        }

        public void PlayerScoresShow(Text score, Text star)
        {
            score.text = _playerScores.Score.ToString();
            star.text = _playerScores.Star.ToString();
        }
    }
}