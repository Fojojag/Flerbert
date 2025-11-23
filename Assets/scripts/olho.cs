using UnityEngine;

public class olho : MonoBehaviour
{
    public AudioClip boom;
    [SerializeField] private float damage;
    [SerializeField] public float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float lifetime;
    public Transform spawnpoint;
    public GameObject kabum;
    public GameObject waveDir;
    public GameObject waveEsq;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * speed;

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "chao")
        {
            Instantiate(kabum, spawnpoint.position, kabum.gameObject.transform.rotation);
            AudioSource.PlayClipAtPoint(boom, transform.position, 1);
            Instantiate(waveDir, spawnpoint.position, waveDir.gameObject.transform.rotation);
            Instantiate(waveEsq, spawnpoint.position, waveEsq.gameObject.transform.rotation);
            Destroy(gameObject);
        }  
            if(collision.gameObject.tag == "Player")
        {
            Instantiate(kabum, spawnpoint.position, kabum.gameObject.transform.rotation);
            AudioSource.PlayClipAtPoint(boom, transform.position, 1);
            Destroy(gameObject);        
        }  
    }

    void OnBecameInvisible()

    {
       
        
        Destroy(gameObject);
        


    }
}


