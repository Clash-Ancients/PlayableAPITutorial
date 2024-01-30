using System;
using Animancer;
using UnityEngine;

namespace Scenes.AnimDemos
{
    
    public class AD_BasicMove : MonoBehaviour
    {
        [SerializeField] AnimationClip ToClipIdle;
        [SerializeField] AnimationClip ToClipWalk;
        [SerializeField] AnimancerComponent AnimanceComp;

        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                AnimanceComp.Play(ToClipWalk);
            }
            else
            {
                AnimanceComp.Play(ToClipIdle);
            }
        }
    }

}
