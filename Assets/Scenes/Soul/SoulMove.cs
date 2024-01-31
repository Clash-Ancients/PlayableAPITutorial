using Animancer;
using UnityEngine;
using UnityEngine.AI;

public class SoulMove : MonoBehaviour
{
    [SerializeReference] ITransition MixerTrans;

    NavMeshAgent mNavAgent;

    LinearMixerState MixerState;

    Vector3 mMoveDir;

    public float MoveSpeed;
    public float RotSpeed;
    public Camera mCamInst;
    public float transSpeed = 0.8f;
    public void OnInit(SoulPlayer player)
    {
        player.AnimComp.Play(MixerTrans);

        MixerState = (LinearMixerState)player.AnimComp.States.GetOrCreate(MixerTrans);
        
        mNavAgent = gameObject.GetComponent<NavMeshAgent>();
    }
    
    public void OnUpdate(SoulPlayer player)
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

        MixerState.Parameter = mMoveDir.magnitude;

        if(mMoveDir != Vector3.zero)
            transform.forward = Vector3.Lerp(transform.forward, mMoveDir, RotSpeed * Time.deltaTime);

    }


    public void OnFixedUpdate(SoulPlayer player)
    {
        mNavAgent.velocity = MixerState.Parameter*MoveSpeed*mMoveDir;
    }
}
