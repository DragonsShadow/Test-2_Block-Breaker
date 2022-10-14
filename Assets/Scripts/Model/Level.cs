using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Model
{
    [CreateAssetMenu(fileName = "Level", menuName = "Level", order = 2)]
    public class Level : ScriptableObject, ISerializationCallbackReceiver
    {
        public static int BlockRows = 4;
        public static int BlockColumns = 8;
        public GameObject[,] Blocks = new GameObject[BlockRows, BlockColumns];


        [SerializeField, HideInInspector] private List<BlockObjectRows> tempBlocks;

        [Serializable]
        private class BlockObjectRows
        {
            [FormerlySerializedAs("Blocks")] public List<GameObject> blocks = new List<GameObject>();
        }

        public void OnBeforeSerialize()
        {
            // convert Blocks to _tempBlocks

            tempBlocks = new List<BlockObjectRows>();
            for (int i = 0; i < BlockRows; i++)
            {
                tempBlocks.Add(new BlockObjectRows());
                for (int j = 0; j < BlockColumns; j++)
                {
                    tempBlocks[i].blocks.Add(Blocks[i, j]);
                }
            }

            //only premetive types gets dirty automatically
            EditorUtility.SetDirty(this);
        }

        public void OnAfterDeserialize()
        {
            //convert _tempBlocks to Blocks

            for (int i = 0; i < BlockRows; i++)
            {
                for (int j = 0; j < BlockColumns; j++)
                {
                    Blocks[i, j] = tempBlocks[i].blocks[j];
                }
            }
        }
    }
}