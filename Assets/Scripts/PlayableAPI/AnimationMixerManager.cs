using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Soul.PlayableAPI
{
    public struct RuntimeData
    {
        public int Id;
        public int PortIndex;
        public float Weight;
        public float SmoothWeight;
        public float FadeDuration;
        public Playable PlayableInst;
    }

    public class LayeredPlayablesController
    {
        AnimationMixerPlayable mRootMixer;
        Queue<int> mRecycleIndex = new Queue<int>();
        List<RuntimeData> mListRuntimeData = new List<RuntimeData>();
        Dictionary<int, RuntimeData> mDicRuntimeData = new Dictionary<int, RuntimeData>();
        int mCurPlayableId = -1;
        int mLastPlayableId = -1;
        public void OnSetRootMixer(AnimationMixerPlayable _root)
        {
            mRootMixer = _root;
        }
        
        public void PlayDynamicPlayable(Playable _playable, PlayableGraph _playGraph)
        {
            int portIndex = mRecycleIndex.Count > 0 ? mRecycleIndex.Dequeue() : mListRuntimeData.Count;
            
            //诉求 ： 第一个没有播放完毕的情况下，又来了一个请求，那么portIndex如何设置
            
            //如何缓存新的播放动画逻辑index

            var id = _playable.GetHashCode();

            var runTimeData = new RuntimeData
            {
                Id = id,
                PortIndex = portIndex,
                FadeDuration = 0.3f,
                Weight = 0f,
                SmoothWeight = 0f,
                PlayableInst = _playable,
            };
            
            mRootMixer.SetInputWeight(portIndex, 0);
            
            _playable.SetTime(0f);
            
            _playGraph.Connect(_playable, 0, mRootMixer, portIndex);

            if (mListRuntimeData.Count > 0)
            {
                mLastPlayableId = mCurPlayableId;
            }
            else
            {
                mLastPlayableId = id;
            }
            
            mCurPlayableId = id;
            
            mListRuntimeData.Add(runTimeData);
            mDicRuntimeData.Add(id, runTimeData);
        }

        public void Evaluate(float dt)
        {
            if(mDicRuntimeData.Count  == 0)
                return;
            
            var runtimePlayable = mDicRuntimeData[mCurPlayableId];
            
            var diffThisFrame = runtimePlayable.FadeDuration == 0 ? 1 : dt / runtimePlayable.FadeDuration;
            
            for(var i = 0; i <= mListRuntimeData.Count - 1; i++)
            {
                var p = mListRuntimeData[i];
                if (p.Id == mCurPlayableId)
                {
                    p.Weight += diffThisFrame;
                    p.Weight = Mathf.Clamp(p.Weight, 0, 1f);
                    p.SmoothWeight = Mathf.Lerp(p.SmoothWeight, p.Weight, 1f - Mathf.Exp(-25f*dt));
                }
                else if (p.Id == mLastPlayableId)
                {
                    p.Weight -= diffThisFrame;
                    p.Weight = Mathf.Clamp(p.Weight, 0, 1f);
                    p.SmoothWeight = Mathf.Lerp(p.SmoothWeight, p.Weight, 1f - Mathf.Exp(-25f*dt));
                }

                mListRuntimeData[i] = p;
                mDicRuntimeData[p.Id] = p;
                mRootMixer.SetInputWeight(p.PortIndex, p.SmoothWeight);
            }
        }

        public void LateUpdate(ref PlayableGraph _graph)
        {
            RuntimeData tmpData = default(RuntimeData);
            bool isFound = false;
            for (var i = 0; i <= mListRuntimeData.Count - 1; i++)
            {
                var p = mListRuntimeData[i];

                if (p.Id != mCurPlayableId && 
                    p.SmoothWeight < 0.001f &&
                    mDicRuntimeData[mCurPlayableId].SmoothWeight > 0.99f
                    )
                {
                    if (p.Id == mLastPlayableId)
                    {
                        mLastPlayableId = -1;
                    }
                    
                    mRecycleIndex.Enqueue(p.PortIndex);
                    
                   
                    isFound = true;
                    tmpData = p;
                    break;
                }
            }
            
            if (isFound)
            {
                mListRuntimeData.Remove(tmpData);
                mDicRuntimeData.Remove(tmpData.Id);
                _graph.Disconnect(mRootMixer, tmpData.PortIndex);
                _graph.DestroyPlayable(tmpData.PlayableInst);
            }
            
        }
    }
    
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

        List<LayeredPlayablesController> mListLayerPlablesCtrl = new List<LayeredPlayablesController>();
        
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
            mMixerInst = AnimationMixerPlayable.Create(mPGInst, 10);
            
            mMixerInst.SetInputWeight(0, 1f);
            
            //将mMixerInst连接到mRootLayerMixerInst后面
            mPGInst.Connect(mMixerInst, 0, mRootLayerMixerInst, 0);

            LayeredPlayablesController ctrl = new LayeredPlayablesController();

            ctrl.OnSetRootMixer(mMixerInst);
            
            mListLayerPlablesCtrl.Add(ctrl);
        }

        void Update()
        {
            var deltaTime = Time.deltaTime;
            
            foreach (var VARIABLE in mListLayerPlablesCtrl)
            {
                VARIABLE.Evaluate(deltaTime);
            }
            
            mPGInst.Evaluate(deltaTime);
        }

        void LateUpdate()
        {
            foreach (var VARIABLE in mListLayerPlablesCtrl)
            {
                VARIABLE.LateUpdate(ref mPGInst);
            }
        }



        public void AddStaticPlayable(Playable input)
        {
            
            mPGInst.Connect(input, 0, mMixerInst, 0);
        }

        public void PlayDynamicPlayable(Playable _playable, int _layerIndex)
        {
            mListLayerPlablesCtrl[_layerIndex].PlayDynamicPlayable(_playable, mPGInst);
        }
        
    }
}

