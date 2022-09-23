using Model;
using UnityEngine;

namespace Logic
{
    public class LevelManager
    {
        private static LevelManageData _levelManageData;
        private static GameObject _tempCreatingBlock;
        private static int _tempCreatingDataBlockObjectNumber = 0;
        private static int _tempCreatingDataBlockRowNumber = 0;
        public static GameObject LevelAssembleDataSend()
        {
            _levelManageData = Resources.Load<LevelManageData>("LevelManageDatas/LevelManageData");
            if (_tempCreatingDataBlockObjectNumber >= 8)
            {
                _tempCreatingDataBlockObjectNumber = 0;
                _tempCreatingDataBlockRowNumber += 1;
            }
            _tempCreatingBlock = _levelManageData.Levels[0].Blocks[_tempCreatingDataBlockRowNumber,_tempCreatingDataBlockObjectNumber];
            _tempCreatingDataBlockObjectNumber += 1;
            
            return _tempCreatingBlock;
        }
    }
}