using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "LevelManageData", menuName = "LevelManageData", order = 1)]
    public class LevelManageData : ScriptableObject
    {
        public static int LevelNumber { get; }
        public Level[] Levels { get; } = new Level[LevelNumber];
    }
}