using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Vector3 motionDebug;

    private int VelXId;
    private int VelYId;

#if UNITY_EDITOR
    private void OnValidate()
    {
        Move(motionDebug);
    }
#endif
    private void Awake()
    {
        VelXId = Animator.StringToHash("VelX");
        VelYId = Animator.StringToHash("VelY");
    }
    public void Move(Vector3 motionDirection)
    {
        anim.SetFloat(VelXId, motionDirection.x);
        anim.SetFloat(VelYId, motionDirection.y);
    }
}
