using System;
using Logic;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class MenuUiManager : MonoBehaviour
    {
        public Text score;
        public Text star;

        private PlayerScoreChangerAndDisplayer _playerScoreChangerAndDisplayer;

        [SerializeField] private Animator menuObjectsanimator;
        [SerializeField] private Animator colorAnimator;

        private static readonly int StartBtn = Animator.StringToHash("Start");
        private static readonly int SettingBtn = Animator.StringToHash("Setting");

        private void Awake()
        {
            SetScreenSize();
        }
        private void Start()
        {
            _playerScoreChangerAndDisplayer = new PlayerScoreChangerAndDisplayer();
            _playerScoreChangerAndDisplayer.LoadPlyerScoreData();
            _playerScoreChangerAndDisplayer.ShowPlayerScores(score, star);
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                BackButton();
            }
        }

        public void GameStart()
        {
            AudioManager.PlayButtonEffect();
            StartAnimationChange(menuObjectsanimator, colorAnimator);
        }

        public void SelectLevel(Text levelNumber)
        {
            AudioManager.PlayButtonEffect();
            LevelSelector.ChangeLevel(levelNumber);
        }

        public void SettingIntraction()
        {
            AudioManager.PlayButtonEffect();
            SettingAnimationChange(menuObjectsanimator);
        }

        public void GameQuit()
        {
            AudioManager.PlayButtonEffect();
            Application.Quit();
        }

        public void BackButton()
        {
            AudioManager.PlayButtonEffect();
            BackFromMenusAnimationChange(menuObjectsanimator, colorAnimator);
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

        private void SetScreenSize()
        {
            Screen.orientation = ScreenOrientation.Landscape;
            Screen.SetResolution(1920, 1080, true);
        }
    }
}