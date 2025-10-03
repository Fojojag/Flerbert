using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class buster : MonoBehaviour
{
    public Rigidbody2D rb;
    public float force = 10f;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject projectileUp;
    [SerializeField] private GameObject projectileDown;
    [SerializeField] private Transform firepoint;
    [SerializeField] private Transform firepointUp;
    [SerializeField] private Transform firepointDown;
    [SerializeField] private GameObject ChargeShot;
    [SerializeField] private GameObject ChargeShotUp;
    [SerializeField] private GameObject ChargeShotDown;
    [SerializeField] private float chargeSpeed;
    [SerializeField] private float chargeTime;
    public bool shot = false;
    private bool shotDown = false;
    public float KBCounter;
    public float KBTotalTime;
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
    // Update is called once per frame
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        CollisionDetector = GetComponent<collisiondetector>();
        playerMain = GetComponent<playercontroller>();
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

        if (chargeTime >= 2)
        {
            chargeLvl = 1;
        }

        if (chargeTime >= 4)
        {
            chargeLvl = 2;
        }

        if (isCharging == true && chargeTime < 4)
        {

            
         chargeTime += Time.deltaTime * chargeSpeed;
            
        }
        if (shot == true && chargeLvl < 2 && shootTimer <= 0)
        {
            shootTimer = shootRate;

            if (up)
            { Instantiate(projectileUp, firepointUp.position, projectileUp.transform.rotation); shot = false; }
            else
            if (down && CollisionDetector.IsGrounded == false)
            { Instantiate(projectileDown, firepointDown.position, projectileDown.transform.rotation); shot = false; }
            else
                Instantiate(projectile, firepoint.position, firepoint.rotation); shot = false;

        }
        if (shot == true && chargeLvl == 2)
        {
            chargeLvl = 0;
            StartCoroutine(releaseCharge());
            
        }
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            shot = true;
            isCharging = true;

        }

        if (context.canceled)
        {
            if (chargeTime < 2)
            {
                shot = false;
                isCharging = false;
                chargeTime = 0;
            }
        else if (chargeTime >= 2)
            {
                
                StartCoroutine (releaseCharge());
            }
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

    private IEnumerator releaseCharge()
    {
        if (up)
        {
            Instantiate(ChargeShotUp, firepointUp.position, projectileUp.transform.rotation);
            shot = false;
            isCharging = false;
            chargeTime = 0;
            rb.AddForce(Vector2.up * (-force), ForceMode2D.Impulse);
        }
        else
        if (down)
        {
            Instantiate(ChargeShotDown, firepointDown.position, projectileDown.transform.rotation);
            shot = false;
            isCharging = false;
            chargeTime = 0;
            playerMain.rb.linearVelocity = new Vector2(rb.linearVelocity.x, force);
        }
        else
        {
            Instantiate(ChargeShot, firepoint.position, firepoint.rotation);
            shot = false;
            isCharging = false;
            chargeTime = 0;
            if (playerMain.IsFacingRight && CollisionDetector.IsGrounded == false)
            {
                shot = false;
                playerMain.dash = -120;
                yield return new WaitForSeconds(0.5f);
                playerMain.dash = 0;
            }


            else
            if (playerMain.IsFacingRight == false && CollisionDetector.IsGrounded == false)
            {
                shot = false;
                playerMain.dash = 120;
                yield return new WaitForSeconds(0.5f);
                playerMain.dash = 0;
            }

        }

    }


}
