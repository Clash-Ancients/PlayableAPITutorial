namespace Scenes.AnimDemos
{
    public class IdleState<T> : CharacterState<T> where T: BaseCharacter
    {
        public IdleState(T temple) : base(temple)
        {
            mCharacter.AnimanceComp.Play(mCharacter.ToClipTransition);
        }
    }
}
