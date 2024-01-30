using Animancer;
using UnityEngine;

namespace Scenes.AnimDemos
{
    
    public class AD_LinearBlending : MonoBehaviour
    {
        [SerializeField] AnimancerComponent AnimanceComp;
        [SerializeField] LinearMixerTransitionAsset.UnShared MixerTransAsset;


        void OnEnable()
        {
            AnimanceComp.Play(MixerTransAsset);
        }

        public float Speed
        {
            get => MixerTransAsset.State.Parameter;
            set => MixerTransAsset.State.Parameter = value;
        }

    }
}

