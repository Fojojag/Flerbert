using UnityEngine;
using UnityEngine.SceneManagement;


public class enemyhp : MonoBehaviour
{
    public float ENhealth;
    public float ENmaxhealth;
    public Animator anima;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ENhealth = ENmaxhealth;    
    }

    void Update()
    {
                if (ENhealth <= 0)
        {
            anima.SetBool("ded", true);
        }
    }

    // Update is called once per frame

    void OnCollisionEnter2D(Collision2D collision)
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
    void ded()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}