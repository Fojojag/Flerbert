using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public GameObject spawn;
    public Animator _anim;
    public bool check;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        spawn = GameObject.Find("SpawnPlayer");
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _anim.SetBool("on", true);

            
        }
    }
}
