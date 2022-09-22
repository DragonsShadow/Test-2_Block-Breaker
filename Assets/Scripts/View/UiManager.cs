using Logic;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class UiManager : MonoBehaviour
    {
        public Text regularScore;
        public Text starScore;

        [SerializeField] private Animator animator;

        private int _levelNumber;

        private ScoreSetter _scoreSetter;
        private AnimationChanger _animationChanger;

        public UiManager(int levelNumber)
        {
            _levelNumber = levelNumber;
        }

        private void Start()
        {
            var scoreSetter = new ScoreSetter();
            _scoreSetter = scoreSetter;
            var animationChanger = new AnimationChanger();
            _animationChanger = animationChanger;
            _scoreSetter.RegularScoreSet(regularScore);
            _scoreSetter.StarScoreSet(starScore);
        }

        public void GameStart()
        {
            _animationChanger.StartAnimationChange(animator);
        }

        public void SettingIntraction()
        {
            _animationChanger.SettingAnimationChange(animator);
        }

        public void GameQuit()
        {
            Application.Quit();
        }
    }
}