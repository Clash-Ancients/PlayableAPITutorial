namespace Scenes.AnimDemos
{
    public abstract class CharacterState<T1> : StateBehaviour where T1 : BaseCharacter
    {
        
        public class StateMachine : StateMachine<CharacterState<T1>>.WithDefault
        {
            public StateMachine(CharacterState<T1> t) : base(t)
            {
               
                
            }
        }
        
        protected readonly T1 mCharacter;
        
        public CharacterState(T1 temple)
        {
            mCharacter = temple;
        }

        public override void OnUpdate()
        {
            
        }
        
    }
}
