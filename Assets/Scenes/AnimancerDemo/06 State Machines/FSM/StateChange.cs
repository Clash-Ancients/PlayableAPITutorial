using System;

namespace Scenes.AnimDemos
{
    public struct StateChange<TState> : IDisposable 
        where TState : class, IState
        
    {
        [ThreadStatic]//每一个线程都会存储一份，避免数据冲突
        private static StateChange<TState> _Current;
        
        StateMachine<TState> mStateMachine;
        
        TState mPreviousState;
        TState mNextState;
        
        public StateChange(StateMachine<TState> _machine, TState previousState, TState nextState)
        {
            this = _Current;

            mStateMachine = _machine;
            mPreviousState = previousState;
            mNextState = nextState;
        }
        
        public void Dispose()
        {
            _Current = this;
        }
    }
}
