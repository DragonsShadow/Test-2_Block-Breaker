using Model;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class LevelDesign : EditorWindow
    {
        private int _screenWidth = 1500;
        private int _screenLength = 1100;
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
            EditorGUILayout.BeginHorizontal();
            
            EditorGUILayout.BeginVertical();

            ObjectButtonsActions();

            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical();

            LevelButtunsActions();

            EditorGUILayout.EndVertical();

            BlockButtonsActions();

            EditorGUILayout.EndHorizontal();
        }

        private void ObjectButtonsActions()
        {
            foreach (var gameObject in Resources.LoadAll<GameObject>("Prefabs/Blocks"))
            {
                if (GUILayout.Button(gameObject.GetComponent<SpriteRenderer>().sprite.texture))
                {
                    Selection.activeObject = gameObject;
                }
            }
        }

        private void LevelButtunsActions()
        {
            for (int temp = 0; temp < LevelManageData.LevelNumber; temp++)
            {
                if (GUILayout.Button("Level " + (temp + 1).ToString()))
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
                    if (levelManageData.levels[_levelNumber].Blocks[x, y] == null)
                    {
                        if (GUILayout.Button("Block " + ((y + 1) * (x + 1))))
                        {
                            levelManageData.levels[_levelNumber].Blocks[x, y] = (GameObject)Selection.activeObject;
                        }
                    }
                    else
                    {
                        if (GUILayout.Button(levelManageData.levels[_levelNumber].Blocks[x, y]
                                .GetComponent<SpriteRenderer>().sprite.texture))
                        {
                            levelManageData.levels[_levelNumber].Blocks[x, y] = (GameObject)Selection.activeObject;
                        }
                    }
                }

                EditorGUILayout.EndVertical();
            }
        }
    }
}