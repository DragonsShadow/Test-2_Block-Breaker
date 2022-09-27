using System;
using Model;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(Level))]
    public class CustomInspectorScriptForLevel : UnityEditor.Editor
    {
        Level _targetScript;

        void OnEnable()
        {
            _targetScript = target as Level;
        }
        [Obsolete("Obsolete")]
        public override void OnInspectorGUI()
        {
            _targetScript.BlockRows = EditorGUILayout.IntField(_targetScript.BlockRows);
            _targetScript.BlockColumns = EditorGUILayout.IntField(_targetScript.BlockColumns);

            EditorGUILayout.BeginHorizontal();
            for (int y = 0; y < _targetScript.BlockColumns; y++)
            {
                EditorGUILayout.BeginVertical();
                for (int x = 0; x < _targetScript.BlockRows; x++)
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