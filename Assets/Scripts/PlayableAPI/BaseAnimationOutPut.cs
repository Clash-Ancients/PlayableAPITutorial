using UnityEngine;
using UnityEngine.Playables;

namespace Test.PlayableAPI
{
    
    [RequireComponent(typeof(AnimationMixerManager))]
    public abstract class BaseAnimationOutPut : MonoBehaviour
    {

        protected AnimationMixerManager mMixerMgrInst;
        
        [SerializeField]
        protected ClipTransition ClipTransition;
        
        protected abstract Playable mPlayerInput { get; }
        
        [SerializeField]
        protected bool IsStatic = false;
        
        void Start()
        {
            mMixerMgrInst = gameObject.GetComponent<AnimationMixerManager>();
            
            if (IsStatic)
            {
                //创建clip
                CreatePlayables();
                
                mMixerMgrInst.AddStaticPlayable(mPlayerInput);
            }
        }
        
        protected abstract void CreatePlayables();
        
    }

}
