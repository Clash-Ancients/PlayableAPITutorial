using Animancer;
namespace Scenes.AnimDemos
{
    public class AttackState<T> : CharacterState<T> where T: BaseCharacter
    {
        public AttackState(T temple) : base(temple)
        {
            ResetAuthority();
        }

        AnimancerState mState;
        
        public override void OnEnterState()
        {
            
            
            
            
            mState = mCharacter.AnimanceComp.Play(mCharacter.ToClipAttackTransition);

            mState.Events.Clear();
            
            mState.Events.OnEnd = AnimEnd;
            
            mState.Events.Add(0.5f, () =>
            {
                mCanExitState = true;
            });
            
        }


        public override void OnUpdate()
        {
            
        }
        public override void OnFixedUpdate()
        {
        }

        void AnimEnd()
        {
            mCanExitState = true;
            mCharacter.OnSwitchStateAction(eActorState.eIdle);
        }

        public override void OnExistState()
        {
            ResetAuthority();
        }

        void ResetAuthority()
        {
            mCanEnterState = true;
            mCanExitState = false;
        }
    }
}
