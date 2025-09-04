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
    public bool isCharging;
    public float chargeLvl = 0;
    // Update is called once per frame
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        CollisionDetector = GetComponent<collisiondetector>();
        playerMain = GetComponent<playercontroller>();
    }
    void Update()
    {
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
        if (shot == true && chargeLvl < 2)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            { Instantiate(projectileUp, firepointUp.position, firepointUp.rotation); shot = false; }
            else
            if (Input.GetKey(KeyCode.DownArrow) && CollisionDetector.IsGrounded == false)
            { Instantiate(projectileDown, firepointDown.position, firepointDown.rotation); shot = false; }
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

    private IEnumerator releaseCharge()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Instantiate(ChargeShotUp, firepointUp.position, firepointUp.rotation);
            shot = false;
            isCharging = false;
            chargeTime = 0;
            rb.AddForce(Vector2.up * (-force), ForceMode2D.Impulse);
        }
        else
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Instantiate(ChargeShotDown, firepointDown.position, firepointDown.rotation);
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
