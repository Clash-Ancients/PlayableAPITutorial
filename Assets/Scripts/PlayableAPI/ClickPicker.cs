using System;
using UnityEngine;

namespace Test.PlayableAPI
{
    public class ClickPicker : MonoBehaviour
    {
        public AnimationClip[] ClipArray;

        int mCurIndex;

        protected AnimationClipOutPut mAnimOutput;

        void Awake()
        {
            mAnimOutput = gameObject.GetComponent<AnimationClipOutPut>();
           
        }

        public void OnClickPlayNext()
        {
            if (mCurIndex >= ClipArray.Length)
            {
                mCurIndex = 0;
            }
            mAnimOutput.toClipInst = ClipArray[mCurIndex];
            
            mAnimOutput.Play();
            
            mCurIndex++;
        }
    } 
}



