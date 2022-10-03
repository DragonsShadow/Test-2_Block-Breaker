using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "Level", menuName = "Level", order = 2)]
    public class Level : ScriptableObject
    {
        public static int BlockRows = 4;
        public static int BlockColumns = 8;
        public readonly GameObject[,] Blocks = new GameObject[BlockRows,BlockColumns];

        
    }
}