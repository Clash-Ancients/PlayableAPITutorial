using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Soul.PlayableAPI
{
    public class AnimationMixerManager : MonoBehaviour
    {

        PlayableGraph mPlayableGraphInst;
        public PlayableGraph PlayableGraphInst => mPlayableGraphInst;

        Animator mAnimatorInst;

        AnimationLayerMixerPlayable mRootAnimLayerMixerPlayableInst;

        AnimationPlayableOutput mAnimPlayableOutPutInst;

        AnimationMixerPlayable mAnimMixerPlayableInst;
        
        void Awake()
        {
            mAnimatorInst = gameObject.GetComponentInChildren<Animator>();
            
            //创建PlayableGraph - 管理多个Playable的结构
            mPlayableGraphInst = PlayableGraph.Create(gameObject.name + "AnimMixerManager");

            //创建AnimationOutPut
            mAnimPlayableOutPutInst = AnimationPlayableOutput.Create(mPlayableGraphInst, "AnimatioinOutPut", mAnimatorInst);
            
            //创建AnimationLayerMixerPlayable
            mRootAnimLayerMixerPlayableInst = AnimationLayerMixerPlayable.Create(mPlayableGraphInst, 0);
            
            //将mRootAnimLayerMixerPlayableInst连接在mAnimPlayableOutPutInst后面
            mAnimPlayableOutPutInst.SetSourcePlayable(mRootAnimLayerMixerPlayableInst, 0);
            
            //设置右侧的输入数量
            mRootAnimLayerMixerPlayableInst.SetInputCount(1);
            
            mPlayableGraphInst.Stop();
            
            //创建AnimationMixerPlayable,并且设置右侧输入数量
            mAnimMixerPlayableInst = AnimationMixerPlayable.Create(mPlayableGraphInst, 1);

            
            mAnimMixerPlayableInst.SetInputWeight(0, 1f);
            
            //将mAnimMixerPlayableInst连接到mRootAnimLayerMixerPlayableInst后面
            mPlayableGraphInst.Connect(mAnimMixerPlayableInst, 0, mRootAnimLayerMixerPlayableInst, 0);
        }

        void Update()
        {
            var deltaTime = Time.deltaTime;
            mPlayableGraphInst.Evaluate(deltaTime);
        }
        
        public void AddStaticPlayable(Playable input)
        {
            mPlayableGraphInst.Connect(input, 0, mAnimMixerPlayableInst, 0);
        }
        
    }
}

