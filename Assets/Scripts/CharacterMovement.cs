using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using CallbackContext = UnityEngine.InputSystem.InputAction.CallbackContext;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private VectorDampener motionVector = new VectorDampener(true);


    private int VelXId;
    private int VelYId;

    public void Move(CallbackContext ctx)
    {
        Vector2 direction = ctx.ReadValue<Vector2>();
        motionVector.TargetValue = direction;
       
    }
    public void ToggleSprint(CallbackContext ctx) 
    {
        bool val = ctx.ReadValueAsButton();
        motionVector.Clamp = !val;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
    }
#endif
    private void Awake()
    {
        VelXId = Animator.StringToHash("VelX");
        VelYId = Animator.StringToHash("VelY");
    }
    private void Update()
    {
        motionVector.Update();
        Vector2 direction = motionVector.CurrentValue;
        anim.SetFloat(VelXId, direction.x);
        anim.SetFloat(VelYId, direction.y);
    }
}