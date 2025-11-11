using UnityEngine;

public class projetilbounce : MonoBehaviour
{

    [SerializeField] private float damage;
    [SerializeField] public float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float lifetime;


    [SerializeField] private bool isEnemy;
    [SerializeField] public bool isHorizontal;  
    void Start()
    {
        if (isHorizontal)
        {rb.linearVelocity = transform.right * speed;}
        else
        {rb.linearVelocity = transform.up * speed;}

        Invoke("destroyProjectile", lifetime);

    }

    void destroyProjectile()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.gameObject.tag == "Player")
        {
            if(isEnemy == true)
        {
            Destroy(gameObject);
        }
        }

        if (collision.gameObject.tag == "inimigo" || collision.gameObject.tag == "boss" || collision.gameObject.tag == "ground")
        {
            if (isEnemy == false)
            {

                Destroy(gameObject);
            }
        }
        if(collision.gameObject.tag == "ground")
        {
            if (transform.position.x < 0)
            {
                transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + 130);
                rb.linearVelocity = transform.right * speed;
            }
            if (transform.position.x > 0)
            {
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z - 130);
            rb.linearVelocity = transform.right * speed;
            }

        }
        
    }

    void OnBecameInvisible()

    {
       
        
        Destroy(gameObject);
        


    }
}
