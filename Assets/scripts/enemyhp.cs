using UnityEngine;
using UnityEngine.SceneManagement;


public class enemyhp : MonoBehaviour
{
    public float ENhealth;
    public float ENmaxhealth;
    public Animator anima;
    public Enemybase corpo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ENhealth = ENmaxhealth;    
    }

    void Update()
    {
                if (ENhealth <= 0)
        {
            corpo.Invoke("ded", 0.1f);
            Destroy(gameObject);
            
        }
    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "limao")          
        {
            ENhealth -= 3;
        }
        
                if(collision.gameObject.tag == "chargeshot")          
        {
            ENhealth -= 10;
        }
        
    }


}