using System;
using Model;
using UnityEditor;

namespace Editor
{
    [CustomEditor(typeof(LevelManageData))]
    public class CustomInspectorScriptForLevelManageData : UnityEditor.Editor
    {
        LevelManageData _targetScript;

        void OnEnable()
        {
            _targetScript = target as LevelManageData;
        }

        [Obsolete("Obsolete")]
        public override void OnInspectorGUI()
        {
            _targetScript.levelNumber = EditorGUILayout.IntField(_targetScript.levelNumber);
            EditorGUILayout.BeginVertical();
            for (int x = 0; x < _targetScript.levelNumber; x++)
            {
                _targetScript.Levels[x] =
                    (Level)EditorGUILayout.ObjectField(_targetScript.Levels[x], typeof(Level));
            }

            EditorGUILayout.EndVertical();
        }
    }
}