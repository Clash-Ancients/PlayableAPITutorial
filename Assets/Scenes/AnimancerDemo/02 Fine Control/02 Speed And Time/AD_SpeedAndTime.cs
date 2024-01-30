using System;
using Animancer;
using UnityEngine;

namespace Scenes.AnimDemos
{
    
    public class AD_SpeedAndTime : MonoBehaviour
    {
        [SerializeField] ClipTransition ClipTranWakeUp;
        [SerializeField] ClipTransition ClipTranRun;

        [SerializeField] AnimancerComponent AnimanceComp;
        
        //启动默认播放idle动画
        void OnEnable()
        {
            ClipTranWakeUp.Events.OnEnd = OnWakeUpOver;

            AnimanceComp.Play(ClipTranWakeUp);

            AnimanceComp.Playable.PauseGraph();
            
            AnimanceComp.Evaluate();
        }
        
        void OnWakeUpOver()
        {
            if (IsMoving)
            {
                AnimanceComp.Play(ClipTranRun);
            }
            else
            {
                AnimanceComp.Playable.PauseGraph();
            }
        }

        void WakeUp()
        {
            AnimanceComp.Playable.UnpauseGraph();
            var state = AnimanceComp.Play(ClipTranWakeUp);
            state.Speed = 1f;

            state.NormalizedTime = 0f;
        }

        void GotoSleep()
        {
            var state = AnimanceComp.Play(ClipTranWakeUp);

            state.Speed = -1f;

            state.NormalizedTime = 1f;
        }
        
        bool mIsMoving;
        
        public bool IsMoving
        {
            get => mIsMoving;
            set
            {
                if (value != mIsMoving)
                {

                    if (value)
                    {
                        //run
                        WakeUp();
                    }
                    else
                    {
                        //wake up
                        GotoSleep();
                    }
                    
                    mIsMoving = value;
                }
                
            }
        }

    }

}
