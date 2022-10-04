using Model;
using UnityEngine;

namespace Logic
{
    public class LevelManager
    {
        private static LevelManageData _levelManageData;
        public static GameObject TempCreatingBlock;
        private static int _tempCreatingDataBlockObjectNumber ;
        private static int _tempCreatingDataBlockRowNumber ;

        public static void LevelAssembleDataSend()
        {
            _levelManageData = ScriptableObject.CreateInstance<LevelManageData>();
            _levelManageData = Resources.Load<LevelManageData>("LevelManageDatas/LevelManageData");
            if (_tempCreatingDataBlockObjectNumber >= 8)
            {
                _tempCreatingDataBlockObjectNumber = 0;
                _tempCreatingDataBlockRowNumber += 1;
            }
            TempCreatingBlock = _levelManageData.levels[0].Blocks[_tempCreatingDataBlockRowNumber,_tempCreatingDataBlockObjectNumber];
            _tempCreatingDataBlockObjectNumber += 1;
            
        }
    }
}