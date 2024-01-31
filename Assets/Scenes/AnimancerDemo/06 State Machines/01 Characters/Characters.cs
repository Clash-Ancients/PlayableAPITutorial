using System;
using System.Collections.Generic;
using Scenes.AnimDemos;
using UnityEngine;



[DefaultExecutionOrder(-10000)]// Initialize the StateMachine before anything uses it.
public class Characters : BaseCharacter
{
   

    CharacterState<Characters>.StateMachine mStateMachine;

    Dictionary<eActorState, CharacterState<Characters>> mDic = new Dictionary<eActorState, CharacterState<Characters>>();
    
    void Awake()
    {
        
        
        var idleState = new IdleState<Characters>(this);

        var attackState = new AttackState<Characters>(this);
        
        mDic.Add(eActorState.eIdle, idleState);
        
        mDic.Add(eActorState.eNT, attackState);
        
        mStateMachine = new CharacterState<Characters>.StateMachine(idleState);
    }

    void Update()
    {
        mStateMachine.OnUpdate(this);
    }

    void FixedUpdate()
    {
        mStateMachine.OnFixedUpdate(this);
    }

    public void OnClickAttack()
    {
        mStateMachine.TryResetState(mDic[eActorState.eNT]);
    }

    public override void OnSwitchStateAction(eActorState state)
    {
        mStateMachine.TryResetState(mDic[state]);
    }
}