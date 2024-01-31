using UnityEngine;
using Animancer;

namespace Scenes.AnimDemos
{
    public enum eActorState
    {
        eIdle,
        eNT,
    }
    
    public class BaseCharacter : MonoBehaviour
    {
        public AnimancerComponent AnimanceComp;
        
        public ClipTransition ToClipAttackTransition;
        
        [SerializeReference] 
        ITransition mMixerTrans;
        public ITransition MixerTrans => mMixerTrans;
        
        
        
        public virtual void OnSwitchStateAction(eActorState state){}
    }
}
