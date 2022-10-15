using Model;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class LevelDesign : EditorWindow
    {
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
            position = new Rect(100,100,500,100);
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginVertical();
            EditorGUILayout.ObjectField(Resources.Load<GameObject>("Prefabs/Blocks/Normal-Block"), typeof(GameObject), false);
            EditorGUILayout.ObjectField(Resources.Load<GameObject>("Prefabs/Blocks/Bomb-Block"), typeof(GameObject), false);
            EditorGUILayout.EndVertical();
            
        }
    }
}