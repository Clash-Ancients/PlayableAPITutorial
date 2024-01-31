using Animancer;
using UnityEngine;
using UnityEngine.AI;
namespace Scenes.AnimDemos
{
    public class IdleState<T> : CharacterState<T> where T: BaseCharacter
    {
        public IdleState(T temple) : base(temple)
        {
            mCanEnterState = true;
            mCanExitState = true;
            mCamInst = Camera.main;
            mMixerState = (LinearMixerState)mCharacter.AnimanceComp.States.GetOrCreate(mCharacter.MixerTrans);
            mNavAgent = mCharacter.gameObject.GetComponent<NavMeshAgent>();
        }

        public override void OnEnterState()
        {
            mCharacter.AnimanceComp.Play(mMixerState, 0.25f);
        }
        
        
        LinearMixerState mMixerState;
        
        NavMeshAgent mNavAgent;
        Camera mCamInst;
        Vector3 mMoveDir;
        float MoveSpeed = 3f;
        float RotSpeed = 1000f;
        
        public override void OnUpdate()
        {
            var horizontal = Input.GetAxis("Horizontal");

            var vertical = Input.GetAxis("Vertical");
        
            var transform1 = mCamInst.transform;
            var CamForward = transform1.forward;
            CamForward.y = 0f;
 
            var CamRight = transform1.right;
            CamRight.y = 0f;
                
            mMoveDir = (CamForward * vertical + CamRight * horizontal).normalized;
        
            //mMoveDir = new Vector3(horizontal, 0, vertical);
            mMixerState.Parameter = Mathf.Lerp(mMixerState.Parameter, mMoveDir.magnitude,  10f * Time.deltaTime) ;
            
            if(Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f )
                mCharacter.transform.forward = Vector3.Lerp(mCharacter.transform.forward, mMoveDir, RotSpeed * Time.deltaTime);
        }
        public override void OnFixedUpdate()
        {
            mNavAgent.velocity = mMixerState.Parameter*MoveSpeed*mMoveDir;
        }
    }
}
