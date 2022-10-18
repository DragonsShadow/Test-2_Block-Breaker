using Model;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class LevelDesign : EditorWindow
    {
        private int _screenWidth = 1100;
        private int _screenLength = 250;
        private int _normalButtonWidth = 85;
        private int _normalButtonHeight = 35;
        private int _spaceBetweenTables = 20;
        public LevelManageData levelManageData;
        private int _levelNumber;

        [MenuItem("LevelDesign/LevelDesign")]
        public static void ShowWindow()
        {
            GetWindow<LevelDesign>(false, "LevelDesign", true);
        }

        private void OnEnable()
        {
            levelManageData = CreateInstance<LevelManageData>();
            levelManageData = Resources.Load<LevelManageData>("LevelManageDatas/LevelmanageData");
            position = new Rect(position.center.x, position.center.y, _screenWidth, _screenLength);
        }

        private void OnGUI()
        {
            GUILayout.BeginArea(new Rect(0, 0, 1000, 250));

            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.BeginVertical();

            GUILayout.Label("Choose your Block");
            ObjectButtonsActions();

            EditorGUILayout.EndVertical();

            EditorGUILayout.Space(_spaceBetweenTables);
            
            EditorGUILayout.BeginVertical();

            GUILayout.Label("Choose your Levels");
            LevelButtunsActions();

            EditorGUILayout.EndVertical();
            
            EditorGUILayout.Space(_spaceBetweenTables);

            EditorGUILayout.BeginVertical(GUILayout.Height(175));

            GUILayout.Label("Design your Level");

            EditorGUILayout.BeginHorizontal(GUILayout.Width(175));

            BlockButtonsActions();

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.EndVertical();

            EditorGUILayout.EndHorizontal();
            GUILayout.EndArea();
        }

        private void ObjectButtonsActions()
        {
            foreach (var gameObject in Resources.LoadAll<GameObject>("Prefabs/Blocks"))
            {
                if (GUILayout.Button(gameObject.GetComponent<SpriteRenderer>().sprite.texture,
                        GUILayout.Height(_normalButtonHeight), GUILayout.MinWidth(_normalButtonWidth)))
                {
                    Selection.activeObject = gameObject;
                }
            }

            if (GUILayout.Button("Null", GUILayout.Height(_normalButtonHeight), GUILayout.MinWidth(_normalButtonWidth)))
            {
                Selection.activeObject = null;
            }
        }

        private void LevelButtunsActions()
        {
            for (int temp = 0; temp < LevelManageData.LevelNumber; temp++)
            {
                if (GUILayout.Button("Level " + (temp + 1), GUILayout.Height(_normalButtonHeight),
                        GUILayout.MinWidth(_normalButtonWidth)))
                {
                    _levelNumber = temp;
                }
            }
        }

        private void BlockButtonsActions()
        {
            for (int y = 0; y < Level.BlockColumns; y++)
            {
                EditorGUILayout.BeginVertical();
                for (int x = 0; x < Level.BlockRows; x++)
                {
                    EditorGUILayout.BeginHorizontal();
                    if (levelManageData.levels[_levelNumber].Blocks[x, y] == null)
                    {
                        if (GUILayout.Button("Empty Block", GUILayout.Height(_normalButtonHeight),
                                GUILayout.Width(_normalButtonWidth)))
                        {
                            levelManageData.levels[_levelNumber].Blocks[x, y] = (GameObject)Selection.activeObject;
                        }
                    }
                    else
                    {
                        if (GUILayout.Button(levelManageData.levels[_levelNumber].Blocks[x, y]
                                    .GetComponent<SpriteRenderer>().sprite.texture,
                                GUILayout.Height(_normalButtonHeight),
                                GUILayout.Width(_normalButtonWidth)))
                        {
                            levelManageData.levels[_levelNumber].Blocks[x, y] = (GameObject)Selection.activeObject;
                        }
                    }

                    EditorGUILayout.EndHorizontal();
                }

                EditorGUILayout.EndVertical();
            }
        }
    }
}