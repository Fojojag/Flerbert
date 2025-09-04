using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D), typeof(collisiondetector))]

public class playercontroller : MonoBehaviour
{
    public float jumpImpulse = 10f;
    public float walkSpeed = 5f;
    public float dash = 0f;
    Vector2 moveInput;
    collisiondetector CollisionDetector;
    [SerializeField]
    private bool _isMoving = false;
    public bool IsMoving { get 
    {
        return _isMoving; 
    } private set
    {
        _isMoving = value;
        animator.SetBool(AnimationStrings.isMoving, value);
    }
    }
    public bool IsFacingRight = true;

    public Rigidbody2D rb;
    Animator animator;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        CollisionDetector = GetComponent<collisiondetector>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
           //if(moveInput.x < 0)
     //{
         //transform.localScale = new Vector3(-1, 1, 1);
         
    // }else if(moveInput.x > 0)
    // {
        // transform.localScale = Vector3.one;
     //}
    //}

    private void FixedUpdate()
    {
      rb.linearVelocity = new Vector2(dash + moveInput.x * walkSpeed, rb.linearVelocity.y);  
      animator.SetFloat(AnimationStrings.yVelocity, rb.linearVelocity.y);


        if(moveInput.x < 0 && IsFacingRight == true)
     {
        flip();
         
     }else if(moveInput.x > 0 && IsFacingRight == false)
     {
         flip();
     }
    }

    void flip()
    {
        transform.Rotate(0f, 180f, 0f);
        IsFacingRight = !IsFacingRight;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;



    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.started && CollisionDetector.IsGrounded)
        {
            animator.SetTrigger(AnimationStrings.jump);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpImpulse);
        }
    }

}
