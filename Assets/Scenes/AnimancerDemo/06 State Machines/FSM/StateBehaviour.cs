namespace Scenes.AnimDemos
{
    public abstract class StateBehaviour : IState
    {
        protected bool mCanEnterState;
        public bool CanEnterState =>mCanEnterState;
        
        protected bool mCanExitState;
        public bool CanExitState
        {
            get => mCanExitState;
        }

        public virtual void OnEnterState() {}
        
        public virtual void OnExistState()
        {
        }

        public abstract void OnUpdate();
        
        public abstract void OnFixedUpdate();
    }
}
