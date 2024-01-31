using UnityEngine;
namespace Scenes.AnimDemos
{
    public partial class StateMachine<TState> where TState : class, IState
    {
        
        public abstract class WithDefault : StateMachine<TState>
        {
            [SerializeField]
            TState _DefaultState;

   
            
            protected WithDefault(TState t) : base(t)
            {
                
            }
            
            
            
        }
    }
}
