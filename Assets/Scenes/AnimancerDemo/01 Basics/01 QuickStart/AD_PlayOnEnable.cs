using Animancer;
using UnityEngine;

namespace Scenes.AnimDemos
{
    
    public class AD_PlayOnEnable : MonoBehaviour
    {
        [SerializeField] AnimationClip ToClip;
        [SerializeField] AnimancerComponent AnimanceComp;
        
        void OnEnable()
        {
            AnimanceComp.Play(ToClip);
        }
    }

}
