using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private InputActionAsset InputSystem;

    private void Start()
    {
        
    }

    public void Move(Vector2 moveVector)
    {
        rb.linearVelocity = new Vector3(moveVector.x, 0, moveVector.y);
    }
}
