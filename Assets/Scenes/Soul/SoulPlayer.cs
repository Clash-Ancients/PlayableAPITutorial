using Animancer;
using UnityEngine;

public class SoulPlayer : MonoBehaviour
{

    [SerializeField] AnimancerComponent mAnimComp;
    public AnimancerComponent AnimComp => mAnimComp;
    
    SoulMove mSoulMove;
    
    void Awake()
    {
        mSoulMove = gameObject.GetComponent<SoulMove>();
        mSoulMove.OnInit(this);
    }


    void Update()
    {
        mSoulMove.OnUpdate(this);
    }


    void FixedUpdate()
    {
        mSoulMove.OnFixedUpdate(this);
    }
    
}
