using UnityEngine;
using UnityEngine.Playables;

namespace Soul.PlayableAPI
{
    
    [RequireComponent(typeof(AnimationMixerManager))]
    public abstract class BaseAnimationOutPut : MonoBehaviour
    {

        protected AnimationMixerManager mMixerMgrInst;
        
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
