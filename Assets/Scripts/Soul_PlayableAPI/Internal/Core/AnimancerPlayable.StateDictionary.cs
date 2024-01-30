using System.Collections.Generic;
using UnityEngine;

namespace Soul.PlayableAPI
{
    public partial class AnimancerPlayable
    {
        public class StateDictionary:IAnimationClipCollection
        {
            
            AnimancerPlayable mRoot;
            
            internal StateDictionary(AnimancerPlayable _root)
            {
                mRoot = _root;
            }
            
            public void GatherAnimationClips(ICollection<AnimationClip> clips)
            {
                
            }
        }

    }
}
