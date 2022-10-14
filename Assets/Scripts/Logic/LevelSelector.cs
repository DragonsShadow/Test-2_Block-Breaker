using UnityEngine.SceneManagement;
using UnityEngine.UI;
using View;

namespace Logic
{
    public class LevelSelector 
    {
        public static void Levechange(Text level)
        {
            GameUiManager.LevelNumber = int.Parse(level.text) - 1;
            SceneManager.LoadScene("Scenes/MainGame");
        }
    }
}