using UnityEngine;

namespace Logic
{
    public class AnimationChanger
    {
        private static readonly int Start = Animator.StringToHash("Start");
        private static readonly int Setting = Animator.StringToHash("Setting");

        public void StartAnimationChange(Animator animator)
        {
            animator.SetBool(Start, true);
            animator.SetBool(Setting, false);
        }

        public void SettingAnimationChange(Animator animator)
        {
            animator.SetBool(Start, false);
            animator.SetBool(Setting, true);
        }
    }
}