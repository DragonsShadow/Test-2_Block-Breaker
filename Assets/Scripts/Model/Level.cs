using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "Level", menuName = "Level", order = 0)]
    public class Level : ScriptableObject
    {
        [SerializeField]private GameObject[] _firstRowOfBlocks = new GameObject[8];
        [SerializeField]private GameObject[] _seconRowOfBlocks = new GameObject[8];
        [SerializeField]private GameObject[] _thirdRowOfBlocks = new GameObject[8];
        [SerializeField]private GameObject[] _forthRowOfBlocks = new GameObject[8];
    }
}