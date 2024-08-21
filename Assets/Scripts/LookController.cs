using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookController : MonoBehaviour
{
    [SerializeField] private VectorDampener lookVector;
    [SerializeField] private Transform lookRig;
    [SerializeField] private float sens;
    [SerializeField] private Vector2 verticalRotationLimits;


    float rotationary;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Look(InputAction.CallbackContext ctx)
    {
        lookVector.TargetValue = ctx.ReadValue<Vector2>() / new Vector2(Screen.width, Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        lookVector.Update();
        lookRig.RotateAround(lookRig.position, transform.up, lookVector.CurrentValue.x * sens * 360f);
        rotationary -= lookVector.CurrentValue.y * sens * 360f;
        rotationary = Mathf.Clamp(rotationary, verticalRotationLimits.x, verticalRotationLimits.y);
        Vector3 euler = lookRig.localEulerAngles;
        lookRig.localEulerAngles = new Vector3 (rotationary, euler.y, euler.z);

    }
}
