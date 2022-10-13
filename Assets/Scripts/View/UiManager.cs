using Model;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class UiManager : MonoBehaviour
    {
        public Text score;
        public Text star;
        private PlayerScores _score;
        [SerializeField] private Animator menuObjectsanimator;
        [SerializeField] private Animator colorAnimator;

        private static readonly int StartBtn = Animator.StringToHash("Start");
        private static readonly int SettingBtn = Animator.StringToHash("Setting");

        private void Start()
        {
            _score = ScriptableObject.CreateInstance<PlayerScores>();
            ScoreTextSette();
        }

        public void GameStart()
        {
            StartAnimationChange(menuObjectsanimator, colorAnimator);
        }

        public void SettingIntraction()
        {
            SettingAnimationChange(menuObjectsanimator);
        }

        public void GameQuit()
        {
            Application.Quit();
        }

        public void BackButton()
        {
            BackFromMenusAnimationChange(menuObjectsanimator, colorAnimator);
        }

        private void ScoreTextSette()
        {
            _score = Resources.Load<PlayerScores>("PLayerScores/PLayerScores");
            score.text = _score.Score.ToString();
            star.text = _score.Star.ToString();
        }

        private void StartAnimationChange(Animator animator, Animator backgroundAnimator)
        {
            animator.SetBool(StartBtn, true);
            backgroundAnimator.SetBool(StartBtn, true);
            animator.SetBool(SettingBtn, false);
        }

        private void SettingAnimationChange(Animator animator)
        {
            animator.SetBool(StartBtn, false);
            animator.SetBool(SettingBtn, true);
        }

        private void BackFromMenusAnimationChange(Animator animator, Animator backgroundAnimator)
        {
            animator.SetBool(StartBtn, false);
            backgroundAnimator.SetBool(StartBtn, false);
            animator.SetBool(SettingBtn, false);
        }
    }
}