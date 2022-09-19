using UnityEngine;

namespace Model
{
    public class PlayerScores : ScriptableObject
    {
        private int _regularScore;
        //score based on destroyed blocks
        private int _starScore;
        //score based on past levels
        public int RegularScore
        {
            get => _regularScore;
            set => _regularScore = value;
        }

        public int StarScore
        {
            get => _starScore;
            set => _starScore = value;
        }
    }
}
