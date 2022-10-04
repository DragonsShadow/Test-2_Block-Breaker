using Model;
using UnityEngine;

namespace Logic
{
    public class GameObserver
    {
        private static bool _hasResult;
        private int _allLevelObjects;
        private int _tempLevelNumber;
        private LevelManageData _levelManageData = ScriptableObject.CreateInstance<LevelManageData>();

        private void GameObserve()
        {
            _levelManageData = Resources.Load<LevelManageData>("LevelManageDatas/LevelManageData");
            while (true)
            {
                if (_allLevelObjects <= 0)
                    {
                        _allLevelObjects = Level.BlockColumns * Level.BlockRows;
                        for (int j = 0; j < Level.BlockRows; j++)
                        {
                            for (int k = 0; k < Level.BlockColumns; k++)
                            {
                                if (_levelManageData.levels[_tempLevelNumber].Blocks[j, k] == null)
                                {
                                    _allLevelObjects -= 1;
                                }
                            }
                        }
                        _tempLevelNumber++;
                    }
                    
                
            }
        }

        public static bool WinOrLoseNotify()
        {
            return _hasResult;
        }
    }
}