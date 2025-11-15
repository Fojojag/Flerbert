using UnityEngine;

public class Enemybase : MonoBehaviour
{

    [SerializeField] private float damage;
    [SerializeField] public float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float lifetime;
    [SerializeField] private bool Respawn;

    [SerializeField] private bool isEnemy;
    [SerializeField] private bool isHorizontal;  
    void Start()
    {


    }
    void Update()
    {
        if (isHorizontal)
           { rb.linearVelocity = Vector2.right * speed; }
        else
        { rb.linearVelocity = new Vector2(0, speed); }

    }
    void OnBecameInvisible()

    {
        if (Respawn)
        {
            Destroy(gameObject);
        }


    }

    void ded()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.gameObject.tag == "Turn")
        {
            transform.Rotate(0f, 180f, 0f);
            speed = -speed;
        }


        
    }

}
