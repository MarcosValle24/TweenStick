using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float gravity = -9.81f;
    
    public InputAction move;
    public InputAction aim;
    CharacterController playerMove;
    
    private Vector3 playerVelocity;

    private void OnEnable()
    {
        move.Enable();
        aim.Enable();
    }
        
    private void OnDisable()
    {
        move.Disable();
        aim.Disable();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMove = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
       CharacterAim();
        CharacterMove();
    }

    void CharacterMove()
    {
        Vector3 movement = new Vector3(move.ReadValue<Vector2>().x, 0, move.ReadValue<Vector2>().y);
        movement = Vector3.ClampMagnitude(movement, 1f);
        
        playerVelocity.y += gravity * Time.deltaTime;
        Vector3 finalMove = movement * speed + Vector3.up * playerVelocity.y;
        playerMove.Move(finalMove * Time.deltaTime);
    }

    void CharacterAim()
    {
        Ray r = Camera.main.ScreenPointToRay(aim.ReadValue<Vector2>());
        Plane p = new Plane(Vector3.up, Vector3.zero);
        float d;

        if (p.Raycast(r, out d))
        {
            Vector3 point = r.GetPoint(d);
            Vector3 correctedPoint = new Vector3(point.x,transform.position.y,point.z);
            transform.LookAt(correctedPoint);
        }
    }
}
