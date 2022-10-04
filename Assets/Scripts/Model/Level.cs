using System;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "Level", menuName = "Level", order = 2)]
    public class Level : ScriptableObject, ISerializationCallbackReceiver
    {
        public static int BlockRows = 4;
        public static int BlockColumns = 8;
        public GameObject[,] Blocks = new GameObject[BlockRows, BlockColumns];


        [SerializeField, HideInInspector] private List<BlockObjectRows> _tempBlocks;

        [Serializable]
        private class BlockObjectRows
        {
            public List<GameObject> Blocks = new List<GameObject>();
        }

        public void OnBeforeSerialize()
        {
            Debug.Log("OnBeforeSerialize Called");

            // convert Blocks to _tempBlocks
            _tempBlocks = new List<BlockObjectRows>();
            for (int i = 0; i < BlockRows; i++)
            {
                _tempBlocks.Add(new BlockObjectRows());
                for (int j = 0; j < BlockColumns; j++)
                {
                    _tempBlocks[i].Blocks.Add(Blocks[i, j]);
                }
            }
        }

        public void OnAfterDeserialize()
        {
            Debug.Log("OnAfterDeserialize Called");

            //convert _tempBlocks to Blocks
            for (int i = 0; i < BlockRows; i++)
            {
                for (int j = 0; j < BlockColumns; j++)
                {
                    Blocks[i, j] = _tempBlocks[i].Blocks[j];
                }
            }
        }
    }
}