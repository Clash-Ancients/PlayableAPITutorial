using Scenes.AnimDemos;
using UnityEngine;

[DefaultExecutionOrder(-10000)]// Initialize the StateMachine before anything uses it.
public class Characters : BaseCharacter
{

    CharacterState<Characters>.StateMachine mStateMachine;
    
    void Awake()
    {
        var idleState = new IdleState<Characters>(this);

        mStateMachine = new CharacterState<Characters>.StateMachine(idleState);
    }
}