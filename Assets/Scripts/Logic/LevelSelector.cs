using UnityEngine.SceneManagement;
using UnityEngine.UI;
using View;

namespace Logic
{
    public class LevelSelector 
    {
        public static void Levechange(Text level)
        {
            GameManager.LevelNumber = int.Parse(level.text) - 1;
            SceneManager.LoadScene("Scenes/MainGame");
        }
    }
}