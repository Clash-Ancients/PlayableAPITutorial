using Soul.PlayableAPI;
using UnityEngine;

public class PlayAnimOnEnable : MonoBehaviour
{
    [SerializeField] AnimanceComponent Animancer;

    [SerializeField] AnimationClip ToClip;
    
    void OnEnable()
    {
        Animancer.Play(ToClip);
    }
}