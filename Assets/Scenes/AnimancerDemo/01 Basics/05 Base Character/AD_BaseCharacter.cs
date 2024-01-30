using Animancer;
using UnityEngine;

namespace Scenes.AnimDemos
{
    
    public class AD_BaseCharacter : MonoBehaviour
    {
        [SerializeField] ClipTransition ToClipIdle;
        [SerializeField] ClipTransition ToClipMove;
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
            if(null != mActionState && mActionState.IsPlaying)
                return;
            
            var vertical = Input.GetAxis("Vertical");
            if (Mathf.Abs(vertical) > 0.2f)
            {
                AnimanceComp.Play(ToClipMove);
            }
            else
            {
                AnimanceComp.Play(ToClipIdle);
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                var state = AnimanceComp.Play(ToClipAction);

                mActionState = state;
                
                state.Time = 0f;
            }
        }
    }

}
