using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;


public class AimController : MonoBehaviour
{
    [SerializeField] private AimConstraint AimChest;
    [SerializeField] private Transform aimRig;
    [SerializeField] private Transform camTransform;
    [SerializeField] private Animator anim;

    bool aiming;

    public void Aim(InputAction.CallbackContext ctx)
    {
        bool val = ctx.ReadValueAsButton();
        aiming = val;
        AimChest.enabled=val;
        aimRig.gameObject.SetActive(val);
        anim.SetBool("Aim", val);
    }
   
    private void Awake()
    {
        aimRig.gameObject.SetActive(false);
    }
    private void Update()
    {
        if(aiming)transform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(camTransform.forward,transform.up).normalized);
    }
}
