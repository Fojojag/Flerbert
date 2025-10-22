using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public GameObject spawn;
    public Animator _anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        GameObject spawn = GameObject.Find("SpawnPlayer");
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _anim.SetBool("on", true);
            spawn.transform.position = transform.position;
            
        }
    }
}
