using System;
using Model;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(Level))]
    public class CustomScriptInscpector : UnityEditor.Editor
    {
        Level _targetScript;

        void OnEnable()
        {
            _targetScript = target as Level;
        }

        [Obsolete("Obsolete")]
        public override void OnInspectorGUI()
        {
            Level.BlockRows = EditorGUILayout.IntField(Level.BlockRows);
            Level.BlockColumns = EditorGUILayout.IntField(Level.BlockColumns);

            EditorGUILayout.BeginHorizontal();
            for (int y = 0; y < Level.BlockColumns; y++)
            {
                EditorGUILayout.BeginVertical();
                for (int x = 0; x < Level.BlockRows; x++)
                {
                    _targetScript.Blocks[x, y] =
                        (GameObject)EditorGUILayout.ObjectField(_targetScript.Blocks[x, y], typeof(GameObject));
                }

                EditorGUILayout.EndVertical();
            }

            EditorGUILayout.EndHorizontal();
        }
    }
}