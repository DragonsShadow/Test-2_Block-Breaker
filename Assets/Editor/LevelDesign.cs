using Model;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class LevelDesign : EditorWindow
    {
        private int _screenWidth = 1500;
        private int _screenLength = 1100;
        public LevelManageData _levelManageData;

        [MenuItem("LevelDesign/LevelDesign")]
        public static void ShowWindow()
        {
            GetWindow<LevelDesign>(false, "LevelDesign", true);
        }

        private void OnEnable()
        {
            _levelManageData = CreateInstance<LevelManageData>();
            _levelManageData = Resources.Load<LevelManageData>("LevelManageDatas/LevelmanageData");
            position = new Rect(position.center.x, position.center.y, _screenWidth, _screenLength);
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.BeginVertical();
            foreach (var gameObject in Resources.LoadAll<GameObject>("Prefabs/Blocks"))
            {
                GUILayout.Button(gameObject.GetComponent<SpriteRenderer>().sprite.texture);
            }

            EditorGUILayout.EndVertical();
            EditorGUILayout.BeginVertical();
            for (int temp = 0; temp < LevelManageData.LevelNumber; temp++)
            {
                GUILayout.Button((temp + 1).ToString());
            }
            EditorGUILayout.EndVertical();
            for (int y = 0; y < Level.BlockColumns; y++)
            {
                EditorGUILayout.BeginVertical();
                for (int x = 0; x < Level.BlockRows; x++)
                {
                    GUILayout.Button("Blcok "+((y+1)*(x+1)));
                }

                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}