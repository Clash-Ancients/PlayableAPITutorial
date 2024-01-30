using UnityEngine;


namespace Soul.PlayableAPI
{
    
    public partial class AnimanceComponent : MonoBehaviour, IAnimancerComponent
    {

        AnimancerPlayable mPlayable;

        Animator mAnimator;
        
        public AnimancerPlayable Playable
        {
            get
            {
                OnInitializePlayable();
                return mPlayable;
            }
        }

        void OnInitializePlayable()
        {
            if(null != mPlayable)
                return;

            mAnimator = gameObject.GetComponentInChildren<Animator>();
            
            //创建AnimancerPlayable
            mPlayable = AnimancerPlayable.Create();

            mPlayable.CreateOutput(mAnimator, this);
        }
        
        public void Play(AnimationClip _clip)
        {
            Debug.LogFormat("Play, clip name:{0}", _clip.name);
            
            Playable.Play();
        }
        
    }

}
