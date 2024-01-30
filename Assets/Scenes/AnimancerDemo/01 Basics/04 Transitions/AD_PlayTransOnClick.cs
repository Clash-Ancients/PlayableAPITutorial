using Animancer;
using UnityEngine;

namespace Scenes.AnimDemos
{
    
    public class AD_PlayTransOnClick : MonoBehaviour
    {
        [SerializeField] ClipTransition ToClipIdle;
        [SerializeField] ClipTransition ToClipAction;
        [SerializeField] AnimancerComponent AnimanceComp;

        AnimancerState mActionState;
        
        void OnEnable()
        {
            ToClipAction.Events.OnEnd = OnActionEnd;
            AnimanceComp.Play(ToClipIdle);
        }

        void OnActionEnd()
        {
            AnimanceComp.Play(ToClipIdle);
        }
        
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(null != mActionState && mActionState.IsPlaying)
                    return;
                    
                var state = AnimanceComp.Play(ToClipAction);

                mActionState = state;
                
                state.Time = 0f;

                state.Events.OnEnd = OnEnable;
            }
        }
    }

}
