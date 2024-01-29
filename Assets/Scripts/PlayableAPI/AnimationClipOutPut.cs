using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Test.PlayableAPI
{
    public class AnimationClipOutPut  : BaseAnimationOutPut
    {

        public AnimationClip toClipInst;
        AnimationClipPlayable mClipPlayableInst;
        
        public int LayerIndex;
        
        protected override Playable mPlayerInput
        {
            get => mClipPlayableInst;
        }
        
        protected override void CreatePlayables()
        {
            mClipPlayableInst = AnimationClipPlayable.Create(mMixerMgrInst.PGInst, toClipInst);
            mClipPlayableInst.SetTime(0f);
        }

        public void OnBtnClickPlay()
        {
            if (!IsStatic)
            {
                CreatePlayables();
                mMixerMgrInst.PlayDynamicPlayable(mPlayerInput, ClipTransition, LayerIndex);
            }
        }

        public void Play()
        {   
            if (!IsStatic)
            {
                CreatePlayables();
                mMixerMgrInst.PlayDynamicPlayable(mPlayerInput, ClipTransition, LayerIndex);
            }
        }
    }
}
