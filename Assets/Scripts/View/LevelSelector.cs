using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace View
{
    public class LevelSelector : MonoBehaviour
    {
        public void Levechange(Text level)
        {
            GameUiManager.LevelNumber = int.Parse(level.text) - 1;
            SceneManager.LoadScene("Scenes/MainGame");
        }
    }
}