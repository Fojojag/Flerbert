using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class Arma2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float force = 10f;
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject spawnerUp;
    [SerializeField] private GameObject spawnerDown;
    [SerializeField] private Transform firepoint;
    [SerializeField] private Transform firepointUp;
    [SerializeField] private Transform firepointDown;
    public bool shot = false;
    collisiondetector CollisionDetector;
    playercontroller playerMain;
    private float shootTimer;
    [SerializeField] private float shootRate;
    public bool isCharging;
    public float chargeLvl = 0;
    public bool up;
    public bool down;
    public SpriteRenderer sideRender;
    public SpriteRenderer upRender;
    public SpriteRenderer downRender;
    public GameObject spawned;
    // Update is called once per frame
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        CollisionDetector = GetComponent<collisiondetector>();


    }
    void Update()
    {
        if (down && CollisionDetector.IsGrounded == false)
        {
            upRender.enabled = false;
            sideRender.enabled = false;
            downRender.enabled = true;
        }
        else
        if (down && CollisionDetector.IsGrounded == true)
        {
            
            sideRender.enabled = true;
            downRender.enabled = false;
        }

        
        shootTimer -= Time.deltaTime;


        if (shot == true)
        {
            shootTimer = shootRate;

            if (up)
            { spawned = Instantiate(spawnerUp, firepointUp.position, spawnerUp.transform.rotation); shot = false; }
            else
            if (down && CollisionDetector.IsGrounded == false)
            { spawned = Instantiate(spawnerDown, firepointDown.position, spawnerDown.transform.rotation); shot = false; }
            else
               spawned = Instantiate(spawner, firepoint.position, firepoint.rotation); shot = false;

        }
    }

    public void OnShoot2(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            shot = true;
           


        }

        if (context.canceled)
        {
            shot = false;
            Destroy(spawned);
        }
    }
    public void OnUp(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            up = true;
            down = false;
            upRender.enabled = true;
            sideRender.enabled = false;
            downRender.enabled = false;

        }

        if (context.canceled)
        {
            up = false;
            upRender.enabled = false;
            sideRender.enabled = true;
            

        }
    }
        public void OnDown(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            up = false;
            down = true;

        }

        if (context.canceled)
        {
            down = false;
            downRender.enabled = false;
            sideRender.enabled = true;
            

        }
    }


}
