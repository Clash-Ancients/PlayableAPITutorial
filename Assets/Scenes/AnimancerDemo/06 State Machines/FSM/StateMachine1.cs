using UnityEngine;
namespace Scenes.AnimDemos
{
    
    public partial class StateMachine<TState> : IStateMachine 
        where TState: class, IState
    {
        TState mCurrentState;
        
        public StateMachine()
        {
            // mCurrentState = _curState;
            //
            // if (null != mCurrentState)
            // {
            //     using (new StateChange<TState>(this, null, mCurrentState))
            //     {
            //         mCurrentState.OnEnterState();
            //     }
            //
            //     return;
            // }
            //
            // Debug.LogError("null == _curState");
        }
        
       
    }
}
