using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Soul.PlayableAPI
{
    public class AnimationMixerManager : MonoBehaviour
    {

        PlayableGraph mPGInst;
        public PlayableGraph PGInst => mPGInst;
        
        //Output
        AnimationPlayableOutput mOutputInst;
        
        //Layer mixer
        AnimationLayerMixerPlayable mRootLayerMixerInst;
        
        //mixer
        AnimationMixerPlayable mMixerInst;
        
        Animator mAnimatorInst;
        
        void Awake()
        {
            mAnimatorInst = gameObject.GetComponentInChildren<Animator>();
            
            //创建PlayableGraph - 管理多个Playable的结构
            mPGInst = PlayableGraph.Create(gameObject.name + "AnimMixerManager");

            //创建AnimationOutPut
            mOutputInst = AnimationPlayableOutput.Create(mPGInst, "AnimatioinOutPut", mAnimatorInst);
            
            //创建AnimationLayerMixerPlayable
            mRootLayerMixerInst = AnimationLayerMixerPlayable.Create(mPGInst, 0);
            
            //将mRootLayerMixerInst连接在mOutputInst后面
            mOutputInst.SetSourcePlayable(mRootLayerMixerInst, 0);
            
            //设置右侧的输入数量
            mRootLayerMixerInst.SetInputCount(1);
            
            //mPGInst.Stop();
            
            //创建AnimationMixerPlayable,并且设置右侧输入数量
            mMixerInst = AnimationMixerPlayable.Create(mPGInst, 1);

            
            mMixerInst.SetInputWeight(0, 1f);
            
            //将mMixerInst连接到mRootLayerMixerInst后面
            mPGInst.Connect(mMixerInst, 0, mRootLayerMixerInst, 0);
        }

        void Update()
        {
            var deltaTime = Time.deltaTime;
            mPGInst.Evaluate(deltaTime);
        }
        
        public void AddStaticPlayable(Playable input)
        {
            
            mPGInst.Connect(input, 0, mMixerInst, 0);
        }
        
    }
}

