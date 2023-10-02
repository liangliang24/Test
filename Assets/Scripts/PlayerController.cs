using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    private Vector2 moveInput;

    [SerializeField]
    private bool _isMoving = false;

    [SerializeField]
    private bool _isRunning = false;    

    private Rigidbody2D rb;
    Animator animator;

    public bool IsRunning
    {  
        get 
        { 
            return _isRunning; 
        }
        set 
        { 
            _isRunning = value;
            animator.SetBool(AnimationStrings.IsRunning, value);
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * walkSpeed * Time.fixedDeltaTime, 
            moveInput.y * walkSpeed * Time.fixedDeltaTime);
        

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;

        if (moveInput.x > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveInput.x < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }
        set
        {
            _isMoving = value;
            animator.SetBool(AnimationStrings.IsMoving, value);
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            IsRunning = true;
            walkSpeed += 200;
        }
        else if(context.canceled) 
        {
            IsRunning = false;
            walkSpeed -= 200;

        }
    }
}
