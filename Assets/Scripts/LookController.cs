using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookController : MonoBehaviour
{
    [SerializeField] private VectorDampener lookVector;
    [SerializeField] private Transform lookRig;
    [SerializeField] private float sens;



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
        lookRig.RotateAround(lookRig.position, transform.up, lookVector.CurrentValue.x*sens*360f);
    }
}
