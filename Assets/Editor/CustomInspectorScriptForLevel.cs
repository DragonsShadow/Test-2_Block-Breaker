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
        public override void OnInspectorGUI()
        {
            _targetScript.blockRows = EditorGUILayout.IntField(_targetScript.blockRows);
            _targetScript.blockColumns = EditorGUILayout.IntField(_targetScript.blockColumns);

            EditorGUILayout.BeginHorizontal();
            for (int y = 0; y < _targetScript.blockColumns; y++)
            {
                EditorGUILayout.BeginVertical();
                for (int x = 0; x < _targetScript.blockRows; x++)
                {
                    _targetScript.Blocks[x, y] =
                        (GameObject)EditorGUILayout.ObjectField(_targetScript.Blocks[x, y], typeof(GameObject), true);
                    
                }

                EditorGUILayout.EndVertical();
            }

            EditorGUILayout.EndHorizontal();
        }
    }
}