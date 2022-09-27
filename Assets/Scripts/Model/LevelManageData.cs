using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "LevelManageData", menuName = "LevelManageData", order = 1)]
    public class LevelManageData : ScriptableObject
    {
        public int levelNumber = 5;
        public Level[] Levels { get; }
        public LevelManageData()
        {
            Levels = new Level[levelNumber];
        }

        
    }
}