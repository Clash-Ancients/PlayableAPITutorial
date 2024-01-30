using Animancer;
using UnityEngine;

namespace Scenes.AnimDemos
{
    
    public class AD_AnimOnClick : MonoBehaviour
    {
        [SerializeField] AnimationClip ToClipIdle;
        [SerializeField] AnimationClip ToClipAction;
        [SerializeField] AnimancerComponent AnimanceComp;

        AnimancerState mJumpState;
        
        void OnEnable()
        {
            AnimanceComp.Play(ToClipIdle);
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
             
                if(null != mJumpState && mJumpState.IsPlaying)
                    return;
                    
                var state = AnimanceComp.Play(ToClipAction);

                mJumpState = state;
                    
                   
                
                state.Time = 0f;

                state.Events.OnEnd = OnEnable;
            }
           
        }
    }

}
