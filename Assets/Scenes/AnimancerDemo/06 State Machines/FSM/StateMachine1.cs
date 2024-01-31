using UnityEngine;
namespace Scenes.AnimDemos
{
    
    public partial class StateMachine<TState> : IStateMachine 
        where TState: class, IState
    {
        TState mCurrentState;
        
        protected StateMachine(TState t)
        {
            mCurrentState = t;
            
            TryResetState(t);
        }
        
       
        
        // TState mPreviousState;
        //     
        // TState mNextState;
        
        public bool TryResetState(TState state)
        {
            if (null == state)
            {
                Debug.LogError("TryResetState input pam is null");
                return false;
            }
            
            if (!CanSetState(state))
                return false;
            
            mCurrentState?.OnExistState();

            mCurrentState = state;
            
            mCurrentState?.OnEnterState();
            
            return true;
        }

        bool CanSetState(TState state)
        {
            if (mCurrentState != null && !mCurrentState.CanExitState)
                return false;

            if (state != null && !state.CanEnterState)
                return false;

            return true;
        }
        
        public void OnUpdate<T1>(T1 _player)
        {
            mCurrentState?.OnUpdate();
        }

        public void OnFixedUpdate<T1>(T1 _player)
        {
            mCurrentState?.OnFixedUpdate();
        }
    }
}
