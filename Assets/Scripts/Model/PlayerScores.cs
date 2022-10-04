using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "PlayerScores", menuName = "PlayerScores", order = 0)]
    public class PlayerScores : ScriptableObject
    {
        private int _score;
        //score based on destroyed blocks

        private int _star;
        //score based on past levels

        public int Score
        {
            get => _score;
            set => _score = value;
        }

        public int Star
        {
            get => _star;
            set => _star = value;
        }
    }
}