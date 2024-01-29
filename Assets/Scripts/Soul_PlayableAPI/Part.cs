using UnityEngine.Animations;
using UnityEngine.Playables;

public class Part
{ 
    /// <summary>
    /// 动画输出管理器 : Connect PlayableGraph to Animator
    /// </summary>
    AnimationPlayableOutput Output;

    /// <summary>
    /// 动画层级混合器 : Layer Mix Controller
    /// </summary>
    AnimationLayerMixerPlayable LayerMixer;


    /// <summary>
    /// 回收Part数据
    /// </summary>
    /// <param name="_graph"></param>
    public void DestroyPart(ref PlayableGraph _graph)
    {
        
    }
}
