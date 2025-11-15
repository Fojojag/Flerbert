using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class FinalBossHP : MonoBehaviour
{
    public SpriteRenderer rend;
    Color c;
    public Animator headAnim;
    public float ENhealth;
    public float ENmaxhealth;
    public FinalBoss main;
    public GameObject espinhos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ENhealth = ENmaxhealth;
        rend = GetComponent<SpriteRenderer>();
        c = rend.color;

    }

    void Update()
    {
        rend.color = c;
                if (ENhealth <= 0)
        {
            Destroy(main);

            Destroy(espinhos);
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("inimigo");
            foreach (GameObject target in gameObjects)
            {
                GameObject.Destroy(target);
            }
            headAnim.SetTrigger("ded");

            
        }
    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "limao")
        {
            ENhealth -= 3;
            hit();
        }

        if (collision.gameObject.tag == "chargeshot")
        {
            ENhealth -= 10;
            hit();
        }

    }
    void hit()
    {
        IEnumerator hit_Cor()
        {
            c.a = 0.2f;
            yield return new WaitForSeconds(0.1f);
            c.a = 1f;
           
        }
        StartCoroutine(hit_Cor());
    }


}
