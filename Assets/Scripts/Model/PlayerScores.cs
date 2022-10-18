using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "PlayerScores", menuName = "PlayerScores", order = 0)]
    public class PlayerScores : ScriptableObject
    {
        [SerializeField, HideInInspector] private int score;
        //score based on destroyed blocks

        [SerializeField, HideInInspector] private int star;
        //score based on past levels


        public int Score
        {
            get => score;
            set => score = value;
        }

        public int Star
        {
            get => star;
            set => star = value;
        }
    }
}