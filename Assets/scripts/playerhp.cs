using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class playerhp : MonoBehaviour
{
    public GameObject vida1;
    public GameObject vida2;
    public GameObject vida3;
    public GameObject vida4;

    SpriteRenderer rend;
    Color c;
    public playercontroller playercontrl;
    public int currenthealth;
    public int maxhealth = 4;
    //public HealthBar healthBar;
    [SerializeField] private GameObject explosion;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] private Transform firepoint;

    public Animator anim;
    //public Image healthbar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public bool IsTakingDmg = false;
    void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 7, false);
        rend = GetComponent<SpriteRenderer>();
        c = rend.color;
        currenthealth = maxhealth;
        //healthBar.SetMaxHealth(maxhealth);
    }

    void Update()
    {
        //healthbar.fillAmount = Mathf.Clamp(maxhealth / health, 0, 1);
        if (currenthealth <= 0)
        {

            ded();
        }
        if (currenthealth > maxhealth)
        {

            currenthealth = maxhealth;
        }

        if (currenthealth == 3)
        {
            Destroy(vida4);
        }
        if (currenthealth == 2)
        {
            Destroy(vida3);
        }
        if (currenthealth == 1)
        {
            Destroy(vida2);
        }




    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "inimigo" && IsTakingDmg == false)
        {
            playercontrl.KBCounter = playercontrl.KBTotalTime;
            if (collision.transform.position.x >= transform.position.x)
            {
                playercontrl.KnockFromRight = true;
            }
            if (collision.transform.position.x <= transform.position.x)
            {
                playercontrl.KnockFromRight = false;
            }
            IsTakingDmg = true;
            anim.SetBool("isTakingDmg", true);
            TakeDamage(1);
        }
        if (collision.gameObject.tag == "espinhos" && IsTakingDmg == false)
        {
            IsTakingDmg = true;
            anim.SetBool("isTakingDmg", true);
            TakeDamage(20);
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "boss" && IsTakingDmg == false || collision.gameObject.tag == "inimigo" && IsTakingDmg == false)
        {
            playercontrl.KBCounter = playercontrl.KBTotalTime;
            if (collision.transform.position.x >= transform.position.x)
            {
                playercontrl.KnockFromRight = true;
            }
            if (collision.transform.position.x <= transform.position.x)
            {
                playercontrl.KnockFromRight = false;
            }
            IsTakingDmg = true;
            //anim.SetBool("isTakingDmg", true);
            TakeDamage(1);
        }
        if (collision.gameObject.tag == "weak" && IsTakingDmg == false)
        {

            TakeDamage(2);
        }
        if (collision.gameObject.tag == "death")
        {

            ded();
        }

        if (collision.gameObject.tag == "kill")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
    void TakeDamage(int damage)
    {
        currenthealth -= damage;
        //healthBar.SetHealth(currenthealth);
        hit();
        StartCoroutine(DamageBoost());


    }
    void hit()
    {
        IEnumerator hit_Cor()
        {
            spriteRenderer.material.SetInt("_hit", 1);
            yield return new WaitForSeconds(0.15f);
            spriteRenderer.material.SetInt("_hit", 0);
            IsTakingDmg = false;
        }
        StartCoroutine(hit_Cor());
    }


    void dmgEnd()
    {
        IsTakingDmg = false;
        anim.SetBool("isTakingDmg", false);
    }
    void ded()
    {
        Instantiate(explosion, firepoint.position, firepoint.rotation);
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    IEnumerator DamageBoost()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        c.a = 0.5f;
        rend.color = c;
        yield return new WaitForSeconds(1.3f);
        Physics2D.IgnoreLayerCollision(6, 7, false);
        c.a = 1f;
        rend.color = c;

        }



}
