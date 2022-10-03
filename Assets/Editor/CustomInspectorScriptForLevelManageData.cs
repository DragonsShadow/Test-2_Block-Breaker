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
        public override void OnInspectorGUI()
        {
            LevelManageData.levelNumber = EditorGUILayout.IntField(LevelManageData.levelNumber);
            EditorGUILayout.BeginVertical();
            for (int x = 0; x < LevelManageData.levelNumber; x++)
            {
                _targetScript.Levels[x] =
                    (Level)EditorGUILayout.ObjectField(_targetScript.Levels[x], typeof(Level) , false);
            }

            EditorGUILayout.EndVertical();
        }
    }
}