using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerInputController : TopDownController
{
    private Camera camera;
    private void Awake()
    {
        camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
       
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        if (newAim.magnitude >= .9f)
        
        {
            CallLookEvent(newAim);
        }
    }

    public void OnFire(InputValue value)
    {
        Debug.Log("OnFire" + value.ToString());
    }

}
