using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "LevelManageData", menuName = "LevelManageData", order = 1)]
    public class LevelManageData : ScriptableObject
    {
        public static int levelNumber = 5;
        public Level[] Levels = new Level[levelNumber];
    }
}