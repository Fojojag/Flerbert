using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class playerhp : MonoBehaviour
{
    public float health;
    public float maxhealth;
    public Animator anim;
    //public Image healthbar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxhealth;    
    }

    void Update()
    {
        //healthbar.fillAmount = Mathf.Clamp(maxhealth / health, 0, 1);
        if (health <= 0)
        {
            anim.SetBool("ded", true);
        }

    }

    // Update is called once per frame

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")          
        {
            health -= 3;
        }
        
    }
    void ded()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}