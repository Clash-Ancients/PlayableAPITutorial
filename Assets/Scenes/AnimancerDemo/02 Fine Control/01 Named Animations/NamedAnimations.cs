using System;
using Animancer;
using UnityEngine;

namespace Scenes.AnimDemos
{
    
    public class NamedAnimations : MonoBehaviour
    {

        [SerializeField] AnimationClip ToClipIdle;
        [SerializeField] AnimationClip ToClipWalk;
        [SerializeField] AnimationClip ToClipRun;

        [SerializeField] NamedAnimancerComponent NamedAnimComp;

        void Awake()
        {
            NamedAnimComp.States.Create(ToClipWalk);
        }

        public void PlayIdle()
        {
            NamedAnimComp.Play(ToClipIdle);
        }
        
        public void PlayWalk()
        {
            NamedAnimComp.TryPlay(ToClipWalk.name);
        }

        public void PlayRun()
        {
            NamedAnimComp.TryPlay(ToClipRun.name);
        }

        public void CreateRun()
        {
            NamedAnimComp.States.Create(ToClipRun);
        }

        
    }

}
