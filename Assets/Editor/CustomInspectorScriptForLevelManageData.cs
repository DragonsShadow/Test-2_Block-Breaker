// using Model;
// using UnityEditor;
//
// namespace Editor
// {
//     [CustomEditor(typeof(LevelManageData))]
//     public class CustomInspectorScriptForLevelManageData : UnityEditor.Editor
//     {
//         LevelManageData _targetScript;
//
//         void OnEnable()
//         {
//             _targetScript = target as LevelManageData;
//         }
//         public override void OnInspectorGUI()
//         {
//             base.OnInspectorGUI();
//             LevelManageData.LevelNumber = EditorGUILayout.IntField(LevelManageData.LevelNumber);
//             EditorGUILayout.BeginVertical();
//             for (int x = 0; x < LevelManageData.LevelNumber; x++)
//             {
//                 _targetScript.levels[x] =
//                     (Level)EditorGUILayout.ObjectField(_targetScript.levels[x], typeof(Level) , false);
//             }
//
//             EditorGUILayout.EndVertical();
//         }
//     }
// }