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

        private static readonly int StartBtn = Animator.StringToHash("Start");
        private static readonly int SettingBtn = Animator.StringToHash("Setting");

        private int _levelNumber;

        private ScoreSetter _scoreSetter;

        public UiManager(int levelNumber)
        {
            _levelNumber = levelNumber;
        }

        private void Start()
        {
            var scoreSetter = new ScoreSetter();
            _scoreSetter = scoreSetter;
            _scoreSetter.RegularScoreSet(regularScore);
            _scoreSetter.StarScoreSet(starScore);
        }

        public void GameStart()
        {
            StartAnimationChange(animator);
        }

        public void SettingIntraction()
        {
            SettingAnimationChange(animator);
        }

        public void GameQuit()
        {
            Application.Quit();
        }

        private void StartAnimationChange(Animator animator)
        {
            animator.SetBool(StartBtn, true);
            animator.SetBool(SettingBtn, false);
        }

        private void SettingAnimationChange(Animator animator)
        {
            animator.SetBool(StartBtn, false);
            animator.SetBool(SettingBtn, true);
        }
    }
}