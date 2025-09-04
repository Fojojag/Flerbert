using System.Timers;
using Unity.VisualScripting;
using UnityEngine;

public class bolha : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float lifetime;


    [SerializeField] private bool isEnemy;
    [SerializeField] private bool isHorizontal;
    public GameObject boss;
    public GameObject player;
    public float timer = 1f;



    public int numero;
    void Start()
    {
        Invoke("destroyProjectile", lifetime);
    
    }

    void Update()
    {

        if (timer >= 0)
        {
            timer -= Time.deltaTime;

        }
        if (timer <= 0)
        {
            timer = 1;
            numero = Random.Range(0, 2);
        }
        
        


        //movimentação da bolha
            if (numero == 0 && boss.transform.position.x <= player.transform.position.x)
            {
                rb.linearVelocity = new Vector2(speed, speed * 1 / 4);
            }

        if (numero == 1 && boss.transform.position.x <= player.transform.position.x)
        {
            rb.linearVelocity = new Vector2(speed, -speed * 1 / 6);
        }

        if (numero == 0 && boss.transform.position.x >= player.transform.position.x)
        {
            rb.linearVelocity = new Vector2(-speed, speed * 1 / 4);
        }

        if (numero == 1 && boss.transform.position.x >= player.transform.position.x)
        {
            rb.linearVelocity = new Vector2(-speed, -speed * 1 / 6);
        }    

    }


    void destroyProjectile()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if(collision.gameObject.tag == "Player")
        {
            if(isEnemy == true)
        {
            Destroy(gameObject);
        }
        }

        if(collision.gameObject.tag == "gunvolt")
        {
            if(isEnemy == false)
        {
  
            Destroy(gameObject);
        }
        }
        
    }

   
}
