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
            Level.blockRows = EditorGUILayout.IntField(Level.blockRows);
            Level.blockColumns = EditorGUILayout.IntField(Level.blockColumns);

            EditorGUILayout.BeginHorizontal();
            for (int y = 0; y < Level.blockColumns; y++)
            {
                EditorGUILayout.BeginVertical();
                for (int x = 0; x < Level.blockRows; x++)
                {
                    _targetScript.Blocks[x, y] =
                        (GameObject)EditorGUILayout.ObjectField(_targetScript.Blocks[x, y], typeof(GameObject), false);
                    
                }

                EditorGUILayout.EndVertical();
            }

            EditorGUILayout.EndHorizontal();
        }
    }
}