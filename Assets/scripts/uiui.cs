using UnityEngine;

public class uiui : MonoBehaviour
{

    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float lifetime;


    [SerializeField] private bool isEnemy;
    [SerializeField] private bool isHorizontal;  
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

        if(collision.gameObject.tag == "trigger" || collision.gameObject.tag == "boss" || collision.gameObject.tag == "ground")
        {
            if(isEnemy == false)
        {
  
            Destroy(gameObject);
        }
        }
     
        
    }


}
