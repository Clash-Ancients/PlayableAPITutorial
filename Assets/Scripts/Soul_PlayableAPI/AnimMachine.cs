using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;

namespace Soul.PlayableAPI
{
    /// <summary>
    /// 动画层级管理逻辑
    /// </summary>
    public partial class AnimMachine : MonoBehaviour
    {
        /// <summary>
        /// Playable动画管理器
        /// </summary>
        PlayableGraph mPGInst;

        /// <summary>
        /// 动画层级字典
        /// </summary>
        Dictionary<string, Part> mDicParts = new Dictionary<string, Part>();

        /// <summary>
        /// 清空回收Part内存数据
        /// </summary>
        void OnClearParts()
        {
            if (null != mDicParts)
            {
                var list = mDicParts.Values.ToList();
                while (list.Count > 0)
                {
                    var item = list[0];
                    list.Remove(item);
                    item.DestroyPart(ref mPGInst);
                }
                mDicParts.Clear();
                mDicParts = null;
            }
        }
    }

    
    /// <summary>
    /// system callbacks
    /// </summary>
    public partial class AnimMachine : MonoBehaviour
    {
        void OnDestroy()
        {
            OnClearParts();
        }
    }
}
