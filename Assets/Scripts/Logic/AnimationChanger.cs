using UnityEngine;

namespace Logic
{
    public class AnimationChanger
    {
        private static readonly int Start = Animator.StringToHash("Start");
        private static readonly int Setting = Animator.StringToHash("Setting");

        void StartAnimationChange(Animator animator)
        {
            animator.SetBool(Start, true);
        }

        void SettingAnimationChange(Animator animator)
        {
            animator.SetBool(Setting, true);
        }
    }
}