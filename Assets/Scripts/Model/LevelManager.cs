using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "LevelManager", menuName = "LevelManager", order = 0)]
    public class LevelManager : ScriptableObject
    {
        public static int LevelNumber ;
        [SerializeField]private Level[] _levels = new Level[LevelNumber];
    }
}
