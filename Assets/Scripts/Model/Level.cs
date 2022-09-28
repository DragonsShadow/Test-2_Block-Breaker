using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "Level", menuName = "Level", order = 2)]
    public class Level : ScriptableObject
    {
        public int blockRows = 4;
        public  int blockColumns = 8;
        public readonly GameObject[,] Blocks;

        public Level()
        {
            Blocks = new GameObject[blockRows,blockColumns];
        }
    }
}