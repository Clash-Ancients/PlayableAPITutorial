namespace Scenes.AnimDemos
{
    public interface IState
    {
        bool CanEnterState { get; }

        bool CanExitState { get; }

        void OnEnterState();
        
        void OnExistState();

        void OnUpdate();
        
        void OnFixedUpdate();
    }
}
