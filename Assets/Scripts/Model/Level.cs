using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "Level", menuName = "Level", order = 2)]
    public class Level : ScriptableObject
    {
        public static int blockRows = 4;
        public static int blockColumns = 8;
        public readonly GameObject[,] Blocks = new GameObject[blockRows,blockColumns];

        
    }
}