using System.Collections;
using UnityEngine;

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
    private bool shotDown = false;
    public float KBCounter;
    public float KBTotalTime;
    collisiondetector CollisionDetector;
    playercontroller playerMain;
    private bool isCharging;
    // Update is called once per frame
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        CollisionDetector = GetComponent<collisiondetector>();
        playerMain = GetComponent<playercontroller>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.X) && chargeTime < 2)
        {
            isCharging = true;
            if (isCharging == true)
            {
                chargeTime += Time.deltaTime * chargeSpeed;
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            { Instantiate(projectileUp, firepointUp.position, firepointUp.rotation); }
            else
            if (Input.GetKey(KeyCode.DownArrow) && CollisionDetector.IsGrounded == false)
            { Instantiate(projectileDown, firepointDown.position, firepointDown.rotation); }
            else
                Instantiate(projectile, firepoint.position, firepoint.rotation);

        }
        else if (Input.GetKeyUp(KeyCode.X) && chargeTime >= 2)
        {
            StartCoroutine (releaseCharge());
        }
    }

    private IEnumerator releaseCharge()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Instantiate(ChargeShotUp, firepointUp.position, firepointUp.rotation);
            rb.AddForce(Vector2.up * (-force), ForceMode2D.Impulse);
        }
        else
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Instantiate(ChargeShotDown, firepointDown.position, firepointDown.rotation);
            playerMain.rb.linearVelocity = new Vector2(rb.linearVelocity.x, force);
        }
        else
        {
            Instantiate(ChargeShot, firepoint.position, firepoint.rotation);
            if (playerMain.IsFacingRight && CollisionDetector.IsGrounded == false)
            {
                playerMain.dash = -15;
                yield return new WaitForSeconds(0.5f);
                playerMain.dash = 0;
            }


            else
            if (playerMain.IsFacingRight == false && CollisionDetector.IsGrounded == false)
            {
                playerMain.dash = 15;
                yield return new WaitForSeconds(0.5f);
                playerMain.dash = 0;
            }
            
        }
        isCharging = false;
        chargeTime = 0;
    }


}
