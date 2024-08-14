using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;


public class AimController : MonoBehaviour
{
    [SerializeField] private AimConstraint AimChest;
    [SerializeField] private Transform aimRig;
    [SerializeField] private VectorDampener lookVector;
    public void Aim(InputAction.CallbackContext ctx)
    {
        bool val = ctx.ReadValueAsButton();
        AimChest.enabled=val;
        aimRig.gameObject.SetActive(val);
    }
    private void Update()
    {
        lookVector.Update();
        aimRig.RotateAround(aimRig.position, transform.up, lookVector.CurrentValue.x);
    }
    private void Awake()
    {
        aimRig.gameObject.SetActive(false);
    }

    public void Look(InputAction.CallbackContext ctx)
    {
        lookVector.TargetValue = ctx.ReadValue<Vector2>();
    }
}
