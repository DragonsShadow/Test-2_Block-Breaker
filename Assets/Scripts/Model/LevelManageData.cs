using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "LevelManageData", menuName = "LevelManageData", order = 1)]
    public class LevelManageData : ScriptableObject
    {
        public static int LevelNumber = 5;
        public Level[] levels = new Level[LevelNumber];
    }
}