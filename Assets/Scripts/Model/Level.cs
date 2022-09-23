using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "Level", menuName = "Level", order = 2)]
    public class Level : ScriptableObject
    {
        public readonly GameObject[,] Blocks = new GameObject[4,8];
    }
}