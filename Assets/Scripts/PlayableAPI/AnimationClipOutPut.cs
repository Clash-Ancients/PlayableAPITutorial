using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Soul.PlayableAPI
{
    public class AnimationClipOutPut  : BaseAnimationOutPut
    {

        public AnimationClip mClipInst;
        AnimationClipPlayable mClipPlayableInst;
        
        public int LayerIndex = 0;
        
        protected override Playable mPlayerInput
        {
            get => mClipPlayableInst;
        }
        
        protected override void CreatePlayables()
        {
            mClipPlayableInst = AnimationClipPlayable.Create(mMixerMgrInst.PGInst, mClipInst);
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
    }
}
