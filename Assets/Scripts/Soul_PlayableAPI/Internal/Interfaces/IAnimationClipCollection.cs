using System.Collections.Generic;
using UnityEngine;

namespace Soul.PlayableAPI
{
    
    public interface IAnimationClipCollection 
    {
        void GatherAnimationClips(ICollection<AnimationClip> clips);
    }

}