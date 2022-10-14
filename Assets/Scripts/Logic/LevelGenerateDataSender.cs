using Model;
using UnityEngine;

namespace Logic
{
    public class LevelGenerateDataSender
    {
        private static LevelManageData _levelManageData;
        public static GameObject TempCreatingBlock;
        private static int _tempCreatingDataBlockObjectNumber;
        private static int _tempCreatingDataBlockRowNumber;

        public static void LevelGenerateData(int levelNumber)
        {
            _levelManageData = ScriptableObject.CreateInstance<LevelManageData>();
            _levelManageData = Resources.Load<LevelManageData>("LevelManageDatas/LevelManageData");
            if (_tempCreatingDataBlockObjectNumber >= Level.BlockColumns)
            {
                _tempCreatingDataBlockObjectNumber = 0;
                _tempCreatingDataBlockRowNumber += 1;
            }

            if (_tempCreatingDataBlockRowNumber >= Level.BlockRows)
            {
                _tempCreatingDataBlockRowNumber = 0;
            }

            TempCreatingBlock = _levelManageData.levels[levelNumber]
                .Blocks[_tempCreatingDataBlockRowNumber, _tempCreatingDataBlockObjectNumber];
            _tempCreatingDataBlockObjectNumber += 1;
        }
    }
}