using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "LevelManageData", menuName = "LevelManageData", order = 0)]
    public class LevelManageData : ScriptableObject
    {
        public static int LevelNumber ;
        [SerializeField]private Level[] _levels = new Level[LevelNumber];
    }
}
