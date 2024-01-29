using UnityEngine;


namespace Soul.PlayableAPI
{
    
    public class AnimanceComponent : MonoBehaviour
    {

        public void Play(AnimationClip _clip)
        {
            Debug.LogFormat("Play, clip name:{0}", _clip.name);
        }
        
    }

}
