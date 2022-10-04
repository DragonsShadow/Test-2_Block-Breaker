using Logic;
using Model;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

namespace View
{
    public class UiManager : MonoBehaviour
    {
        public Text score;
        public Text star;
        private PlayerScores _score = new PlayerScores();
        [SerializeField] private Animator animator;

        private static readonly int StartBtn = Animator.StringToHash("Start");
        private static readonly int SettingBtn = Animator.StringToHash("Setting");

        private int _levelNumber;

        public UiManager(int levelNumber)
        {
            _levelNumber = levelNumber;
        }

        private void Start()
        {
            ScoreTextSette();
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

        private void ScoreTextSette()
        {
            _score = Resources.Load<PlayerScores>("PLayerScores/PLayerScores");
            score.text = _score.Score.ToString();
            star.text = _score.Star.ToString();
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