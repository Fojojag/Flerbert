using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D), typeof(collisiondetector))]

public class playercontroller : MonoBehaviour
{
    public GameObject spawn;
    public playerSpawn spawnScript;
    public bool canChange = true;
    public int wpn = 1;
    public float jumpImpulse = 10f;
    public float walkSpeed = 5f;
    public float dash = 0f;
    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    Vector2 moveInput;

    public bool KnockFromRight;
    collisiondetector CollisionDetector;
    buster wpn1;
    Arma2 wpn2;
    [SerializeField]
    private bool _isMoving = false;
    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }
        private set
        {
            _isMoving = value;
            animator.SetBool(AnimationStrings.isMoving, value);
        }
    }
    public bool IsFacingRight = true;

    public Rigidbody2D rb;
    Animator animator;

    public bool endedJumpEarly;

    private void Awake()
    {
        spawn = GameObject.Find("SpawnPlayer");
        spawnScript = spawn.GetComponent<playerSpawn>();
        transform.position = spawn.transform.position;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        CollisionDetector = GetComponent<collisiondetector>();
        wpn1 = GetComponent<buster>();
        wpn2 = GetComponent<Arma2>();
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


        if (KBCounter <= 0)
        {
            rb.linearVelocity = new Vector2(dash + moveInput.x * walkSpeed, rb.linearVelocity.y);
            animator.SetFloat(AnimationStrings.yVelocity, rb.linearVelocity.y);
        }
        else
        {
            if (KnockFromRight == true)
            {
                rb.linearVelocity = new Vector2(-KBForce, KBForce);
            }
            if (KnockFromRight == false)
            {
                rb.linearVelocity = new Vector2(KBForce, KBForce);
            }

            KBCounter -= Time.deltaTime;
        }
        if (moveInput.x < 0 && IsFacingRight == true)
        {
            flip();

        }
        else if (moveInput.x > 0 && IsFacingRight == false)
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
        if (context.started && CollisionDetector.IsGrounded)
        {
            animator.SetTrigger(AnimationStrings.jump);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpImpulse);
        }
        if (context.canceled && rb.linearVelocityY > 0 && !endedJumpEarly)
        {
            endedJumpEarly = true;
        }
    }

    public void OnChange(InputAction.CallbackContext context)
    {
        if (context.started && wpn == 1 && canChange)
        {
            wpn1.enabled = false;
            wpn2.enabled = true;
            wpn = 2;
            canChange = false;
        }
        if (context.started && wpn == 2 && canChange)
        {
            wpn1.enabled = true;
            wpn2.enabled = false;
            wpn = 1;
            canChange = false;
        }
        if (context.canceled)
        {
            canChange = true;
        }




    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Checkpoint")
        {
            spawnScript.newPos(collision.gameObject);
            
        }
    }

}
