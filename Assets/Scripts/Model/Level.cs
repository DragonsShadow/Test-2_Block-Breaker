using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "Level", menuName = "Level", order = 2)]
    public class Level : ScriptableObject
    {
        public int BlockRows = 4;
        public  int BlockColumns = 8;
        public readonly GameObject[,] Blocks;

        public Level()
        {
            Blocks = new GameObject[BlockRows,BlockColumns];
        }
    }
}