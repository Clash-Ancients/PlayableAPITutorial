using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Soul.PlayableAPI
{
    
    //构造AnimancerPlayable
    public partial class AnimancerPlayable : PlayableBehaviour
    {

        Playable mRootPlayable;

        PlayableGraph mGraph;
        
        public static AnimancerPlayable Create()
        {
            var graph = PlayableGraph.Create("AnimancerPlayableGraph");

            return Create(graph);
        }

        static readonly AnimancerPlayable Template = new AnimancerPlayable();
        
        static AnimancerPlayable Create(PlayableGraph _playGraph)
        {
            return Create(_playGraph, Template);
        }

        static AnimancerPlayable Create<T>(PlayableGraph _playGraph, T _template) where T: AnimancerPlayable, new()
            => ScriptPlayable<T>.Create(_playGraph, _template, 2).GetBehaviour();

        public override void OnPlayableCreate(Playable playable)
        {
            mRootPlayable = playable;

            mGraph = playable.GetGraph();
            
            playable.SetInputWeight(0, 1);
            
           var LayerMixer = AnimationLayerMixerPlayable.Create(mGraph, 1);
           mGraph.Connect(LayerMixer, 0, mRootPlayable, 0);
        }

        public void CreateOutput(Animator animator, IAnimancerComponent animancer)
        {
            
            AnimationPlayableUtilities.Play(animator, mRootPlayable, mGraph);
        }

    }
    
    public partial class AnimancerPlayable : PlayableBehaviour
    {
        public void Play()
        {
            
        }
    }

}
