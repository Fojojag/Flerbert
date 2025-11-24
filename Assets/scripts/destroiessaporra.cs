using UnityEngine;

public class destroiessaporra : MonoBehaviour
{
    public GameObject BGM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" )
        {
           Destroy(BGM); 
        }
        
    }
}
