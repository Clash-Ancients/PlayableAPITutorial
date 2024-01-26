using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Soul.PlayableAPI
{
    public class AnimationClipOutPut  : BaseAnimationOutPut
    {

        public AnimationClip mClipInst;
        AnimationClipPlayable mClipPlayableInst;

        protected override Playable mPlayerInput
        {
            get => mClipPlayableInst;
        }
        protected override void CreatePlayables()
        {
            mClipPlayableInst = AnimationClipPlayable.Create(mMixerMgrInst.PlayableGraphInst, mClipInst);
            mClipPlayableInst.SetTime(0f);
        }
    }

}
