using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponFire : MonoBehaviour
{   
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Fire(InputAction.CallbackContext ctx)
    {
        bool state = ctx.ReadValueAsButton();
        anim.SetBool("Shooting", state);
    }
    // Start is called before the first frame update
  public void OnShoot()
    {
        Debug.Log("piu");
    }
}
